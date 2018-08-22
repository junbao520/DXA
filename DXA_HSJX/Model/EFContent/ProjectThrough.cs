using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ProjectThrough : BaseTable
    {
      

        public int ExamRecordId { get; set; }
        public int ExamItemItemCode { get; set; }
        public DateTime? EnterTime {get;set;}

        public DateTime? LeaveTime { get; set; }


        public virtual ExamItem ExamItem { get; set; }
        public virtual ExamRecord ExamRecord { get; set; }



    }
}
