using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXA_HSJX
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        IMessenger Messenger;
        UdpServer udpServer;
        IExamService examService;
        IEFRepository<ExamCar> examCarReposiatory;
        List<KeyValuePair<int,string>> lstPosition = new List<KeyValuePair<int, string>>();
        

        public FormMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
      ControlStyles.UserPaint |
      ControlStyles.AllPaintingInWmPaint,
      true);
            this.UpdateStyles();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        //我要获取所有的车辆信息
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Messenger = ServiceLocator.Current.GetInstance<IMessenger>();
            examCarReposiatory = ServiceLocator.Current.GetInstance<IEFRepository<ExamCar>>();
            examService= ServiceLocator.Current.GetInstance<IExamService>();
            udpServer = new UdpServer();
            udpServer.StartReceiveMsg();
            RegisterMessage(Messenger);
            InitCarControl();
            //初始化根据数据库的结果绑定考生
            InitCarExamStudent();
            // this.carExamControl1.Position = 1;
        }
        public void InitCarExamStudent()
        {
            var beginTime = DateTime.Now;
            //todo:不明白为何查询数据库如此慢 是否和我电脑C盘满了还有关系？
            var cars = examCarReposiatory.LoadEntities();
            var endTime1 = DateTime.Now;
            foreach (var item in cars)
            {
                if (item.ExamStudent!=null)
                {
                    onExamCarChangeMessage(new ExamCarChangeMessage(item));
                }
            }
            var endTime = DateTime.Now;
            var ts = endTime - beginTime;
        }
        public void InitCarControl()
        {
            this.carExamControl1.InitInstance(this.Messenger, this.udpServer,this.examService);
            this.carExamControl2.InitInstance(this.Messenger, this.udpServer,this.examService);
            this.carExamControl3.InitInstance(this.Messenger, this.udpServer,this.examService);
            this.carExamControl4.InitInstance(this.Messenger, this.udpServer,this.examService);
        }

        public void RegisterMessage(IMessenger message)
        {
            message.Register<ExamCarChangeMessage>(this, onExamCarChangeMessage);
            message.Register<ExamMessage>(this, OnExamMessage);
        }
        //初始化加载所有绑定车辆以前绑定的考试
        public void OnExamMessage(ExamMessage message)
        {
            var control = GetCarExamControl(message.ExamStudent.IdCard);
            if (control!=null)
            {
                control.updateExamMessage(message);
            }
            
        }
      

        public CarExamControl GetCarExamControl(int Position)
        {
            if (Position == 1)
            {
                return carExamControl1;
            }
            else if (Position == 2)
            {
                return carExamControl2;
            }
            else if (Position == 3)
            {
                return carExamControl3;
               
            }
            else
            {
                return carExamControl4;
            }

        }

        public CarExamControl GetCarExamControl(string IDCard)
        {
            if (lstPosition.Where(s=>s.Value==IDCard).Count()<=0)
            {
                return null;
            }
           var item= lstPosition.Where(s => s.Value == IDCard).FirstOrDefault();
            return GetCarExamControl(item.Key);
           
        }
        private void onExamCarChangeMessage(ExamCarChangeMessage message)
        {
            var examCar = message.ExamCar;
            var control = GetCarExamControl(examCar.Position);
            control.Position= examCar.Position;
            control.IDCard = examCar.ExamStudent.IdCard;
            //把这个车辆位置信息更新到内存中

            if (lstPosition.Where(s=>s.Key==examCar.Position).Count()>=0)
            {
                var Item = lstPosition.Where(s => s.Key == examCar.Position).FirstOrDefault();
                lstPosition.Remove(Item);
                var newItem = new KeyValuePair<int, string>(examCar.Position, examCar.ExamStudent.IdCard);
                lstPosition.Add(newItem);
            }
            else
            {
                var newItem = new KeyValuePair<int, string>(examCar.Position, examCar.ExamStudent.IdCard);
                lstPosition.Add(newItem);
            }
           

           
            control.updateExamCarInfo(message);
        }

        private void ExamStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExamStudentManage form = new FormExamStudentManage();
            form.ShowDialog();
        }

        private void ExamCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCarSetting form = new FormCarSetting();
            form.ShowDialog();
        }
        private void SystemSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
