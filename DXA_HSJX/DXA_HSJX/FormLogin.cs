using Common;
using Common.Logging;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Model;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DXA_HSJX
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        ILog Logger;
        IMessenger Messenger;
        ILoginService LoginService;

        public FormLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;


        }
        protected TService Resolve<TService>()
        {
            return ServiceLocator.Current.GetInstance<TService>();
        }
        //不需要这么麻烦 加一个判断初始化就行了！ 
        //如果数据库里面有这个数据库
        //
        private void FormLogin_Load(object sender, EventArgs e)
        {
            Logger = LogManager.GetLogger(GetType());

            LoginService = ServiceLocator.Current.GetInstance<LoginService>();

            var msg = new ExamMessage();
            var result = JsonConvert.SerializeObject(msg);
            new UdpServer().Send(result, "192.168.1.6", 60000);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string Pwd = txtPwd.Text.Trim();
            if (LoginService.userLogin(UserName,Pwd))
            {
                FormMain form= new FormMain();
                form.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或者密码错误");
            }
        }
}
}
