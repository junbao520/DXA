using DevExpress.XtraEditors.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXA_HSJX
{
    public partial class FormCarSetting : DevExpress.XtraEditors.XtraForm
    {
        public FormCarSetting()
        {
            InitializeComponent();
        }
        private IEFRepository<ExamCar> examCarRepository;
        private IEFRepository<ExamStudent> examStudentRepository;
        private IMessenger Messenger;
        ExamCarChangeMessage message;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        //IP 地址201 620A
        private void btnSave_Click(object sender, EventArgs e)
        {


            //要不直接执行Sql 更新？
            //不在使用EF更新？
            //同一个人不能绑定两个车
            var IdCard = cmbExamStudent.Text.Split(',')[1];

            var examCarID = Convert.ToInt32(txtID.Text);
            var otherCarEntitiy = examCarRepository.LoadEntities(s => s.Id != examCarID && s.ExamStudent.IdCard == IdCard).FirstOrDefault(); ;
            //todo:设计Bug
            //如果这个学员有绑定其他车辆 那么这个学员 怎么办？ 
            //如果我删除关系会怎么样？
            //如果这个人选中路 
            //todo:bug 在这点
            //可以这样添加一个学员车辆关系表 
            //这样就可以知道学员那辆车了
            //其实我只要解决了更新头像Bug就可以了
            //这样还是会更新下//
            if (otherCarEntitiy!=null)
            {
                otherCarEntitiy.ExamStudentId = null;
                examCarRepository.UpdateEntity(otherCarEntitiy);
            }
          


            //其实这点不需要取查询了
            var examstudent = examStudentRepository.LoadEntitiy(s => s.IdCard == IdCard);
            // 其实还需要一个ID
            // 如果我不执行更新操作 //会怎么样？
            ExamCar examCar = examCarRepository.LoadEntitiy(s => s.Id == examCarID);
            examCar.Ip = txtIP.Text.ToString();
            examCar.Port = Convert.ToInt32(txtPort.Text);
            examCar.ExamStudentId = examstudent.Id;
            examCar.LicensePlate = txtLicensePlate.Text;
            examCar.ExamStudent = examstudent;
            examCarRepository.UpdateEntity(examCar);

            message = new ExamCarChangeMessage(examCar);
            //发送消息
            Messenger.Send<ExamCarChangeMessage>(message);
            //更新之后刷新列表
            //发送消息
            BindExamCar();

            MessageBox.Show("修改成功", "车辆管理");

        }

        public void BindExamCar()
        {
            listExamCar.DataSource = examCarRepository.LoadEntities();
            listExamCar.DisplayMember = "LicensePlate";
            listExamCar.ValueMember = "Id";

            ExamCarSelect(examCarRepository.LoadEntities().FirstOrDefault());
        }


        private void FormCarSetting_Load(object sender, EventArgs e)
        {
            examCarRepository = ServiceLocator.Current.GetInstance<EFRepositoryBase<ExamCar>>();
            examStudentRepository = ServiceLocator.Current.GetInstance<EFRepositoryBase<ExamStudent>>();
            Messenger = ServiceLocator.Current.GetInstance<IMessenger>();
            this.MaximizeBox = false;
            // var result = examCarRepository.LoadEntitiy(s=>s.Id==1);

            BindExamCar();
            cmbExamStudent.Properties.Items.Clear();
            //学员默认不重复就行
            var students = examStudentRepository.LoadEntities();
            ComboBoxItemCollection coll = cmbExamStudent.Properties.Items;
            foreach (var item in students)
            {
                coll.Add(item.Name + "," + item.IdCard);
            }

        }

        private void cmbExamStudent_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbExamStudent_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void ExamCarSelect(ExamCar examCar)
        {

            txtIP.Text = examCar.Ip;
            txtPort.Text = examCar.Port.ToString();
            txtLicensePlate.Text = examCar.LicensePlate.ToString();
            txtID.Text = examCar.Id.ToString();


            //为这个车加载选中项学员
            if (examCar.ExamStudent != null)
            {
                cmbExamStudent.Text = examCar.ExamStudent.Name + "," + examCar.ExamStudent.IdCard;
            }
        }
        private void listExamCar_Click(object sender, EventArgs e)
        {
            var selectItem = (ExamCar)listExamCar.SelectedItem;
            ExamCarSelect(selectItem);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
