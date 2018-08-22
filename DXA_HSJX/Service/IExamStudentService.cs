using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// 考生管理接口
    /// </summary>
    public interface IExamStudentService
    {
       void AddStudent(string IdCard, string Name, string phone, string Address, byte[] Image);
        ExamStudent GetStudentInfo(string IdCard);
    }
}
