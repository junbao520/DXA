using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using DCommon;
using GalaSoft.MvvmLight.Messaging;

namespace Signal
{
    public abstract class SocketCarSignalSeedV4
    {
        public const string DefaultIPAddress = "192.168.4.1";
        public const int DefaultPort = 4000;
        public IPEndPoint RemoteEndpoint { get; protected set; }

        protected Socket Socket { get; set; }
        protected SocketAsyncEventArgs SocketArgs { get; set; }
        protected MessageBuffers Buffer { get; set; }

        protected CancellationTokenSource CancellationSource { get; set; }

        protected AutoResetEvent Event { get; set; }

        protected ILog Logger { get; set; }

        public List<KeyValuePair<int, Socket>> lstSendSocket = new List<KeyValuePair<int, Socket>>();

        protected virtual bool Connected
        {
            get { return Socket != null && Socket.Connected; }
        }

        protected SocketCarSignalSeedV4(IMessenger messenger)
        {
            Buffer = new MessageBuffers();
            Logger = LogManager.GetLogger(GetType());
        }

        public void Init(NameValueCollection settings)
        {
           
            RemoteEndpoint = new IPEndPoint(IPAddress.Any, DefaultPort);
            Logger.DebugFormat("SocketCarSignalSeedV4 - {0};", RemoteEndpoint);
        }

        public async Task InitAsync()
        {

            Socket = await InitSocketAsync();
            SocketArgs = CreateSocketArgs();
            StartReceive(SocketArgs);
        }



        protected virtual SocketAsyncEventArgs CreateSocketArgs()
        {
            var receiveEventArgs = new SocketAsyncEventArgs();
            receiveEventArgs.UserToken = Socket;
            receiveEventArgs.RemoteEndPoint = RemoteEndpoint;
            receiveEventArgs.AcceptSocket = Socket;
            receiveEventArgs.SetBuffer(new byte[10000], 0, 10000);
            receiveEventArgs.Completed += ReceiveEventArgsOnCompleted;
            return receiveEventArgs;
        }
        /// <summary>
        /// 每一次开始考试创建一个对应的发送的Socket
        /// </summary>
        /// <param name="Ip"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        public void CreateSendSocket(string Ip,int Port,int Key)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, true);
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(Ip), Port);
            socket.Connect(remoteIpep);
            if (lstSendSocket.Where(s=>s.Key==Key).Count()>0)
            {
                var item = lstSendSocket.Where(s => s.Key == Key).FirstOrDefault();
                lstSendSocket.Remove(item);
            }
            lstSendSocket.Add(new KeyValuePair<int, Socket>(Key, socket));
        }
        /// <summary>
        ///通过Socket 发送数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="Key"></param>
        public void SocketSend(string msg,int Key)
        {
            var socket = lstSendSocket.Where(s => s.Key == Key).FirstOrDefault().Value;
            byte[] sendbytes = Encoding.Default.GetBytes(msg);
            socket.Send(sendbytes);

        }

        protected void ReceiveEventArgsOnCompleted(object sender, SocketAsyncEventArgs socketAsyncEventArgs)
        {
            ProcessReceive(socketAsyncEventArgs);
        }
        protected string ReadCommands()
        {
            try
            {
                var items = Buffer.ReadToCommands();
                return items;
            }
            catch (Exception exp)
            {
                Logger.ErrorFormat("读取信号发生异常，原因：{0}", exp, exp);
            }
            return string.Empty;
        }
        protected void ProcessReceive(SocketAsyncEventArgs receiveEventArgs)
        {
            try
            {
                if (receiveEventArgs.BytesTransferred > 0 && receiveEventArgs.SocketError == SocketError.Success)
                {
                    var body = Encoding.Default.GetString(receiveEventArgs.Buffer, receiveEventArgs.Offset, receiveEventArgs.BytesTransferred);
                    //Buffer.AddMessage(body);
                    Buffer.SetMessage(body);
                    Logger.DebugFormat("信号：{0},{1}", receiveEventArgs.RemoteEndPoint, body);
                }
                else
                {
                    Logger.WarnFormat("读取信号发生未知错误，信号读取被终止");
                }
            }
            catch (Exception exp)
            {
                Logger.ErrorFormat("接受信号发生异常，原因：{0}", exp, exp);
            }
            finally
            {
                StartReceive(receiveEventArgs);
            }
        }

        protected virtual void StartReceive(SocketAsyncEventArgs receiveEventArgs)
        {
            try
            {
                Socket socket = (Socket)receiveEventArgs.UserToken;
                bool willRaiseEvent = socket.ReceiveFromAsync(receiveEventArgs);
                if (!willRaiseEvent)
                {
                    ProcessReceive(receiveEventArgs);
                }
            }
            catch (Exception exp)
            {
                Logger.ErrorFormat("接受信号发生异常，原因：{0}", exp, exp);
            }
        }

        protected virtual Task<Socket> InitSocketAsync()
        {
            var socket = CreateSocket();
            socket.SendTimeout = 2000;
            socket.ReceiveTimeout = 2000;

            return socket.ConnectExAsync(RemoteEndpoint.Address, RemoteEndpoint.Port).ContinueWith((task) =>
            {
                if (task.Exception != null)
                {
                    Logger.ErrorFormat("连接：{0}发生异常，原因：{1}", RemoteEndpoint, task.Exception);
                    throw task.Exception;
                }
                return socket;
            });
        }

        protected abstract Socket CreateSocket();

        protected class MessageBuffers
        {
            public ILog Logger { get; set; }
            protected AutoResetEvent Event { get; private set; }

            public StringBuilder Content { get; private set; }

            public string ReceiveMessage { get; set; }

            public MessageBuffers()
            {
                Content = new StringBuilder(4096);
                Event = new AutoResetEvent(false);
                Logger = LogManager.GetLogger<MessageBuffers>();
            }

            public void AddMessage(string message)
            {
                try
                {
                    if (message == null)
                        return;

                    Event.Reset();
                    //如果信号起始是$,或者启用新行，或者之前无信号
                    lock (Content)
                    {
                        //不要追加文本
                        ReceiveMessage = message;
                    }
                    Event.Set();
                }
                catch (Exception exp)
                {
                    Logger.ErrorFormat("信号处理发生异常：{0}", exp);
                }
            }

            public void SetMessage(string message)
            {
                try
                {
                    if (message == null)
                        return;

                    Event.Reset();

                    //不要追加文本
                    ReceiveMessage = message;

                    Event.Set();
                }
                catch (Exception exp)
                {
                    Logger.ErrorFormat("信号处理发生异常：{0}", exp);
                }
            }

            public string ReadToCommands()
            {
                var result = Event.WaitOne(TimeSpan.FromSeconds(2));
                if (!result || ReceiveMessage.Length == 0)
                {
                    Logger.DebugFormat("读取信号超时");
                    return string.Empty;
                }


                return ReceiveMessage;

            }

            private static int IndexOfCommand(string message, string command)
            {
                var startIndex = message.LastIndexOf(command, StringComparison.Ordinal);
                if (startIndex == -1)
                    return -1;

                var endIndex = message.IndexOf(Environment.NewLine, startIndex, StringComparison.Ordinal);
                if (endIndex == -1)
                    return -1;

                return endIndex;
            }

            #region IEnumerable<string>
            public IEnumerator<string> GetEnumerator()
            {
                var message = Content.ToString();
                var items = message.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var count = message.EndsWith(Environment.NewLine) ? items.Length : items.Length - 1;
                return items.Take(count).GetEnumerator();
            }

         
            #endregion
        }
    }
}
