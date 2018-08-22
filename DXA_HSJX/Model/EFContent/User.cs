using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User:BaseTable
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
