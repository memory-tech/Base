
namespace ScheduleManagement
{
    partial class Pomodoro
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pomodoro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tomatoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeSet = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.cmbRemindStyle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.tomatoLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TimeSet);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.cmbRemindStyle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 285);
            this.panel1.TabIndex = 16;
            // 
            // tomatoLabel
            // 
            this.tomatoLabel.AutoSize = true;
            this.tomatoLabel.Font = new System.Drawing.Font("楷体", 10F);
            this.tomatoLabel.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.tomatoLabel.Location = new System.Drawing.Point(82, 11);
            this.tomatoLabel.Name = "tomatoLabel";
            this.tomatoLabel.Size = new System.Drawing.Size(17, 17);
            this.tomatoLabel.TabIndex = 18;
            this.tomatoLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 11F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "番茄数";
            // 
            // TimeSet
            // 
            this.TimeSet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TimeSet.AutoSize = true;
            this.TimeSet.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeSet.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.TimeSet.Location = new System.Drawing.Point(119, 92);
            this.TimeSet.Name = "TimeSet";
            this.TimeSet.Size = new System.Drawing.Size(122, 40);
            this.TimeSet.TabIndex = 10;
            this.TimeSet.Text = "25:00";
            this.TimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold);
            this.label.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label.Location = new System.Drawing.Point(109, 21);
            this.label.Name = "label";
            this.label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label.Size = new System.Drawing.Size(122, 40);
            this.label.TabIndex = 16;
            this.label.Text = "label";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRemindStyle
            // 
            this.cmbRemindStyle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbRemindStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemindStyle.FormattingEnabled = true;
            this.cmbRemindStyle.Items.AddRange(new object[] {
            "响铃",
            "震动",
            "响铃且震动"});
            this.cmbRemindStyle.Location = new System.Drawing.Point(198, 182);
            this.cmbRemindStyle.Name = "cmbRemindStyle";
            this.cmbRemindStyle.Size = new System.Drawing.Size(121, 23);
            this.cmbRemindStyle.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "提醒方式";
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.Location = new System.Drawing.Point(215, 327);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(104, 44);
            this.btnEnd.TabIndex = 15;
            this.btnEnd.Text = "结束";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.Transparent;
            this.btnBegin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin.Location = new System.Drawing.Point(32, 327);
            this.btnBegin.Margin = new System.Windows.Forms.Padding(4);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(95, 44);
            this.btnBegin.TabIndex = 14;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // Pomodoro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ScheduleManagement.Properties.Resources.背景;
            this.ClientSize = new System.Drawing.Size(353, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pomodoro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pomodoro_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TimeSet;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cmbRemindStyle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label tomatoLabel;
        private System.Windows.Forms.Label label1;
    }
}
