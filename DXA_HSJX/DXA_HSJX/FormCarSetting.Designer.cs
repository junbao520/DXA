namespace DXA_HSJX
{
    partial class FormCarSetting
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
            this.listExamCar = new DevExpress.XtraEditors.ListBoxControl();
            this.lableTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtLicensePlate = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbExamStudent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.listExamCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamStudent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listExamCar
            // 
            this.listExamCar.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.listExamCar.Appearance.Options.UseFont = true;
            this.listExamCar.Cursor = System.Windows.Forms.Cursors.Default;
            this.listExamCar.Location = new System.Drawing.Point(57, 84);
            this.listExamCar.Name = "listExamCar";
            this.listExamCar.Size = new System.Drawing.Size(194, 271);
            this.listExamCar.TabIndex = 0;
            this.listExamCar.Click += new System.EventHandler(this.listExamCar_Click);
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
            this.lableTitle.Location = new System.Drawing.Point(5, 12);
            this.lableTitle.Name = "lableTitle";
            this.lableTitle.Size = new System.Drawing.Size(833, 51);
            this.lableTitle.TabIndex = 3;
            this.lableTitle.Text = "南京多伦公司道路驾驶计算机考试系统";
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtLicensePlate.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtLicensePlate.ForeColor = System.Drawing.Color.White;
            this.txtLicensePlate.Location = new System.Drawing.Point(395, 136);
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(341, 30);
            this.txtLicensePlate.TabIndex = 4;
            this.txtLicensePlate.Text = "川A0001";
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtIP.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtIP.ForeColor = System.Drawing.Color.White;
            this.txtIP.Location = new System.Drawing.Point(395, 197);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(341, 30);
            this.txtIP.TabIndex = 5;
            this.txtIP.Text = "川A0001";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtPort.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.Location = new System.Drawing.Point(395, 263);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(341, 30);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "川A0001";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(305, 136);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 23);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "车    牌：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(305, 200);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 23);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "I     P:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(305, 266);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 23);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "端  口：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(303, 332);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 23);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "学员：";
            // 
            // cmbExamStudent
            // 
            this.cmbExamStudent.Location = new System.Drawing.Point(395, 329);
            this.cmbExamStudent.Name = "cmbExamStudent";
            this.cmbExamStudent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cmbExamStudent.Properties.Appearance.Options.UseFont = true;
            this.cmbExamStudent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExamStudent.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbExamStudent.Size = new System.Drawing.Size(341, 30);
            this.cmbExamStudent.TabIndex = 11;
            this.cmbExamStudent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbExamStudent_KeyDown);
            this.cmbExamStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbExamStudent_KeyPress);
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
            this.btnSave.Location = new System.Drawing.Point(139, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(266, 55);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(305, 84);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(84, 23);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "编    号：";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtID.ForeColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(395, 84);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(341, 30);
            this.txtID.TabIndex = 14;
            this.txtID.Text = "川A0001";
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
            this.btnExit.Location = new System.Drawing.Point(446, 397);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(266, 55);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormCarSetting
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 497);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbExamStudent);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.listExamCar);
            this.Controls.Add(this.lableTitle);
            this.Name = "FormCarSetting";
            this.Text = "FormCarSetting";
            this.Load += new System.EventHandler(this.FormCarSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listExamCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamStudent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.ListBoxControl listExamCar;
        private DevExpress.XtraEditors.LabelControl lableTitle;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbExamStudent;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtID;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}