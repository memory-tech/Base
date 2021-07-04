
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TimeInterval = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker_endtime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_datetime = new System.Windows.Forms.DateTimePicker();
            this.cmb_urgency = new System.Windows.Forms.ComboBox();
            this.cmb_state = new System.Windows.Forms.ComboBox();
            this.cmb_remindtimes = new System.Windows.Forms.ComboBox();
            this.cmb_unit = new System.Windows.Forms.ComboBox();
            this.label_remindtimes = new System.Windows.Forms.Label();
            this.label_timeinterval = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label_content = new System.Windows.Forms.Label();
            this.label_urgency = new System.Windows.Forms.Label();
            this.label_endtime = new System.Windows.Forms.Label();
            this.label_datetime = new System.Windows.Forms.Label();
            this.label_place = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_test_AffId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToResizeColumns = false;
            this.DataGridView1.AllowUserToResizeRows = false;
            this.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.Location = new System.Drawing.Point(4, 107);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.Size = new System.Drawing.Size(233, 434);
            this.DataGridView1.TabIndex = 14;
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick_1);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("楷体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(169, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 39);
            this.label7.TabIndex = 13;
            this.label7.Text = "待办事项";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(78, 12);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(147, 25);
            this.textBox_Title.TabIndex = 15;
            // 
            // textBox_place
            // 
            this.textBox_place.Location = new System.Drawing.Point(77, 43);
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.Size = new System.Drawing.Size(101, 25);
            this.textBox_place.TabIndex = 16;
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(78, 198);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(147, 79);
            this.textBox_content.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(255, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 26);
            this.button2.TabIndex = 21;
            this.button2.Text = "新建事项";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(383, 480);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 48);
            this.button3.TabIndex = 22;
            this.button3.Text = "保存修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(255, 515);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 26);
            this.button4.TabIndex = 23;
            this.button4.Text = "删除事项";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "序号";
            // 
            // textBox_TimeInterval
            // 
            this.textBox_TimeInterval.Location = new System.Drawing.Point(81, 283);
            this.textBox_TimeInterval.Name = "textBox_TimeInterval";
            this.textBox_TimeInterval.Size = new System.Drawing.Size(75, 25);
            this.textBox_TimeInterval.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker_endtime);
            this.panel1.Controls.Add(this.dateTimePicker_datetime);
            this.panel1.Controls.Add(this.cmb_urgency);
            this.panel1.Controls.Add(this.cmb_state);
            this.panel1.Controls.Add(this.cmb_remindtimes);
            this.panel1.Controls.Add(this.cmb_unit);
            this.panel1.Controls.Add(this.label_remindtimes);
            this.panel1.Controls.Add(this.label_timeinterval);
            this.panel1.Controls.Add(this.label_state);
            this.panel1.Controls.Add(this.label_content);
            this.panel1.Controls.Add(this.label_urgency);
            this.panel1.Controls.Add(this.label_endtime);
            this.panel1.Controls.Add(this.label_datetime);
            this.panel1.Controls.Add(this.label_place);
            this.panel1.Controls.Add(this.label_title);
            this.panel1.Controls.Add(this.textBox_Title);
            this.panel1.Controls.Add(this.textBox_TimeInterval);
            this.panel1.Controls.Add(this.textBox_place);
            this.panel1.Controls.Add(this.textBox_content);
            this.panel1.Location = new System.Drawing.Point(255, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 346);
            this.panel1.TabIndex = 31;
            // 
            // dateTimePicker_endtime
            // 
            this.dateTimePicker_endtime.CustomFormat = "yy/MM/dd HH:mm";
            this.dateTimePicker_endtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endtime.Location = new System.Drawing.Point(77, 105);
            this.dateTimePicker_endtime.Name = "dateTimePicker_endtime";
            this.dateTimePicker_endtime.Size = new System.Drawing.Size(158, 25);
            this.dateTimePicker_endtime.TabIndex = 34;
            // 
            // dateTimePicker_datetime
            // 
            this.dateTimePicker_datetime.CustomFormat = "yy/MM/dd HH:mm";
            this.dateTimePicker_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_datetime.Location = new System.Drawing.Point(77, 74);
            this.dateTimePicker_datetime.Name = "dateTimePicker_datetime";
            this.dateTimePicker_datetime.Size = new System.Drawing.Size(157, 25);
            this.dateTimePicker_datetime.TabIndex = 34;
            // 
            // cmb_urgency
            // 
            this.cmb_urgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_urgency.FormattingEnabled = true;
            this.cmb_urgency.Items.AddRange(new object[] {
            "非常紧急",
            "紧急",
            "一般",
            "未知"});
            this.cmb_urgency.Location = new System.Drawing.Point(78, 141);
            this.cmb_urgency.Name = "cmb_urgency";
            this.cmb_urgency.Size = new System.Drawing.Size(100, 23);
            this.cmb_urgency.TabIndex = 5;
            // 
            // cmb_state
            // 
            this.cmb_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_state.FormattingEnabled = true;
            this.cmb_state.Items.AddRange(new object[] {
            "未完成",
            "完成"});
            this.cmb_state.Location = new System.Drawing.Point(76, 170);
            this.cmb_state.Name = "cmb_state";
            this.cmb_state.Size = new System.Drawing.Size(102, 23);
            this.cmb_state.TabIndex = 42;
            // 
            // cmb_remindtimes
            // 
            this.cmb_remindtimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_remindtimes.FormattingEnabled = true;
            this.cmb_remindtimes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            ""});
            this.cmb_remindtimes.Location = new System.Drawing.Point(81, 314);
            this.cmb_remindtimes.Name = "cmb_remindtimes";
            this.cmb_remindtimes.Size = new System.Drawing.Size(109, 23);
            this.cmb_remindtimes.TabIndex = 41;
            // 
            // cmb_unit
            // 
            this.cmb_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_unit.FormattingEnabled = true;
            this.cmb_unit.Items.AddRange(new object[] {
            "分",
            "时",
            "天"});
            this.cmb_unit.Location = new System.Drawing.Point(172, 283);
            this.cmb_unit.Name = "cmb_unit";
            this.cmb_unit.Size = new System.Drawing.Size(53, 23);
            this.cmb_unit.TabIndex = 40;
            // 
            // label_remindtimes
            // 
            this.label_remindtimes.AutoSize = true;
            this.label_remindtimes.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_remindtimes.Location = new System.Drawing.Point(4, 317);
            this.label_remindtimes.Name = "label_remindtimes";
            this.label_remindtimes.Size = new System.Drawing.Size(71, 15);
            this.label_remindtimes.TabIndex = 39;
            this.label_remindtimes.Text = "提醒次数";
            // 
            // label_timeinterval
            // 
            this.label_timeinterval.AutoSize = true;
            this.label_timeinterval.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_timeinterval.Location = new System.Drawing.Point(4, 290);
            this.label_timeinterval.Name = "label_timeinterval";
            this.label_timeinterval.Size = new System.Drawing.Size(71, 15);
            this.label_timeinterval.TabIndex = 38;
            this.label_timeinterval.Text = "提醒间隔";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_state.Location = new System.Drawing.Point(18, 173);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(49, 20);
            this.label_state.TabIndex = 37;
            this.label_state.Text = "状态";
            // 
            // label_content
            // 
            this.label_content.AutoSize = true;
            this.label_content.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_content.Location = new System.Drawing.Point(18, 203);
            this.label_content.Name = "label_content";
            this.label_content.Size = new System.Drawing.Size(49, 20);
            this.label_content.TabIndex = 36;
            this.label_content.Text = "备注";
            // 
            // label_urgency
            // 
            this.label_urgency.AutoSize = true;
            this.label_urgency.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_urgency.Location = new System.Drawing.Point(8, 144);
            this.label_urgency.Name = "label_urgency";
            this.label_urgency.Size = new System.Drawing.Size(71, 15);
            this.label_urgency.TabIndex = 35;
            this.label_urgency.Text = "紧急程度";
            // 
            // label_endtime
            // 
            this.label_endtime.AutoSize = true;
            this.label_endtime.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_endtime.Location = new System.Drawing.Point(3, 108);
            this.label_endtime.Name = "label_endtime";
            this.label_endtime.Size = new System.Drawing.Size(71, 15);
            this.label_endtime.TabIndex = 34;
            this.label_endtime.Text = "结束时间";
            // 
            // label_datetime
            // 
            this.label_datetime.AutoSize = true;
            this.label_datetime.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_datetime.Location = new System.Drawing.Point(4, 81);
            this.label_datetime.Name = "label_datetime";
            this.label_datetime.Size = new System.Drawing.Size(71, 15);
            this.label_datetime.TabIndex = 33;
            this.label_datetime.Text = "开始时间";
            // 
            // label_place
            // 
            this.label_place.AutoSize = true;
            this.label_place.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_place.Location = new System.Drawing.Point(18, 46);
            this.label_place.Name = "label_place";
            this.label_place.Size = new System.Drawing.Size(49, 20);
            this.label_place.TabIndex = 32;
            this.label_place.Text = "地点";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(18, 15);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(49, 20);
            this.label_title.TabIndex = 31;
            this.label_title.Text = "主题";
            // 
            // label_test_AffId
            // 
            this.label_test_AffId.AutoSize = true;
            this.label_test_AffId.Location = new System.Drawing.Point(285, 526);
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
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_test_AffId);
            this.Controls.Add(this.label1);
            this.Name = "Affair";
            this.Size = new System.Drawing.Size(555, 609);
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
        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TimeInterval;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_content;
        private System.Windows.Forms.Label label_urgency;
        private System.Windows.Forms.Label label_endtime;
        private System.Windows.Forms.Label label_datetime;
        private System.Windows.Forms.Label label_place;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_remindtimes;
        private System.Windows.Forms.Label label_timeinterval;
        private System.Windows.Forms.Label label_test_AffId;
        private System.Windows.Forms.ComboBox cmb_urgency;
        private System.Windows.Forms.ComboBox cmb_state;
        private System.Windows.Forms.ComboBox cmb_remindtimes;
        private System.Windows.Forms.ComboBox cmb_unit;
        private System.Windows.Forms.DateTimePicker dateTimePicker_datetime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endtime;
    }
}
