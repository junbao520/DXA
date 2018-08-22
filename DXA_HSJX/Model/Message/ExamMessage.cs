using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 考试消息类，这个类将用来做客户端和服务端进行消息发送接收 会把这个类进行序列化成为json对象进行传输
    /// 还需要编写Udp通信类
    /// </summary>
    public class ExamMessage
    {
        /// <summary>
        /// 命令类型
        /// </summary>
      public  CmdTypeEnum CmdType { get; set; }

      /// <summary>
      /// 考试GUID 表明是同一次考试
      /// </summary>
      public string GUID { get; set; }

      /// <summary>
      /// 考试线路
      /// </summary>
      public string ExamLine { get; set; }

     /// <summary>
     /// 考试分数
     /// </summary>
      public int Score { get; set; }

        /// <summary>
        /// 考试项目 分为开始和结束
        /// </summary>
      public ExamItemEnum ExamItem { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
      public  DateTime SendTime { get; set; }
    
        /// <summary>
        /// 抓拍图片
        /// </summary>
      public byte[] CapturImage { get; set; }

      /// <summary>
      /// 是否初考
      /// </summary>
      public bool IsPreliminaryExam { get; set; }

        /// <summary>
        /// 考试学生
        /// </summary>
        public ExamStudent ExamStudent { get; set; }

        /// <summary>
        /// 车载信号
        /// </summary>
        public  CarSignalInfo CarSignalInfo { get; set; }

        /// <summary>
        /// 扣分规则
        /// </summary>
       public ExamMessageDeductionRule DeductionRule { get; set; }



    }


    public class ExamMessageDeductionRule
    {
        public string RuleCode { get; set; }
        public string SubRuleCode { get; set; }
        public string RuleName { get; set; }
        public int ExamItemId { get; set; }
        public int DeductedScores { get; set; }
        public string DeductedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ExamItemName { get; set; }
    }

    public enum CmdTypeEnum {
        /// <summary>
        /// 开始考试
        /// </summary>
        StartExam,
        /// <summary>
        /// 结束考试
        /// </summary>
        EndExam,
        /// <summary>
        /// 扣分
        /// </summary>
        BreakeRule,
        /// <summary>
        /// 抓拍
        /// </summary>
        Capture,
        /// <summary>
        /// 进入考试项目
        /// </summary>
        EnterExamItem,
        /// <summary>
        /// 离开考试项目
        /// </summary>
        LeaveExamItem,
        /// <summary>
        /// 发送考生信息
        /// </summary>
        SendExamStudentInfo,
        
        /// <summary>
        /// 发送车辆信号
        /// </summary>
        SendCarSensor,
       
    }

    public enum ExamItemEnum
    {
        CommonExamItem=10100,
        /// <summary>
        /// 倒车入库
        /// </summary>
        ReverseParking=20100,
        ReverseParkingEnd=60005,
        /// <summary>
        /// 侧方停车
        /// </summary>
        ParallelParking= 20400,
        ParallelParkingEnd= 60400,
        /// <summary>
        /// 坡道定点停车和起步
        /// </summary>
        SlopeWayParkingAndStarting= 20300,
        SlopeWayParkingAndStartingEnd= 60300,
        /// <summary>
        /// 曲线行驶
        /// </summary>
        QuarterTurning= 20600,
        QuarterTurningEnd= 60600,
        /// <summary>
        ///直角转弯
        /// </summary>
        CurveDriving= 20700,
        CurveDrivingEnd= 60100,

    }


}
