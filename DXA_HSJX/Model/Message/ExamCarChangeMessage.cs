using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExamCarChangeMessage : MessageBase
    {
        public ExamCarChangeMessage(ExamCar ExamCar)
        {
            this.ExamCar = ExamCar;
        }
        public ExamCar ExamCar { get; set; }
    }
}
