using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DeductionRule
    {
        [Key]
        public int Id { get; set; }
        public string RuleCode { get; set; }
        public string SubRuleCode { get; set; }

        public string RuleName { get; set; }

        public int ExamItemId { get; set; }

        public int DeductedScores { get; set; }

        public byte IsRequired { get; set; }

         public string DeductedReason { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ExamItemName { get; set; }

    }
}
