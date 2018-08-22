using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 登录日志表
    /// </summary>
    public class LoginLog:BaseTable
    {
        public string UserName { get; set; }
        public DateTime LoginTime { get; set; }

        public bool IsSuccess { get; set; }
    }
}
