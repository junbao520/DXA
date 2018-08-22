using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 打印成绩模板类
    /// </summary>
    public class PrintScoreModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        public string ExamDate { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>

        public string IDCard { get; set; }

        /// <summary>
        /// 身份证照片路劲
        /// </summary>
        public string IDCardPath { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        
        public string CarType { get; set; }

        /// <summary>
        ///业务类型
        /// </summary>
        public string BusinessType { get; set; }

        public ExamMode FirstExam { get; set; }
        public ExamMode SecondExam { get; set; }
    }

    public class ExamMode {
        //考试时间 13：40：37-14：00：42 包含了开始和结束时间
        public string ExamTime { get; set; }

        public int Score { get; set; }

        public string DedictionRules { get; set; }

        /// <summary>
        /// 抓怕照片第一张路径
        /// </summary>
        public string CaptureImageFirstPath { get; set; }

        /// <summary>
        /// 抓怕照片第二张路径
        /// </summary>
        public string CaptureImageSecondPath { get; set; }

        /// <summary>
        /// 抓怕照片第三者路径
        /// </summary>

        public string CaptureImageThirdPath { get; set; }
    }

    /// <summary>
    ///模板上面所有的书签名字
    /// </summary>
    public class TemplateBookMarkName {

        public const string IDCardImage = "IDCardImage";
        public const string name = "name";
        public const string businessType = "businessType";
        public const string examAddress = "examAddress";
        public const string examDate = "examDate";
        public const string firstExamBreakeRule = "firstExamBreakeRule";
        public const string firstExamFirstCapturePhoto = "firstExamFirstCapturePhoto";
        public const string firstExamScore = "firstExamScore";
        public const string firstExamSecondCapturePhoto = "firstExamSecondCapturePhoto";
        public const string firstExamThirdCapturePhoto = "firstExamThirdCapturePhoto";
        public const string firstExamTime = "firstExamTime";
        public const string IdCard = "IdCard";
        public const string SecondExamBreakeRule = "SecondExamBreakeRule";
        public const string SecondExamFirstCapturePhoto = "SecondExamFirstCapturePhoto";
        public const string SecondExamScore = "SecondExamScore";
        public const string SecondExamSecondCapturePhoto = "SecondExamSecondCapturePhoto";
        public const string SecondExamThirdCapturePhoto = "SecondExamThirdCapturePhoto";
        public const string SecondExamTime = "SecondExamTime";

    }


}
