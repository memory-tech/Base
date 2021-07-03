
namespace ScheduleManagement
{
    partial class Affair
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_EndTime = new System.Windows.Forms.TextBox();
            this.textBox_TimeInterval = new System.Windows.Forms.TextBox();
            this.textBox_Unit = new System.Windows.Forms.TextBox();
            this.textBox_RemindTimes = new System.Windows.Forms.TextBox();
            this.textBox_state = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label_timeinterval = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label_content = new System.Windows.Forms.Label();
            this.label_urgency = new System.Windows.Forms.Label();
            this.label_endtime = new System.Windows.Forms.Label();
            this.label_datetime = new System.Windows.Forms.Label();
            this.label_place = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_test = new System.Windows.Forms.TextBox();
            this.label_test_AffId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToResizeColumns = false;
            this.DataGridView1.AllowUserToResizeRows = false;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(20, 107);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 51;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.Size = new System.Drawing.Size(186, 418);
            this.DataGridView1.TabIndex = 14;
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick_1);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 20F);
            this.label7.Location = new System.Drawing.Point(154, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 39);
            this.label7.TabIndex = 13;
            this.label7.Text = "待办事项";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(78, 12);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(100, 25);
            this.textBox_Title.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(77, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(77, 136);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(77, 167);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 44);
            this.button2.TabIndex = 21;
            this.button2.Text = "添加事项";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 483);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 42);
            this.button3.TabIndex = 22;
            this.button3.Text = "修改事项";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(327, 531);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 44);
            this.button4.TabIndex = 23;
            this.button4.Text = "删除事项";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "序号";
            // 
            // textBox_EndTime
            // 
            this.textBox_EndTime.Location = new System.Drawing.Point(77, 105);
            this.textBox_EndTime.Name = "textBox_EndTime";
            this.textBox_EndTime.Size = new System.Drawing.Size(100, 25);
            this.textBox_EndTime.TabIndex = 25;
            // 
            // textBox_TimeInterval
            // 
            this.textBox_TimeInterval.Location = new System.Drawing.Point(77, 229);
            this.textBox_TimeInterval.Name = "textBox_TimeInterval";
            this.textBox_TimeInterval.Size = new System.Drawing.Size(42, 25);
            this.textBox_TimeInterval.TabIndex = 27;
            // 
            // textBox_Unit
            // 
            this.textBox_Unit.Location = new System.Drawing.Point(127, 229);
            this.textBox_Unit.Name = "textBox_Unit";
            this.textBox_Unit.Size = new System.Drawing.Size(51, 25);
            this.textBox_Unit.TabIndex = 28;
            // 
            // textBox_RemindTimes
            // 
            this.textBox_RemindTimes.Location = new System.Drawing.Point(77, 260);
            this.textBox_RemindTimes.Name = "textBox_RemindTimes";
            this.textBox_RemindTimes.Size = new System.Drawing.Size(100, 25);
            this.textBox_RemindTimes.TabIndex = 29;
            // 
            // textBox_state
            // 
            this.textBox_state.Location = new System.Drawing.Point(77, 198);
            this.textBox_state.Name = "textBox_state";
            this.textBox_state.Size = new System.Drawing.Size(100, 25);
            this.textBox_state.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label_timeinterval);
            this.panel1.Controls.Add(this.label_state);
            this.panel1.Controls.Add(this.label_content);
            this.panel1.Controls.Add(this.label_urgency);
            this.panel1.Controls.Add(this.label_endtime);
            this.panel1.Controls.Add(this.label_datetime);
            this.panel1.Controls.Add(this.label_place);
            this.panel1.Controls.Add(this.label_title);
            this.panel1.Controls.Add(this.textBox_RemindTimes);
            this.panel1.Controls.Add(this.textBox_state);
            this.panel1.Controls.Add(this.textBox_Unit);
            this.panel1.Controls.Add(this.textBox_Title);
            this.panel1.Controls.Add(this.textBox_TimeInterval);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox_EndTime);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Location = new System.Drawing.Point(227, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 352);
            this.panel1.TabIndex = 31;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "提醒次数";
            // 
            // label_timeinterval
            // 
            this.label_timeinterval.AutoSize = true;
            this.label_timeinterval.Location = new System.Drawing.Point(4, 239);
            this.label_timeinterval.Name = "label_timeinterval";
            this.label_timeinterval.Size = new System.Drawing.Size(67, 15);
            this.label_timeinterval.TabIndex = 38;
            this.label_timeinterval.Text = "提醒间隔";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(16, 208);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(37, 15);
            this.label_state.TabIndex = 37;
            this.label_state.Text = "状态";
            // 
            // label_content
            // 
            this.label_content.AutoSize = true;
            this.label_content.Location = new System.Drawing.Point(16, 177);
            this.label_content.Name = "label_content";
            this.label_content.Size = new System.Drawing.Size(37, 15);
            this.label_content.TabIndex = 36;
            this.label_content.Text = "备注";
            // 
            // label_urgency
            // 
            this.label_urgency.AutoSize = true;
            this.label_urgency.Location = new System.Drawing.Point(4, 139);
            this.label_urgency.Name = "label_urgency";
            this.label_urgency.Size = new System.Drawing.Size(67, 15);
            this.label_urgency.TabIndex = 35;
            this.label_urgency.Text = "紧急程度";
            // 
            // label_endtime
            // 
            this.label_endtime.AutoSize = true;
            this.label_endtime.Location = new System.Drawing.Point(4, 108);
            this.label_endtime.Name = "label_endtime";
            this.label_endtime.Size = new System.Drawing.Size(67, 15);
            this.label_endtime.TabIndex = 34;
            this.label_endtime.Text = "截止时间";
            // 
            // label_datetime
            // 
            this.label_datetime.AutoSize = true;
            this.label_datetime.Location = new System.Drawing.Point(4, 77);
            this.label_datetime.Name = "label_datetime";
            this.label_datetime.Size = new System.Drawing.Size(67, 15);
            this.label_datetime.TabIndex = 33;
            this.label_datetime.Text = "发生时间";
            // 
            // label_place
            // 
            this.label_place.AutoSize = true;
            this.label_place.Location = new System.Drawing.Point(18, 46);
            this.label_place.Name = "label_place";
            this.label_place.Size = new System.Drawing.Size(37, 15);
            this.label_place.TabIndex = 32;
            this.label_place.Text = "地点";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(18, 15);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(37, 15);
            this.label_title.TabIndex = 31;
            this.label_title.Text = "主题";
            // 
            // textBox_test
            // 
            this.textBox_test.Location = new System.Drawing.Point(68, 543);
            this.textBox_test.Name = "textBox_test";
            this.textBox_test.Size = new System.Drawing.Size(100, 25);
            this.textBox_test.TabIndex = 32;
            // 
            // label_test_AffId
            // 
            this.label_test_AffId.AutoSize = true;
            this.label_test_AffId.Location = new System.Drawing.Point(408, 45);
            this.label_test_AffId.Name = "label_test_AffId";
            this.label_test_AffId.Size = new System.Drawing.Size(55, 15);
            this.label_test_AffId.TabIndex = 33;
            this.label_test_AffId.Text = "label3";
            // 
            // Affair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ScheduleManagement.Properties.Resources.背景;
            this.Controls.Add(this.label_test_AffId);
            this.Controls.Add(this.textBox_test);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Name = "Affair";
            this.Size = new System.Drawing.Size(501, 592);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_EndTime;
        private System.Windows.Forms.TextBox textBox_TimeInterval;
        private System.Windows.Forms.TextBox textBox_Unit;
        private System.Windows.Forms.TextBox textBox_RemindTimes;
        private System.Windows.Forms.TextBox textBox_state;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_content;
        private System.Windows.Forms.Label label_urgency;
        private System.Windows.Forms.Label label_endtime;
        private System.Windows.Forms.Label label_datetime;
        private System.Windows.Forms.Label label_place;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_timeinterval;
        private System.Windows.Forms.TextBox textBox_test;
        private System.Windows.Forms.Label label_test_AffId;
    }
}
