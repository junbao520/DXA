using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BrokenRuleInfo
    {
        public DateTime BreakTime { get; internal set; }
        public string ExamItemCode { get; internal set; }
        public string ExamItemName { get; internal set; }
        public string RuleName { get; set; }
        public int DeductedScores { get; set; }
    }
}
