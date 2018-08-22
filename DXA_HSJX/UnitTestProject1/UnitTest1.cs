using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Service;
using Model;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {

            ILoginService service = new LoginService();
            var result = service.userLogin("admin", "123456");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifiedPwd()
        {
            ILoginService service = new LoginService();
            var result = service.ModifiedPwd("admin", "123456");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddSutdnet()
        {
            ExamStudentService a = new ExamStudentService();
            a.AddStudent("55", "22", "123", "234", null);
        }
        [TestMethod]
        public void TestGetStudent()
        {
            ExamStudentService a = new ExamStudentService();

            a.GetStudentInfo("123");
        }

        [TestMethod]
        public void ExamRecordTest()
        {
            //首先开始考试
            ExamMessage msg = new ExamMessage();
            msg.GUID = "dsds";
            var car = new EFRepositoryBase<ExamCar>();
            var examRecord = new EFRepositoryBase<ExamRecord>();
            var examCapture = new EFRepositoryBase<ExamCapture>();
            var breakeRule = new EFRepositoryBase<ExamBreakeRuleRecord>();
            var examItem = new EFRepositoryBase<ExamItem>();
            var project = new EFRepositoryBase<ProjectThrough>();
            var examStudent = new EFRepositoryBase<ExamStudent>();

            var service = new ExamService(car, examRecord, examCapture, breakeRule, examItem, project, examStudent);
            var message = new ExamMessage();
            message.CmdType = CmdTypeEnum.StartExam;
            message.SendTime = DateTime.Now;
            message.ExamStudent = new ExamStudent();
            message.ExamStudent.IdCard = "500227199111222222";
            message.ExamStudent.Name = "张三";
            message.IsPreliminaryExam = true;
            message.ExamLine = "测试一号线";
            message.GUID = System.Guid.NewGuid().ToString("N");
           // message.GUID = "70760794d8864c6d9d374fc6dca767dd";
            message.Score = 100;

            //开始考试
            service.AddExamInfo(message);
     

            //通过项目 侧方停车
            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.ParallelParking;
            message.SendTime = DateTime.Now;
            service.AddExamInfo(message);

            //抓拍
            message.CmdType = CmdTypeEnum.Capture;
            message.ExamItem= ExamItemEnum.ParallelParking;
            message.CapturImage = System.IO.File.ReadAllBytes("capture.jpg");
            message.SendTime = DateTime.Now;
            service.AddExamInfo(message);


            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.ParallelParkingEnd;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.BreakeRule;
            message.SendTime = DateTime.Now;
            message.Score = 0;
            message.DeductionRule = new ExamMessageDeductionRule();
            message.DeductionRule.DeductedScores = 100;
            message.DeductionRule.DeductedReason = "不按考试路线行驶";
            message.DeductionRule.RuleCode = "10101";
            message.DeductionRule.ExamItemId = (int)ExamItemEnum.ParallelParking;
            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.CurveDriving;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.CurveDrivingEnd;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.Capture;
            message.ExamItem = ExamItemEnum.CurveDrivingEnd;
            message.CapturImage = System.IO.File.ReadAllBytes("capture.jpg");
            service.AddExamInfo(message);


            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.QuarterTurning;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.QuarterTurningEnd;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.ReverseParking;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.ReverseParkingEnd;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.SlopeWayParkingAndStarting;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EnterExamItem;
            message.ExamItem = ExamItemEnum.SlopeWayParkingAndStartingEnd;
            message.SendTime = DateTime.Now;

            service.AddExamInfo(message);

            message.CmdType = CmdTypeEnum.EndExam;
            message.SendTime = DateTime.Now;
            service.AddExamInfo(message);
        }

        [TestMethod]
        public void TestVaildMessage()
        {
            ExamMessage msg = new ExamMessage();
            msg.GUID = "dsds";
            var car = new EFRepositoryBase<ExamCar>();
            var examRecord = new EFRepositoryBase<ExamRecord>();
            var examCapture = new EFRepositoryBase<ExamCapture>();
            var breakeRule = new EFRepositoryBase<ExamBreakeRuleRecord>();
            var examItem = new EFRepositoryBase<ExamItem>();
            var project = new EFRepositoryBase<ProjectThrough>();
            var examStudent = new EFRepositoryBase<ExamStudent>();

            var examService = new ExamService(car, examRecord, examCapture, breakeRule, examItem, project, examStudent);
            examService.AddExamInfo(msg);
            
        }
    }
}
