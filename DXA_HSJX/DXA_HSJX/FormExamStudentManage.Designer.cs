namespace DXA_HSJX
{
    partial class FormExamStudentManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExamStudentManage));
            this.lableTitle = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.picIDCardImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.radC1 = new CCWin.SkinControl.SkinRadioButton();
            this.radC2 = new CCWin.SkinControl.SkinRadioButton();
            this.pannelCarType = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picIDCardImage)).BeginInit();
            this.pannelCarType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lableTitle
            // 
            this.lableTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lableTitle.Appearance.Font = new System.Drawing.Font("华文行楷", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lableTitle.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lableTitle.Appearance.Options.UseFont = true;
            this.lableTitle.Appearance.Options.UseForeColor = true;
            this.lableTitle.Location = new System.Drawing.Point(12, 27);
            this.lableTitle.Name = "lableTitle";
            this.lableTitle.Size = new System.Drawing.Size(833, 51);
            this.lableTitle.TabIndex = 4;
            this.lableTitle.Text = "南京多伦公司道路驾驶计算机考试系统";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(55, 107);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(78, 23);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "姓   名：";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtName.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(139, 104);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 30);
            this.txtName.TabIndex = 16;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(49, 160);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 23);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "身份证：";
            // 
            // txtIDCard
            // 
            this.txtIDCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtIDCard.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtIDCard.ForeColor = System.Drawing.Color.White;
            this.txtIDCard.Location = new System.Drawing.Point(139, 153);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(236, 30);
            this.txtIDCard.TabIndex = 19;
            // 
            // picIDCardImage
            // 
            this.picIDCardImage.Image = ((System.Drawing.Image)(resources.GetObject("picIDCardImage.Image")));
            this.picIDCardImage.Location = new System.Drawing.Point(438, 104);
            this.picIDCardImage.Name = "picIDCardImage";
            this.picIDCardImage.Size = new System.Drawing.Size(144, 134);
            this.picIDCardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIDCardImage.TabIndex = 20;
            this.picIDCardImage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(179)))), ((int)(((byte)(45)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnSave.Location = new System.Drawing.Point(55, 361);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(302, 55);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "录入";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(179)))), ((int)(((byte)(45)))));
            this.btnExit.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnExit.Location = new System.Drawing.Point(438, 361);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(302, 55);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(55, 204);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 23);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "手机：";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.Location = new System.Drawing.Point(139, 204);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(236, 30);
            this.txtPhone.TabIndex = 24;
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Appearance.Options.UseFont = true;
            this.lblMsg.Appearance.Options.UseForeColor = true;
            this.lblMsg.Location = new System.Drawing.Point(633, 104);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 23);
            this.lblMsg.TabIndex = 25;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtAddress.Enabled = false;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtAddress.ForeColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(121, 314);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(236, 30);
            this.txtAddress.TabIndex = 26;
            this.txtAddress.Text = "13637822683";
            this.txtAddress.Visible = false;
            // 
            // radC1
            // 
            this.radC1.AutoSize = true;
            this.radC1.BackColor = System.Drawing.Color.Transparent;
            this.radC1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.radC1.DownBack = null;
            this.radC1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.radC1.Location = new System.Drawing.Point(17, 13);
            this.radC1.MouseBack = null;
            this.radC1.Name = "radC1";
            this.radC1.NormlBack = null;
            this.radC1.SelectedDownBack = null;
            this.radC1.SelectedMouseBack = null;
            this.radC1.SelectedNormlBack = null;
            this.radC1.Size = new System.Drawing.Size(53, 27);
            this.radC1.TabIndex = 27;
            this.radC1.TabStop = true;
            this.radC1.Text = "C1";
            this.radC1.UseVisualStyleBackColor = false;
            // 
            // radC2
            // 
            this.radC2.AutoSize = true;
            this.radC2.BackColor = System.Drawing.Color.Transparent;
            this.radC2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.radC2.DownBack = null;
            this.radC2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.radC2.Location = new System.Drawing.Point(109, 13);
            this.radC2.MouseBack = null;
            this.radC2.Name = "radC2";
            this.radC2.NormlBack = null;
            this.radC2.SelectedDownBack = null;
            this.radC2.SelectedMouseBack = null;
            this.radC2.SelectedNormlBack = null;
            this.radC2.Size = new System.Drawing.Size(53, 27);
            this.radC2.TabIndex = 28;
            this.radC2.TabStop = true;
            this.radC2.Text = "C2";
            this.radC2.UseVisualStyleBackColor = false;
            // 
            // pannelCarType
            // 
            this.pannelCarType.Controls.Add(this.radC2);
            this.pannelCarType.Controls.Add(this.radC1);
            this.pannelCarType.Location = new System.Drawing.Point(139, 244);
            this.pannelCarType.Name = "pannelCarType";
            this.pannelCarType.Size = new System.Drawing.Size(200, 53);
            this.pannelCarType.TabIndex = 29;
            this.pannelCarType.Visible = false;
            // 
            // FormExamStudentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(852, 439);
            this.Controls.Add(this.pannelCarType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picIDCardImage);
            this.Controls.Add(this.txtIDCard);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lableTitle);
            this.Name = "FormExamStudentManage";
            this.Text = "FormExamStudentManage";
            this.Load += new System.EventHandler(this.FormExamStudentManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIDCardImage)).EndInit();
            this.pannelCarType.ResumeLayout(false);
            this.pannelCarType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lableTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.PictureBox picIDCardImage;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtPhone;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private System.Windows.Forms.TextBox txtAddress;
        private CCWin.SkinControl.SkinRadioButton radC1;
        private CCWin.SkinControl.SkinRadioButton radC2;
        private System.Windows.Forms.Panel pannelCarType;
    }
}