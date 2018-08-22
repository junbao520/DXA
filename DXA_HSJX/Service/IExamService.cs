using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IExamService
    {

        string GetLicensePlateByIdCard(string IdCard);
        void AddExamInfo(ExamMessage message);

        ExamCar GetExamCar(string IdCard);
        PrintScoreModel GetPrintScoreModel(string IDCard);
    }
}
