using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 考试记录表
    /// </summary>
    public class ExamRecord : BaseTable
    {


        public int ExamStudentId { get; set; }

        /// <summary>
        /// 每一次考试的一个位移编码这个由客户端生成每次都会发送过来
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        ///结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        public int Score { get; set; }

        /// <summary>
        /// 是否初考 true 是 false 不是
        /// </summary>
        public bool IsPreliminaryExam { get; set; }
        /// <summary>
        /// 考试线路
        /// </summary>
        public string ExamLine { get; set; }

        /// <summary>
        /// 考试车牌
        /// </summary>
        public string LicensePlate { get; set; }

        public virtual ExamStudent ExamStudent { get; set; }

        /// <summary>
        /// 考试扣分记录
        /// </summary>
        public virtual List<ExamBreakeRuleRecord> ExamBreakeRuleRecords {get;set;}



    }
}
