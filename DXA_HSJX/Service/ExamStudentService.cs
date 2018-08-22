using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.Linq.SqlClient;
using System.Data.Entity;

namespace Service
{
    public class ExamStudentService:IExamStudentService
    {

        private EFRepositoryBase<ExamStudent> efRepository;

        public ExamStudentService()
        {
            efRepository = new EFRepositoryBase<ExamStudent>();
        }

        public void ValidAddStudent(string IdCard)
        {
            //todo:不清楚加时间查询为何不行 
            var result = efRepository.LoadEntities
                (s => s.IdCard == IdCard && DbFunctions.DiffDays(s.CreateTime, DateTime.Now) == 0);

            if (result.Count() > 0)
            {
                throw new MyException("考生管理", "考生已经添加请勿重复添加");
            }
        }


        public void AddStudent(string IdCard, string Name, string phone, string Address, byte[] Image)
        {

            ValidAddStudent(IdCard);
            ExamStudent student = new ExamStudent();
            student.IdCard = IdCard;
            student.Name = Name;
            student.Phone = phone;
            student.Address = Address;
            student.IDCardImage = Image;
            student.IsDelete = false;
            student.CreateTime = DateTime.Now;
            student.ModifiedTime = DateTime.Now;
            efRepository.AddEntity(student);
        }

        public ExamStudent GetStudentInfo(string IdCard)
        {

            var result = efRepository.LoadEntitiy(s => DbFunctions.DiffDays(s.CreateTime, DateTime.Now) == 0);

            return result;
        }
    }
}
