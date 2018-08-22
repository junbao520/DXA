using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    /// <summary>
    /// 自定义异常处理类
    /// </summary>
    public class MyException:Exception
    {

        public MyException(string title,string msg):base(msg)
        {
            this.Title = title;
        }
        public string Title { get; set; }
    }
}
