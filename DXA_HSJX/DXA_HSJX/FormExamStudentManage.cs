using Microsoft.Practices.ServiceLocation;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXA_HSJX
{
    public partial class FormExamStudentManage : Form
    {

        private IEFRepository<ExamStudent> examStudentRepository;
        Timer timerCRV;
        public FormExamStudentManage()
        {
            InitializeComponent();
           
        }
        private int m_iUSBOpened = -1;
        private bool CRV_Init()
        {
            int iPort;
            for (iPort = 1001; iPort <= 1016; iPort++)
            {
                m_iUSBOpened = CVRSDK.CVR_InitComm(iPort);
                if (m_iUSBOpened == 1)
                {
                    break;
                }
            }

            return m_iUSBOpened == 1;
        }
        public Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        private void CRV_Start()
        {
            int authenticate = CVRSDK.CVR_Authenticate();
            if (authenticate == 1)
            {
                int readContent = CVRSDK.CVR_Read_Content(4);
                if (readContent == 1)
                {
                    byte[] number = new byte[30];
                    byte[] name = new byte[30];
                    byte[] people = new byte[30];
                    byte[] validtermOfStart = new byte[30];
                    byte[] birthday = new byte[30];
                    int length = 36;
                    CVRSDK.GetPeopleIDCode(ref number[0], ref length);
                    string SFZH = Encoding.Default.GetString(number).Replace("\0", "");
                    length = 30;
                    CVRSDK.GetPeopleName(ref name[0], ref length);
                    string Uname = Encoding.Default.GetString(name).Replace("\0", "");

                    CVRSDK.GetPeopleNation(ref people[0], ref length);
                    string PeopleNation = Encoding.Default.GetString(people).Replace("\0", "");

                    length = 16;
                    CVRSDK.GetStartDate(ref validtermOfStart[0], ref length);
                    string OfStart = Encoding.Default.GetString(validtermOfStart).Replace("\0", "");


                    length = 16;
                    CVRSDK.GetPeopleBirthday(ref birthday[0], ref length);
                    byte[] address = new byte[30];
                    length = 70;
                    CVRSDK.GetPeopleAddress(ref address[0], ref length);
                    string UAddress = Encoding.Default.GetString(address).Replace("\0", "");
                    byte[] validtermOfEnd = new byte[30];
                    length = 16;
                    CVRSDK.GetEndDate(ref validtermOfEnd[0], ref length);
                    byte[] signdate = new byte[30];
                    length = 30;
                    CVRSDK.GetDepartment(ref signdate[0], ref length);
                    byte[] sex = new byte[30];
                    length = 3;
                    CVRSDK.GetPeopleSex(ref sex[0], ref length);

                    byte[] samid = new byte[32];
                    CVRSDK.CVR_GetSAMID(ref samid[0]);

                    txtName.Text = Uname;
                    txtIDCard.Text = SFZH;
                    txtAddress.Text = UAddress;

                    var picbuff = System.IO.File.ReadAllBytes("zp.bmp");
                    picIDCardImage.Image = BytesToImage(picbuff);



                }
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            ExamStudent entity = new ExamStudent();
            var name = txtName.Text.Trim();
            var IdCard = txtIDCard.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var address = txtAddress.Text.Trim();
            if (picIDCardImage.Image != null)
            {
                var image = System.IO.File.ReadAllBytes("zp.bmp");
                entity.IDCardImage = image;
            }
            //判断身份证号码是否已经添加了
            if (examStudentRepository.LoadEntities(s =>s.IdCard==IdCard).Count() > 0)
            {
                MessageBox.Show("已经添加了该考生请勿重复添加","考生管理");
                return;
            }
          
            entity.IdCard = IdCard;
            entity.Phone = phone;
            entity.Name = name;

            examStudentRepository.AddEntity(entity);
            MessageBox.Show("录入成功", "考生管理");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormExamStudentManage_Load(object sender, EventArgs e)
        {
            examStudentRepository = ServiceLocator.Current.GetInstance<EFRepositoryBase<ExamStudent>>();
            CRV_Init();
            timerCRV = new Timer();
            timerCRV.Interval = 300;
            timerCRV.Enabled = true;
            timerCRV.Tick += TimerCRV_Tick;

        }

        private void TimerCRV_Tick(object sender, EventArgs e)
        {
            CRV_Start();
        }
    }
}
