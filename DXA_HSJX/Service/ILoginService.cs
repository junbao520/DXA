using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILoginService
    {
        bool userLogin(string userName, string pwd);
        bool ModifiedPwd(string userName, string pwd);
    }
}
