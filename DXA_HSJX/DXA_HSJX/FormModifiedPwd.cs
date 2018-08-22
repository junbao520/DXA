using Microsoft.Practices.ServiceLocation;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXA_HSJX
{
    public partial class FormModifiedPwd : Form
    {
        ILoginService LoginService;
        public FormModifiedPwd()
        {
            InitializeComponent();
        }

        private void btnModified_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text.Trim()!=txtConfirmPwd.Text.Trim())
            {
                MessageBox.Show("新密码和确认密码不一致", "密码修改");
            }
         var result=   LoginService.ModifiedPwd(txtUserName.Text.Trim(), txtConfirmPwd.Text.Trim());
            if (result)
            {
                MessageBox.Show("修改成功", "密码修改");
            }
            else
            {
                MessageBox.Show("失败", "密码修改");
            }
        }

        private void FormModifiedPwd_Load(object sender, EventArgs e)
        {
            LoginService = ServiceLocator.Current.GetInstance<LoginService>();
            
        }
    }
}
