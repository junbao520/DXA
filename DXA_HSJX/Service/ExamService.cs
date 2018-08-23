using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Newtonsoft.Json;

namespace Service
{
    public class ExamService : IExamService
    {
        IEFRepository<ExamCar> examCarRepository;
        IEFRepository<ExamRecord> examRecordRepository;
        IEFRepository<ExamCapture> examCaptureRepository;
        IEFRepository<ExamBreakeRuleRecord> examBreakeRuleRecordRepository;
        IEFRepository<ExamItem> examItemRepository;
        IEFRepository<ProjectThrough> projectThroughRepository;
        IEFRepository<ExamStudent> examStudentRepository;
        ILog Logger;


        public ExamService(IEFRepository<ExamCar> IExamCarRepository,
            IEFRepository<ExamRecord> IExamRecordRepository,
            IEFRepository<ExamCapture> IExamCaptureRepository,
            IEFRepository<ExamBreakeRuleRecord> IExamBreakeRuleRecordRepository,
            IEFRepository<ExamItem> IExamItemRepository,
            IEFRepository<ProjectThrough> IProjectThroughRepository,
            IEFRepository<ExamStudent> IExamStudentRepository
            )
        {
            examCarRepository = IExamCarRepository;
            examRecordRepository = IExamRecordRepository;
            examCaptureRepository = IExamCaptureRepository;
            examBreakeRuleRecordRepository = IExamBreakeRuleRecordRepository;
            examItemRepository = IExamItemRepository;
            projectThroughRepository = IProjectThroughRepository;
            examStudentRepository = IExamStudentRepository;
            Logger = LogManager.GetLogger(GetType());
        }


        
        /// <summary>
        /// 验证消息是否合法
        /// </summary>
        /// <param name="message"></param>
        public bool VaildMessage(ExamMessage message)
        {
            if (message.CmdType != CmdTypeEnum.StartExam)
            {
                //去数据库中查询是否有该记录
                var entity = examRecordRepository.LoadEntitiy(s => s.GUID == message.GUID);
                if (entity == null)
                {
                    var msg = JsonConvert.SerializeObject(message);
                    Logger.Error("验证消息不合法:"+msg);
                    return false;
                }
                return true;
            }
            return true;
        }
        /// <summary>
        /// todo:延迟加载不行 这个还需要研究
        /// 添加考试信息 考试所有信息
        /// </summary>
        /// <param name="message"></param>
        public void AddExamInfo(ExamMessage message)
        {
            try
            {
                var result = VaildMessage(message);
                if (result == false)
                {
                    return;
                }
                switch (message.CmdType)
                {
                    case CmdTypeEnum.StartExam:
                        StartExam(message);
                        break;
                    case CmdTypeEnum.EndExam:
                        EndExam(message);
                        break;
                    case CmdTypeEnum.BreakeRule:
                        BreakeRule(message);
                        break;
                    case CmdTypeEnum.Capture:
                        Capture(message);
                        break;
                    case CmdTypeEnum.EnterExamItem:
                        //进入项目 同时抓怕图片
                        Capture(message);
                        EnterExam(message);
                        break;
                    case CmdTypeEnum.LeaveExamItem:
                        LeaveExam(message);
                        break;
                    case CmdTypeEnum.SendExamStudentInfo:
                        break;
                    case CmdTypeEnum.SendCarSensor:
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Logger.Error("ErrorMessage" + JsonConvert.SerializeObject(message));
            }

           

            //Thread.Sleep(1000);
        }

        public PrintScoreModel GetPrintScoreModel(string IDCard)
        {
            //首先去查询几天的考试记录有没有该考生

            PrintScoreModel model = new PrintScoreModel();

            var examRecords = examRecordRepository.LoadEntities(s => s.ExamStudent.IdCard == IDCard & DbFunctions.DiffDays(s.CreateTime, DateTime.Now) == 0);

            if (examRecords.Count() <= 0)
            {
                throw new MyException("打印", "今天无该考生信息");
            }

            List<ExamRecord> lstExamRecords = new List<ExamRecord>();

            //todo:bug
            var result = examRecords.Where(s => s.IsPreliminaryExam == true).OrderByDescending(s => s.CreateTime);
            var FirstExam = result == null ? null : result.FirstOrDefault();
            if (FirstExam == null)
            {
                throw new MyException("打印", "该考生无初考信息");
            }
            FirstExam.ExamStudent = GetExamStudent(FirstExam.ExamStudentId);
            //如果考生为空则重新获取
            result = examRecords.Where(s => s.IsPreliminaryExam == false&&s.BeginTime>FirstExam.BeginTime).OrderByDescending(s => s.CreateTime);
            var SecondExam = result == null ? null : result.FirstOrDefault();

            model.Name = FirstExam.ExamStudent.Name;
            model.IDCard = FirstExam.ExamStudent.IdCard;
            model.ExamDate = FirstExam.BeginTime.Value.ToString("yyyy-MM-dd");
            //这个从配置文件读取
            model.Title = "驾驶技能模拟考试成绩单";
            model.IDCardPath = GetImagePath("IDCard", FirstExam.ExamStudent.IDCardImage);
            model.CarType = "C1";
            model.BusinessType = "初次申领";
            model.FirstExam = GetExamMode(FirstExam);
            if (SecondExam != null)
            {
                SecondExam.ExamStudent = FirstExam.ExamStudent;
                model.SecondExam = GetExamMode(SecondExam);
            }
            return model;
        }

        public ExamMode GetExamMode(ExamRecord record)
        {
            var Exam = new ExamMode();
            Exam.ExamTime = record.BeginTime.Value.ToString("HH:mm:ss") + "-" + record.EndTime.Value.ToString("HH:mm:ss");

            //获取考试扣分项
            var breakeRules = examBreakeRuleRecordRepository.LoadEntities(s => s.ExamRecordId == record.Id);

            var breakeRulesStr = string.Join(",", breakeRules.Select(s => s.DeductedReason));
            Exam.Score = record.Score;
            Exam.DedictionRules = breakeRulesStr;
            var Captures = examCaptureRepository.LoadEntities(s => s.ExamRecordId == record.Id);
            for (int i = 0; i < Captures.Count() && i < 3; i++)
            {
                if (i == 0)
                {
                    Exam.CaptureImageFirstPath = GetImagePath("FirstCaptureImage", Captures[i].Image);
                }
                else if (i == 1)
                {
                    Exam.CaptureImageSecondPath = GetImagePath("SecondCaptureImage", Captures[i].Image);
                }
                else if (i == 2)
                {
                    Exam.CaptureImageThirdPath = GetImagePath("ThirdCaptureImage", Captures[i].Image);
                }
            }

            return Exam;
            //简单逻辑 我只需要前面三张照片

        }

        public ExamStudent GetExamStudent(int Id)
        {
            var entity = examStudentRepository.LoadEntitiy(s => s.Id == Id);
            return entity;
        }

        public string GetImagePath(string Type, byte[] Image)
        {
            if (Image == null)
            {
                return string.Empty;
            }
            string path = System.IO.Directory.GetCurrentDirectory() + "\\" + Type + ".jpg";
            System.IO.File.WriteAllBytes(path, Image);
            return path;
        }




        public string GetLicensePlateByIdCard(string IdCard)
        {
            var entity = examCarRepository.LoadEntitiy(s => s.ExamStudent.IdCard == IdCard);
            return entity.LicensePlate;
        }
        public ExamCar GetExamCar(string IdCard)
        {
            var entity = examCarRepository.LoadEntitiy(s => s.ExamStudent.IdCard == IdCard);
            return entity;
        }



        public ExamRecord GetExamRecord(string GUID)
        {
            var entity = examRecordRepository.LoadEntitiy(s => s.GUID == GUID);
            return entity;
        }

        public ExamItem GetExamItem(ExamItemEnum examItem)
        {
            var entity = examItemRepository.LoadEntitiy(s => s.ItemCode == (int)examItem);
            return entity;
        }
        //&& DbFunctions.DiffDays(s.CreateTime, DateTime.Now) == 0
        public ExamStudent GetExamStudent(string IdCard)
        {
            var result = examStudentRepository.LoadEntitiy
             (s => s.IdCard == IdCard);
            return result;
        }
        /// <summary>
        /// 开始考试
        /// </summary>
        /// <param name="message"></param>
        public void StartExam(ExamMessage message)
        {
            //创建考试记录 写入开始时间
            //TODO:GUID 
            //怎样获取当天
            ExamRecord record = new ExamRecord();
            record.BeginTime = message.SendTime;
            record.IsPreliminaryExam = message.IsPreliminaryExam;
            //这个去获取
            record.LicensePlate = GetLicensePlateByIdCard(message.ExamStudent.IdCard);
            record.ExamLine = message.ExamLine;

            record.ExamStudentId = GetExamStudent(message.ExamStudent.IdCard).Id;
            record.Score = message.Score;
            record.GUID = message.GUID;
            record.CreateTime = DateTime.Now;
            examRecordRepository.AddEntity(record);
        }

        public ProjectThrough GetProjectThroughs(int ExamRecordId, ExamItemEnum ItemCode)
        {
            var result = projectThroughRepository.LoadEntitiy(s => s.ExamItemItemCode == (int)ItemCode && s.ExamRecordId == ExamRecordId);
            return result;
        }
        public int GetParentItemCode(ExamItemEnum examItem)
        {
            var result = examItemRepository.LoadEntitiy(s => s.ItemCode == (int)examItem);
            return result.ParentItemCode.HasValue ? result.ParentItemCode.Value : 0;
        }

        /// <summary>
        /// 结束考试
        /// </summary>
        /// <param name="message"></param>
        public void EndExam(ExamMessage message)
        {
            var entity = GetExamRecord(message.GUID);
            entity.EndTime = message.SendTime;
            entity.Score = message.Score;
            entity.ModifiedTime = DateTime.Now;
            examRecordRepository.UpdateEntity(entity);
        }

        /// <summary>
        /// 扣分
        /// </summary>
        /// <param name="message"></param>
        public void BreakeRule(ExamMessage message)
        {
            ExamBreakeRuleRecord entity = new ExamBreakeRuleRecord();
            entity.ExamRecordId = GetExamRecord(message.GUID).Id;
            entity.ExamItemItemCode = GetExamItem(message.ExamItem).ItemCode;
            entity.IsDelete = false;
            entity.RuleCode = message.DeductionRule.RuleCode;
            entity.SubRuleCode = message.DeductionRule.SubRuleCode;
            entity.Score = message.DeductionRule.DeductedScores;
            entity.DeductedReason = message.DeductionRule.DeductedReason;
            entity.CreateTime = DateTime.Now;
            examBreakeRuleRecordRepository.AddEntity(entity);

            //扣分了 就应该更新扣分分数
            var examRecordEntity = GetExamRecord(message.GUID);
            examRecordEntity.Score = message.Score;
            examRecordRepository.UpdateEntity(examRecordEntity);


            //扣分了就应该更新数据库显示的分数
            //

        }

        /// <summary>
        /// 抓拍
        /// </summary>
        /// <param name="message"></param>
        public void Capture(ExamMessage message)
        {
            //如果抓怕的图片不为空
            if (message.CapturImage != null)
            {
                ExamCapture entity = new ExamCapture();
                entity.ExamRecordId = GetExamRecord(message.GUID).Id;
                entity.ExamItemItemCode = GetExamItem(message.ExamItem).ItemCode;

                entity.Image = message.CapturImage;
                entity.CreateTime = DateTime.Now;
                examCaptureRepository.AddEntity(entity);
            }

        }



        public void EnterExam(ExamMessage message)
        {


            ProjectThrough entity = new ProjectThrough();
            //这些都需要加上非空判断
            var examRecord = GetExamRecord(message.GUID);
            if (examRecord == null)
            {
                //需要依赖注入ILogger;
                return;
            }
            entity.ExamRecordId = examRecord.Id;
            entity.ExamItemItemCode = GetExamItem(message.ExamItem).ItemCode;
            entity.EnterTime = message.SendTime;
            entity.CreateTime = DateTime.Now;
            projectThroughRepository.AddEntity(entity);


            var parentCode = GetParentItemCode(message.ExamItem);
            if (parentCode > 0)
            {

                entity = GetProjectThroughs(examRecord.Id, (ExamItemEnum)parentCode);
                if (entity == null)
                {
                    return;
                }
                entity.LeaveTime = message.SendTime;
                entity.ModifiedTime = DateTime.Now;
                //更新离开时间
                projectThroughRepository.UpdateEntity(entity);
            }




        }
        public void LeaveExam(ExamMessage message)
        {
            ProjectThrough entity = new ProjectThrough();
            entity.ExamRecordId = GetExamRecord(message.GUID).Id;
            entity.ExamItemItemCode = GetExamItem(message.ExamItem).ItemCode;
            entity.LeaveTime = message.SendTime;
            entity.CreateTime = DateTime.Now;
            projectThroughRepository.AddEntity(entity);
        }

    }
}
