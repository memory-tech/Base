namespace Tomato
{
    partial class Tomato
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TimeSet = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRemindStyle = new System.Windows.Forms.ComboBox();
            this.cmbTaskType = new System.Windows.Forms.ComboBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tomatoAmount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeSet
            // 
            this.TimeSet.AutoSize = true;
            this.TimeSet.Font = new System.Drawing.Font("隶书", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeSet.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.TimeSet.Location = new System.Drawing.Point(296, 13);
            this.TimeSet.Name = "TimeSet";
            this.TimeSet.Size = new System.Drawing.Size(210, 70);
            this.TimeSet.TabIndex = 1;
            this.TimeSet.Text = "15:00";
            this.TimeSet.Click += new System.EventHandler(this.TimeSet_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbRemindStyle);
            this.panel1.Controls.Add(this.cmbTaskType);
            this.panel1.Controls.Add(this.btnEnd);
            this.panel1.Controls.Add(this.btnBegin);
            this.panel1.Controls.Add(this.TimeSet);
            this.panel1.Location = new System.Drawing.Point(-2, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 345);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "提醒方式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "任务类型";
            // 
            // cmbRemindStyle
            // 
            this.cmbRemindStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemindStyle.FormattingEnabled = true;
            this.cmbRemindStyle.Items.AddRange(new object[] {
            "响铃",
            "震动",
            "响铃且震动"});
            this.cmbRemindStyle.Location = new System.Drawing.Point(368, 256);
            this.cmbRemindStyle.Name = "cmbRemindStyle";
            this.cmbRemindStyle.Size = new System.Drawing.Size(121, 23);
            this.cmbRemindStyle.TabIndex = 9;
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Items.AddRange(new object[] {
            "工作",
            "学习",
            "读书",
            "写作",
            "休息"});
            this.cmbTaskType.Location = new System.Drawing.Point(368, 196);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(121, 23);
            this.cmbTaskType.TabIndex = 8;
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(484, 106);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(79, 38);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "关闭";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(241, 106);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(85, 38);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(52, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("华文新魏", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button1.Location = new System.Drawing.Point(626, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "总计";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文新魏", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label3.Location = new System.Drawing.Point(673, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "15分钟";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("华文新魏", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 44);
            this.label6.TabIndex = 5;
            this.label6.Text = "15分钟工作法";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("华文新魏", 15F);
            this.label7.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label7.Location = new System.Drawing.Point(437, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 26);
            this.label7.TabIndex = 7;
            this.label7.Text = "番茄数";
            // 
            // tomatoAmount
            // 
            this.tomatoAmount.AutoSize = true;
            this.tomatoAmount.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tomatoAmount.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tomatoAmount.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.tomatoAmount.Location = new System.Drawing.Point(530, 19);
            this.tomatoAmount.Name = "tomatoAmount";
            this.tomatoAmount.Size = new System.Drawing.Size(30, 21);
            this.tomatoAmount.TabIndex = 8;
            this.tomatoAmount.Text = "    ";
            // 
            // Tomato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tomatoAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tomato";
            this.Text = "番茄钟";
            this.Load += new System.EventHandler(this.Tomato_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TimeSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRemindStyle;
        private System.Windows.Forms.ComboBox cmbTaskType;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tomatoAmount;
    }
}

