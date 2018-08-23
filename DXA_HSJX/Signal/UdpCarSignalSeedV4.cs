using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DCommon;
using GalaSoft.MvvmLight.Messaging;
using Model;
using Newtonsoft.Json;

namespace Signal
{
    public class UdpCarSignalSeedV4 : SocketCarSignalSeedV4
    {

        private IMessenger Messenger;
        public UdpCarSignalSeedV4(IMessenger messenger):base(messenger)
        {
            Messenger = messenger;
        }
        public virtual Task StartAsync()
        {
            CancellationSource = new CancellationTokenSource();
            Event = new AutoResetEvent(false);
            return Task.Run(() =>
            {
                Event.Reset();
                while (!CancellationSource.IsCancellationRequested)
                {
                    if (!Connected)
                    {
                        InitAsync().Wait();
                    }

                    StartCore();
                }
                Event.Set();
            }, CancellationSource.Token);
        }
        private string Data = string.Empty;
        protected virtual void StartCore()
        {
            try
            {
                Data = ReadCommands();
                if (string.IsNullOrEmpty(Data))
                {
                    return;
                }
                ExamMessage examMessage = JsonConvert.DeserializeObject<ExamMessage>(Data);
                //收到的消息再通过消息模式转发出来
                Messenger.Send<ExamMessage>(examMessage);
            }
            catch (Exception ex)
            {
                Logger.Error("解析信号错误:" + ex.Message + "信号:" + Data);
            }
           
        }

        private bool _connected = false;
        protected override bool Connected
        {
            get { return _connected; }
        }

        public  void Init()
        {
            var port = 50000;
            RemoteEndpoint = new IPEndPoint(IPAddress.Any, port);
            Logger.DebugFormat("UdpCarSignalSeedV4 - {0};", RemoteEndpoint);
        }

        protected override Socket CreateSocket()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, true);
            return socket;
        }

        protected override SocketAsyncEventArgs CreateSocketArgs()
        {
            var receiveEventArgs = new SocketAsyncEventArgs();
            receiveEventArgs.UserToken = Socket;
            receiveEventArgs.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            receiveEventArgs.AcceptSocket = Socket;
            receiveEventArgs.SetBuffer(new byte[10000], 0, 10000);
            receiveEventArgs.Completed += ReceiveEventArgsOnCompleted;
            return receiveEventArgs;
        }

        protected async override Task<Socket> InitSocketAsync()
        { 
            var socket = CreateSocket();
            socket.SendTimeout = 2000;
            socket.ReceiveTimeout = 2000;
            try
            {
                _connected = true;
                socket.Bind(RemoteEndpoint);
            }
            catch (Exception exp)
            {
                Logger.ErrorFormat("绑定：{0}发生异常，原因：{1}", RemoteEndpoint, exp);
            }
            return socket;
        }

        public static string GetLocalIp()
        {
            string hostname = Dns.GetHostName();//得到本机名   
            //IPHostEntry localhost = Dns.GetHostByName(hostname);//方法已过期，只得到IPv4的地址   
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            foreach (var addr in localhost.AddressList)
            {
                var ip = addr.ToString();
                if (ip.StartsWith("192.168."))
                    return ip;
            }
             
            IPAddress localaddr = localhost.AddressList[0];
            return localaddr.ToString();
        }
    }
}
