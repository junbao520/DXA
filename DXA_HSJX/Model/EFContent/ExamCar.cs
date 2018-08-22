using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 考试车辆表
    /// </summary>
    public class ExamCar:BaseTable
    {

        public int?  ExamStudentId { get; set; }
        //车牌
        public string LicensePlate { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public int Position { get; set; }
        public virtual ExamStudent ExamStudent { get; set; }
    }
}
