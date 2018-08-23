using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 考试学生表
    /// </summary>
    public class ExamStudent:BaseTable
    {
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string Address { get; set; } 
        public int Age { get; set; }

        public char Sex { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 身份证头像
        /// </summary>
        public byte[] IDCardImage { get; set; }

        /// <summary>
        /// 考试车型 
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 学生所在的考场ID 也就是车牌 这个作为备用 如果要做分车
        /// </summary>
        public string CarId { get; set; }
    }
}
