using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Text;
using Common.Logging;
using Common;

namespace DXA_HSJX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {


                //加载Log4Net
                System.IO.FileInfo file = new System.IO.FileInfo(string.Format(@"{0}\log4netdebug.config", AppDomain.CurrentDomain.BaseDirectory));
                log4net.Config.XmlConfigurator.ConfigureAndWatch(file);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                #region 应用程序入口
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

                //初始化Ioc 
                new Bootstrapper().Initialize();

                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {

                //判断是Debug还是Relase
                //可以考虑使用预编译指令判断
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            #endregion

        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            if (e.Exception is MyException)
            {
                var exception = (MyException)e.Exception;
                MessageBox.Show(exception.Message, exception.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string str = GetExceptionMsg(e.Exception, e.ToString());
            //把日志写入Log
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            //把日志写入Log
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }
        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
           
            ILog logger = LogManager.GetLogger("Program.cs");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            //写入日志
            logger.Error(sb);
            return sb.ToString();
        }


    }
}
