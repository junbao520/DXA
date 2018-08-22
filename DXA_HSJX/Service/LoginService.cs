using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;

namespace Service
{
    /// <summary>
    /// 登录服务类
    /// </summary>
    public class LoginService: ILoginService
    {

        private EFRepositoryBase<User> efRepository;
        private EFRepositoryBase<LoginLog> efLoginLogRepository;
        public LoginService()
        {
            efRepository = new EFRepositoryBase<User>();
            efLoginLogRepository = new EFRepositoryBase<LoginLog>();
        }
        private string GetMd5(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string a = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str)));
            a = a.Replace("-", "");
            return a;
        }
        public bool userLogin(string userName, string pwd)
        {
            var user = Login(userName, pwd);
            LoginLog log = new LoginLog();
            log.UserName = userName; 
            log.LoginTime = DateTime.Now;
            log.IsSuccess = user!=null;
            log.CreateTime = DateTime.Now;
            log.ModifiedTime = DateTime.Now;
            efLoginLogRepository.AddEntity(log);

            return user != null;

        }
        private User Login(string userName, string pwd)
        {
            pwd = GetMd5(pwd);
            var user = efRepository.LoadEntitiy(s => s.UserName == userName && s.Password == pwd && s.IsDelete == false);

            return user;
        }
        public bool ModifiedPwd(string userName, string pwd)
        {
            var user = Login(userName, pwd);
            if (user != null)
            {
                user.Password = GetMd5(pwd);
                efRepository.UpdateEntity(user);
                return true;
            }
            return false;
        }
    }
}
