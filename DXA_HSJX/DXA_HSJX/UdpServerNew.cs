using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Model;
using Newtonsoft.Json;

namespace DXA_HSJX
{

    /// <summary>
    /// Udp Server 类
    /// </summary>
    //public class UdpServerNew
    //{
    //    private string ServerIp { get; set; }
    //    private int ServerPort { get; set; }


    //    protected IMessenger Messenger { get; private set; }

    //    private ILog Logger { get; set; }

    //    IPEndPoint remoteIpep;
    //    protected Socket Socket { get; set; }
    //    public UdpServerNew()
    //    {
    //        //服务端永远以50000端口 进行监听
    //        this.ServerIp = GetLocalIP();
    //        this.ServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
    //        //服务器端Ip和服务器端端口
    //        this.Messenger = Resolve<IMessenger>();
    //        Logger = LogManager.GetLogger(GetType());

    //        //初始化
    //        remoteIpep = new IPEndPoint(IPAddress.Any, ServerPort);
    //    }

    //    public static string GetLocalIP()
    //    {
    //            string HostName = Dns.GetHostName(); //得到主机名
    //            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
    //            for (int i = 0; i < IpEntry.AddressList.Length; i++)
    //            {
    //                //从IP地址列表中筛选出IPv4类型的IP地址
    //                //AddressFamily.InterNetwork表示此IP为IPv4,
    //                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
    //                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
    //                {
    //                    return IpEntry.AddressList[i].ToString();
    //                }
    //            }
    //            return "";
        
           
    //    }
    //    protected TService Resolve<TService>()
    //    {
    //        return ServiceLocator.Current.GetInstance<TService>();
    //    }


    //    public  Socket CreateSocket()
    //    {
    //        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    //        socket.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, true);
    //        return socket;
    //    }
    //    protected  SocketAsyncEventArgs CreateSocketArgs()
    //    {
    //        var receiveEventArgs = new SocketAsyncEventArgs();
    //        receiveEventArgs.UserToken = Socket;
    //        receiveEventArgs.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
    //        receiveEventArgs.AcceptSocket = Socket;
    //        receiveEventArgs.SetBuffer(new byte[1024], 0, 1024);
    //        receiveEventArgs.Completed += ReceiveEventArgsOnCompleted;
    //        return receiveEventArgs;
    //    }
    //    protected void ReceiveEventArgsOnCompleted(object sender, SocketAsyncEventArgs socketAsyncEventArgs)
    //    {
    //        ProcessReceive(socketAsyncEventArgs);
    //    }
    //    protected void ProcessReceive(SocketAsyncEventArgs receiveEventArgs)
    //    {
    //        try
    //        {
    //            if (receiveEventArgs.BytesTransferred > 0 && receiveEventArgs.SocketError == SocketError.Success)
    //            {
    //                var body = Encoding.Default.GetString(receiveEventArgs.Buffer, receiveEventArgs.Offset, receiveEventArgs.BytesTransferred);
                
    //                Logger.DebugFormat("信号：{0},{1}", receiveEventArgs.RemoteEndPoint, body);
    //            }
    //            else
    //            {
    //                Logger.WarnFormat("读取信号发生未知错误，信号读取被终止");
    //            }
    //        }
    //        catch (Exception exp)
    //        {
    //            Logger.ErrorFormat("接受信号发生异常，原因：{0}", exp, exp);
    //        }
    //        finally
    //        {
    //            StartReceive(receiveEventArgs);
    //        }
    //    }
    //    protected virtual void StartReceive(SocketAsyncEventArgs receiveEventArgs)
    //    {
    //        try
    //        {
    //            Socket socket = (Socket)receiveEventArgs.UserToken;
    //            bool willRaiseEvent = socket.ReceiveFromAsync(receiveEventArgs);
    //            if (!willRaiseEvent)
    //            {
    //                ProcessReceive(receiveEventArgs);
    //            }
    //        }
    //        catch (Exception exp)
    //        {
    //            Logger.ErrorFormat("接受信号发生异常，原因：{0}", exp, exp);
    //        }
    //    }
    //    protected virtual Task<Socket> InitSocketAsync()
    //    {
    //        var socket = CreateSocket();
    //        socket.SendTimeout = 2000;
    //        socket.ReceiveTimeout = 2000;

    //        return socket.ConnectExAsync(RemoteEndpoint.Address, RemoteEndpoint.Port).ContinueWith((task) =>
    //        {
    //            if (task.Exception != null)
    //            {
    //                Logger.ErrorFormat("连接：{0}发生异常，原因：{1}", RemoteEndpoint, task.Exception);
    //                throw task.Exception;
    //            }
    //            return socket;
    //        });
    //    }





    //}

 

}
