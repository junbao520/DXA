using DevExpress.XtraEditors;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Model;
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
    public partial class FormManualJudge : Form
    {
        //todo：扣分后还是通过消息机制发送 

        IEFRepository<DeductionRule> deductionRuleReposiatory;
        public  DeductionRule SelectedRule { get; set; }
        IMessenger Messenger;

        public int Position = 0;
        public FormManualJudge()
        {
            InitializeComponent();
        }
        public string IDCard = string.Empty;

        private void FormManualJudge_Load(object sender, EventArgs e)
        {
            btnCF.Click += BtnExamItem_Click;
            btnComon.Click += BtnExamItem_Click;
            btnDK.Click += BtnExamItem_Click;
            btnPQ.Click+= BtnExamItem_Click;
            btnQX.Click+= BtnExamItem_Click;
            btnZJ.Click += BtnExamItem_Click;
            dataGridViewDeduction.AutoGenerateColumns = false;
            deductionRuleReposiatory = ServiceLocator.Current.GetInstance<IEFRepository<DeductionRule>>();
            Messenger = ServiceLocator.Current.GetInstance<IMessenger>();
            InitDeductionRule((int)ExamItemEnum.CommonExamItem);
            
        }
        private void BtnExamItem_Click(object sender, EventArgs e)
        {
            var btn = (SimpleButton)sender;
            ExamItemEnum ExamItem = ExamItemEnum.CommonExamItem;
            if (btn.Text=="综合评判")
            {
                ExamItem = ExamItemEnum.CommonExamItem;
            }
           else if (btn.Text == "倒车入库")
            {
                ExamItem = ExamItemEnum.ReverseParking;
            }
            else if (btn.Text == "侧方停车")
            {
                ExamItem = ExamItemEnum.ParallelParking;
            }
            else if (btn.Text == "曲线行驶")
            {
                ExamItem = ExamItemEnum.QuarterTurning;
            }
            else if (btn.Text == "直角转弯")
            {
                ExamItem = ExamItemEnum.CurveDriving;
            }
            else if (btn.Text == "坡道起步")
            {
                ExamItem = ExamItemEnum.SlopeWayParkingAndStarting;
            }
            InitDeductionRule((int)ExamItem);
        }
        public void InitDeductionRule(int ItemCode)
        {
            //update [HSJX].[dbo].[DeductionRules] set ExamItemName=ItemName
           // from ExamItems inner join [HSJX].[dbo].[DeductionRules] on [ExamItemId] = ItemCode
            
     dataGridViewDeduction.DataSource=deductionRuleReposiatory.LoadEntities(s => s.ExamItemId == ItemCode);
        }
        private void BtnCF_Click(object sender, EventArgs e)
        {
            
        }

        //直接读取返回值
        private void btnDeduction_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
           // BorkenRuleMessage message = new BorkenRuleMessage(SelectedRule,Position);
           // Messenger.Send<BorkenRuleMessage>(message);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SelectedRule = null;
            this.Close();
        }

        private void dataGridViewDeduction_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeduction.SelectedRows.Count > 0)
                SelectedRule = dataGridViewDeduction.SelectedRows[0].DataBoundItem as DeductionRule;
            else
                SelectedRule = null;
        }
    }
}
