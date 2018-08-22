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
    public class UdpServer
    {
        private string ServerIp { get; set; }
        private int ServerPort { get; set; }

        private UdpClient udpcSend;

        protected IMessenger Messenger { get; private set; }

        private ILog Logger { get; set; }

        private UdpClient udpcRecv;
        System.Threading.Timer timer;
         public UdpServer()
        {
            //服务端永远以50000端口 进行监听
            this.ServerIp = GetLocalIP();
            this.ServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            //服务器端Ip和服务器端端口
            this.Messenger = Resolve<IMessenger>();
            Logger = LogManager.GetLogger(GetType());
        }

        public static string GetLocalIP()
        {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
        
           
        }
        protected TService Resolve<TService>()
        {
            return ServiceLocator.Current.GetInstance<TService>();
        }
        /// <summary>
        /// 发送数据 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="Ip"></param>
        /// <param name="Port"></param>
        public void Send(string msg, string Ip, int Port)
        {
            //本机IP
          //  IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort); // 本机IP，指定的端口号
            if (udpcSend==null)
            {
                udpcSend = new UdpClient();
            }
           
            Task.Run(() =>
            {
                byte[] sendbytes = Encoding.Default.GetBytes(msg);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(Ip), Port); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
            });
        }

        public void StartReceiveMsg()
        {
            if (udpcRecv == null)
            {
                IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort); // 本机IP和监听端口号
                udpcRecv = new UdpClient(localIpep);
            }
            
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(ReceiveMessage), null, 100, 100);
        }
        public void StopReceiveMsg() {
            //停止计数器
            timer.Change(-1, 0);
        }
        
        private void ReceiveMessage(object a)
        {
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);
                string message = Encoding.Default.GetString(bytRecv, 0, bytRecv.Length);

                ExamMessage examMessage = JsonConvert.DeserializeObject<ExamMessage>(message);
                //收到的消息再通过消息模式转发出来
                Messenger.Send<ExamMessage>(examMessage);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }



    }

 

}
