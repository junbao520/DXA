using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 考试扣分
    /// </summary>
    public class ExamBreakeRuleRecord:BaseTable
    {

        public int ExamRecordId { get; set; }

        public int ExamItemItemCode { get; set; }
       
        public string RuleCode { get; set; }
        public string SubRuleCode { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 扣分内容
        /// </summary>
        public string DeductedReason { get; set; }

        public virtual ExamRecord ExamRecord { get; set; }
        /// <summary>
        /// 考试项目
        /// </summary>
        public virtual ExamItem ExamItem { get; set; }
    }
}
