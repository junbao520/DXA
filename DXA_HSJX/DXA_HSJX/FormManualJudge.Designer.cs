namespace DXA_HSJX
{
    partial class FormManualJudge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDeduction = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeductedScores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeductedReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeduction = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnParallelParking = new DevExpress.XtraEditors.SimpleButton();
            this.btnCF = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnComon = new DevExpress.XtraEditors.SimpleButton();
            this.btnDK = new DevExpress.XtraEditors.SimpleButton();
            this.btnZJ = new DevExpress.XtraEditors.SimpleButton();
            this.btnPQ = new DevExpress.XtraEditors.SimpleButton();
            this.btnQX = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeduction)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 100);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "考试项目";
            // 
            // dataGridViewDeduction
            // 
            this.dataGridViewDeduction.AllowUserToAddRows = false;
            this.dataGridViewDeduction.AllowUserToDeleteRows = false;
            this.dataGridViewDeduction.AllowUserToResizeColumns = false;
            this.dataGridViewDeduction.AllowUserToResizeRows = false;
            this.dataGridViewDeduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDeduction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeduction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DeductedScores,
            this.DeductedReason});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDeduction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDeduction.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewDeduction.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewDeduction.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewDeduction.MultiSelect = false;
            this.dataGridViewDeduction.Name = "dataGridViewDeduction";
            this.dataGridViewDeduction.ReadOnly = true;
            this.dataGridViewDeduction.RowHeadersVisible = false;
            this.dataGridViewDeduction.RowTemplate.Height = 40;
            this.dataGridViewDeduction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewDeduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDeduction.Size = new System.Drawing.Size(982, 338);
            this.dataGridViewDeduction.TabIndex = 2;
            this.dataGridViewDeduction.Click += new System.EventHandler(this.dataGridViewDeduction_Click);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 99.47188F;
            this.Id.HeaderText = "序号";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // DeductedScores
            // 
            this.DeductedScores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeductedScores.DataPropertyName = "DeductedScores";
            this.DeductedScores.FillWeight = 152.2843F;
            this.DeductedScores.HeaderText = "扣分";
            this.DeductedScores.Name = "DeductedScores";
            this.DeductedScores.ReadOnly = true;
            // 
            // DeductedReason
            // 
            this.DeductedReason.DataPropertyName = "DeductedReason";
            this.DeductedReason.FillWeight = 48.24385F;
            this.DeductedReason.HeaderText = "扣分原因";
            this.DeductedReason.Name = "DeductedReason";
            this.DeductedReason.ReadOnly = true;
            // 
            // btnDeduction
            // 
            this.btnDeduction.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(179)))), ((int)(((byte)(45)))));
            this.btnDeduction.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeduction.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDeduction.Appearance.Options.UseBackColor = true;
            this.btnDeduction.Appearance.Options.UseFont = true;
            this.btnDeduction.Appearance.Options.UseForeColor = true;
            this.btnDeduction.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnDeduction.Location = new System.Drawing.Point(579, 29);
            this.btnDeduction.Name = "btnDeduction";
            this.btnDeduction.Size = new System.Drawing.Size(170, 55);
            this.btnDeduction.TabIndex = 34;
            this.btnDeduction.Text = "扣分";
            this.btnDeduction.Click += new System.EventHandler(this.btnDeduction_Click);
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
            this.btnExit.Location = new System.Drawing.Point(787, 29);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 55);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.btnDeduction);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 438);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 100);
            this.panel2.TabIndex = 36;
            // 
            // btnParallelParking
            // 
            this.btnParallelParking.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnParallelParking.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnParallelParking.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnParallelParking.Appearance.Options.UseBackColor = true;
            this.btnParallelParking.Appearance.Options.UseFont = true;
            this.btnParallelParking.Appearance.Options.UseForeColor = true;
            this.btnParallelParking.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnParallelParking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParallelParking.Location = new System.Drawing.Point(0, 538);
            this.btnParallelParking.Name = "btnParallelParking";
            this.btnParallelParking.Size = new System.Drawing.Size(982, 0);
            this.btnParallelParking.TabIndex = 37;
            this.btnParallelParking.Text = "侧方停车";
            // 
            // btnCF
            // 
            this.btnCF.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnCF.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnCF.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCF.Appearance.Options.UseBackColor = true;
            this.btnCF.Appearance.Options.UseFont = true;
            this.btnCF.Appearance.Options.UseForeColor = true;
            this.btnCF.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnCF.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCF.Location = new System.Drawing.Point(161, 3);
            this.btnCF.Name = "btnCF";
            this.btnCF.Size = new System.Drawing.Size(111, 41);
            this.btnCF.TabIndex = 38;
            this.btnCF.Text = "侧方停车";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.btnQX, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPQ, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnZJ, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDK, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnComon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCF, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnComon
            // 
            this.btnComon.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnComon.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnComon.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnComon.Appearance.Options.UseBackColor = true;
            this.btnComon.Appearance.Options.UseFont = true;
            this.btnComon.Appearance.Options.UseForeColor = true;
            this.btnComon.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnComon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnComon.Location = new System.Drawing.Point(3, 3);
            this.btnComon.Name = "btnComon";
            this.btnComon.Size = new System.Drawing.Size(111, 41);
            this.btnComon.TabIndex = 39;
            this.btnComon.Text = "综合评判";
            // 
            // btnDK
            // 
            this.btnDK.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnDK.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnDK.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDK.Appearance.Options.UseBackColor = true;
            this.btnDK.Appearance.Options.UseFont = true;
            this.btnDK.Appearance.Options.UseForeColor = true;
            this.btnDK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDK.Location = new System.Drawing.Point(319, 3);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(111, 41);
            this.btnDK.TabIndex = 40;
            this.btnDK.Text = "倒车入库";
            // 
            // btnZJ
            // 
            this.btnZJ.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnZJ.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnZJ.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnZJ.Appearance.Options.UseBackColor = true;
            this.btnZJ.Appearance.Options.UseFont = true;
            this.btnZJ.Appearance.Options.UseForeColor = true;
            this.btnZJ.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnZJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnZJ.Location = new System.Drawing.Point(477, 3);
            this.btnZJ.Name = "btnZJ";
            this.btnZJ.Size = new System.Drawing.Size(111, 41);
            this.btnZJ.TabIndex = 41;
            this.btnZJ.Text = "直角转弯";
            // 
            // btnPQ
            // 
            this.btnPQ.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnPQ.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnPQ.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPQ.Appearance.Options.UseBackColor = true;
            this.btnPQ.Appearance.Options.UseFont = true;
            this.btnPQ.Appearance.Options.UseForeColor = true;
            this.btnPQ.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnPQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPQ.Location = new System.Drawing.Point(635, 3);
            this.btnPQ.Name = "btnPQ";
            this.btnPQ.Size = new System.Drawing.Size(111, 41);
            this.btnPQ.TabIndex = 42;
            this.btnPQ.Text = "上坡起步";
            // 
            // btnQX
            // 
            this.btnQX.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(71)))), ((int)(((byte)(102)))));
            this.btnQX.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnQX.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnQX.Appearance.Options.UseBackColor = true;
            this.btnQX.Appearance.Options.UseFont = true;
            this.btnQX.Appearance.Options.UseForeColor = true;
            this.btnQX.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnQX.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnQX.Location = new System.Drawing.Point(793, 3);
            this.btnQX.Name = "btnQX";
            this.btnQX.Size = new System.Drawing.Size(111, 41);
            this.btnQX.TabIndex = 43;
            this.btnQX.Text = "曲线行驶";
            // 
            // FormManualJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 534);
            this.Controls.Add(this.btnParallelParking);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewDeduction);
            this.Controls.Add(this.panel1);
            this.Name = "FormManualJudge";
            this.Text = "FormManualJudge";
            this.Load += new System.EventHandler(this.FormManualJudge_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeduction)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewDeduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeductedScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeductedReason;
        private DevExpress.XtraEditors.SimpleButton btnDeduction;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnParallelParking;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnQX;
        private DevExpress.XtraEditors.SimpleButton btnPQ;
        private DevExpress.XtraEditors.SimpleButton btnZJ;
        private DevExpress.XtraEditors.SimpleButton btnDK;
        private DevExpress.XtraEditors.SimpleButton btnComon;
        private DevExpress.XtraEditors.SimpleButton btnCF;
    }
}