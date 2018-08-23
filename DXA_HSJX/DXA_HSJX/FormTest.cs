using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using Model;
using Spire.Doc;

namespace DXA_HSJX
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            

        }
        public Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
            pictureBox1.Image = bitmap;
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
            bitmap.Save(fileName, ImageFormat.Jpeg);
            bitmap.Dispose();

            //MemoryStream ms = new MemoryStream();
            //bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释
            //var Image = BytesToImage(bytes);
            //pictureBox1.Image = Image;
            //ms.Close();

             //打印word代码
            //Document doc = new Document();
            //var path = System.IO.Directory.GetCurrentDirectory() + "\\" + "test" + ".doc";
            //doc.LoadFromFile(path);

            //PrintDialog dialog = new PrintDialog();
            //dialog.AllowPrintToFile = true;
            //dialog.AllowCurrentPage = true;
            //dialog.AllowSomePages = true;
            //dialog.UseEXDialog = true;
            //doc.PrintDialog = dialog;

            //System.Drawing.Printing.PrintDocument printDoc = doc.PrintDocument;
            //printDoc.Print();

        }

        VideoCaptureDevice videoSource;
     private void FormTest_Load(object sender, EventArgs e)
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int selectedDeviceIndex =1;
           videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            videoSourcePlayer1.VideoSource = videoSource;
            // set NewFrame event handler
            videoSourcePlayer1.Start();
            videoSourcePlayer1.Visible = false;


            Timer t = new Timer();

            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.AutoReset = true;
            //timer.Enabled = true;
            //timer.Interval = 2000;
            //timer.Elapsed += Timer_Elapsed;
           // timer.Start();
        }
    
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (videoSource == null)
                return;
      

           // return bytes；


        }


      
        private void button2_Click(object sender, EventArgs e)
        {
            //ceshi 
            var picpath = System.IO.Directory.GetCurrentDirectory() + "\\" + "capture.jpg";
            var IdCardPath = System.IO.Directory.GetCurrentDirectory() + "\\" + "zp.bmp";
            PrintScoreModel model = new PrintScoreModel();
            model.Name = "鲍君";
            model.BusinessType = "初次申请";
            model.CarType = "C1";
            model.ExamDate = "2018-08-20";
            model.IDCard = "5000227119111294612";
            model.IDCardPath = IdCardPath;
            model.FirstExam = new ExamMode();
            model.FirstExam.CaptureImageFirstPath = picpath;
           
            model.FirstExam.CaptureImageSecondPath = picpath;
            model.FirstExam.CaptureImageThirdPath=picpath;
            model.FirstExam.DedictionRules = "倒库不入";
            model.FirstExam.Score = 0;
            model.FirstExam.ExamTime = "19:46:00-20:20:00";

            model.SecondExam = new ExamMode();
            model.SecondExam.CaptureImageFirstPath = picpath;
            model.SecondExam.CaptureImageSecondPath = picpath;
            model.SecondExam.CaptureImageThirdPath = picpath;
            model.SecondExam.Score = 100;
            model.SecondExam.ExamTime = "19:46:00-20:20:00";
            model.SecondExam.DedictionRules = "倒车前前保险杠未至于终端线上，不超过50厘米";


            model.SecondExam.CaptureImageSecondPath = picpath;
            WriteIntoWord wiw = null;
            wiw = new WriteIntoWord();
            var path = System.IO.Directory.GetCurrentDirectory() + "\\" + "PrintTemplate.dotx";
            wiw.CreateNewDocument(path);
     

            wiw.WriteIntoDocument(TemplateBookMarkName.name,model.Name);
            wiw.WriteIntoDocument(TemplateBookMarkName.IdCard, model.IDCard);
            wiw.WriteIntoDocument(TemplateBookMarkName.businessType, model.BusinessType);
            wiw.WriteIntoDocument(TemplateBookMarkName.examDate, model.ExamDate);
            wiw.WriteIntoDocument(TemplateBookMarkName.examAddress, "华山驾校十区一号线");
            wiw.WriteIntoDocument(TemplateBookMarkName.firstExamTime, model.FirstExam.ExamTime);
            wiw.WriteIntoDocument(TemplateBookMarkName.firstExamBreakeRule, model.FirstExam.DedictionRules);
            wiw.WriteIntoDocument(TemplateBookMarkName.firstExamScore, model.FirstExam.Score.ToString());

            wiw.WritePicIntoDocument(TemplateBookMarkName.IDCardImage, model.IDCardPath);
            wiw.WritePicIntoDocument(TemplateBookMarkName.firstExamFirstCapturePhoto, model.SecondExam.CaptureImageFirstPath);
            wiw.WritePicIntoDocument(TemplateBookMarkName.firstExamSecondCapturePhoto, model.SecondExam.CaptureImageSecondPath);
            wiw.WritePicIntoDocument(TemplateBookMarkName.firstExamThirdCapturePhoto, model.SecondExam.CaptureImageThirdPath);

            wiw.WriteIntoDocument(TemplateBookMarkName.SecondExamTime, model.SecondExam.ExamTime);
            wiw.WriteIntoDocument(TemplateBookMarkName.SecondExamBreakeRule, model.SecondExam.DedictionRules);
            wiw.WriteIntoDocument(TemplateBookMarkName.SecondExamScore, model.SecondExam.Score.ToString());


            wiw.WritePicIntoDocument(TemplateBookMarkName.SecondExamFirstCapturePhoto, model.SecondExam.CaptureImageFirstPath);
            wiw.WritePicIntoDocument(TemplateBookMarkName.SecondExamSecondCapturePhoto, model.SecondExam.CaptureImageSecondPath);
            wiw.WritePicIntoDocument(TemplateBookMarkName.SecondExamThirdCapturePhoto, model.SecondExam.CaptureImageThirdPath);
            path = System.IO.Directory.GetCurrentDirectory() + "\\" +"print"+ ".doc";
            wiw.Save_CloseDocument(path);

             var Image=wiw.WordtoImage(path)[0];
            Image.Save("Image.jpg",ImageFormat.Jpeg);


            //调用Com组建的word转图片
            //Document doc = new Document();
            //doc.LoadFromFile(path);
            ////convert to image
            ////doc.BuiltinDocumentProperties.PageCount  word的页数，这个属性找了好久才找到啊，官方的demo没看到使用过这个属性。
            //for (int i = 0; i < doc.BuiltinDocumentProperties.PageCount; i++)
            //{
            //    System.Drawing.Image image = doc.SaveToImages(i, Spire.Doc.Documents.ImageType.Metafile);
            //    image.Save(i.ToString() + ".jpg", ImageFormat.Jpeg);
            //}
            MessageBox.Show("成功");

            //然后 开始 打印

        }



        //videoSourcePlayer1.Visible = false;
    }
}
