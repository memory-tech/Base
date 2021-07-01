
namespace ScheduleManagement
{
    partial class AddAffair
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.Alarm_Bell = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SetButton = new System.Windows.Forms.Button();
            this.textBox_test = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 20F);
            this.label4.Location = new System.Drawing.Point(37, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 44);
            this.label4.TabIndex = 38;
            this.label4.Text = "提醒方式：";
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.Transparent;
            this.SelectButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SelectButton.FlatAppearance.BorderSize = 0;
            this.SelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectButton.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectButton.ForeColor = System.Drawing.Color.Red;
            this.SelectButton.Location = new System.Drawing.Point(384, 213);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(4);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(67, 31);
            this.SelectButton.TabIndex = 42;
            this.SelectButton.Text = "选择";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // PathBox
            // 
            this.PathBox.BackColor = System.Drawing.Color.White;
            this.PathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathBox.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PathBox.ForeColor = System.Drawing.Color.Blue;
            this.PathBox.Location = new System.Drawing.Point(43, 217);
            this.PathBox.Margin = new System.Windows.Forms.Padding(4);
            this.PathBox.Multiline = true;
            this.PathBox.Name = "PathBox";
            this.PathBox.ReadOnly = true;
            this.PathBox.Size = new System.Drawing.Size(333, 24);
            this.PathBox.TabIndex = 41;
            this.PathBox.TextChanged += new System.EventHandler(this.PathBox_TextChanged);
            // 
            // TestButton
            // 
            this.TestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TestButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TestButton.FlatAppearance.BorderSize = 0;
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestButton.Location = new System.Drawing.Point(43, 273);
            this.TestButton.Margin = new System.Windows.Forms.Padding(4);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(79, 38);
            this.TestButton.TabIndex = 40;
            this.TestButton.Text = "测试";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // Alarm_Bell
            // 
            this.Alarm_Bell.AutoSize = true;
            this.Alarm_Bell.BackColor = System.Drawing.Color.Transparent;
            this.Alarm_Bell.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Alarm_Bell.Location = new System.Drawing.Point(38, 160);
            this.Alarm_Bell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Alarm_Bell.Name = "Alarm_Bell";
            this.Alarm_Bell.Size = new System.Drawing.Size(137, 25);
            this.Alarm_Bell.TabIndex = 39;
            this.Alarm_Bell.Text = "闹钟铃声：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SetButton
            // 
            this.SetButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SetButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.SetButton.FlatAppearance.BorderSize = 0;
            this.SetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetButton.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetButton.Location = new System.Drawing.Point(181, 273);
            this.SetButton.Margin = new System.Windows.Forms.Padding(4);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(84, 38);
            this.SetButton.TabIndex = 43;
            this.SetButton.Text = "保存";
            this.SetButton.UseVisualStyleBackColor = false;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // textBox_test
            // 
            this.textBox_test.Location = new System.Drawing.Point(379, 398);
            this.textBox_test.Name = "textBox_test";
            this.textBox_test.Size = new System.Drawing.Size(100, 25);
            this.textBox_test.TabIndex = 44;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // AddAffair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ScheduleManagement.Properties.Resources.背景;
            this.Controls.Add(this.textBox_test);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.Alarm_Bell);
            this.Controls.Add(this.label4);
            this.Name = "AddAffair";
            this.Size = new System.Drawing.Size(501, 592);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Label Alarm_Bell;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.TextBox textBox_test;
        private System.Windows.Forms.Timer timer2;
    }
}
