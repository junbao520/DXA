using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 考试抓拍表 
    /// </summary>
    public class ExamCapture:BaseTable
    {

        public int ExamRecordId { get; set; }

        public int ExamItemItemCode { get; set; }
   

        /// <summary>
        /// 抓拍图片
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// 考试记录
        /// </summary>
        public virtual ExamRecord ExamRecord { get; set; }

        /// <summary>
        /// 考试项目
        /// </summary>
        public virtual ExamItem ExamItem { get; set; }





    }
}
