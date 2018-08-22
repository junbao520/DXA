using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BorkenRuleMessage : MessageBase
    {
        public BorkenRuleMessage(DeductionRule rule,int position)
        {
            this.DeductionRule = rule;
            this.Position = position;
        }
        public DeductionRule DeductionRule { get; set; }
        public int Position { get; set; }
    }
}
