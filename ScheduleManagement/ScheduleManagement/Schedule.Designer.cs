
namespace ScheduleManagement
{
    partial class Schedule
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
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.placelab = new System.Windows.Forms.Label();
            this.starttimelab = new System.Windows.Forms.Label();
            this.endtimelab = new System.Windows.Forms.Label();
            this.statelab = new System.Windows.Forms.Label();
            this.placeBox = new System.Windows.Forms.TextBox();
            this.starttimeBox = new System.Windows.Forms.TextBox();
            this.endtimeBox = new System.Windows.Forms.TextBox();
            this.stateBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 20F);
            this.label8.Location = new System.Drawing.Point(178, -50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 10);
            this.label8.TabIndex = 14;
            this.label8.Text = "  日程";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ColumnHeadersHeight = 29;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Location = new System.Drawing.Point(4, 60);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(313, 528);
            this.dataGridView2.TabIndex = 16;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(59, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 37);
            this.label1.TabIndex = 15;
            this.label1.Text = "  日程";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(360, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 39);
            this.button1.TabIndex = 17;
            this.button1.Text = "完成工作";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // placelab
            // 
            this.placelab.AutoSize = true;
            this.placelab.Font = new System.Drawing.Font("华文隶书", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.placelab.Location = new System.Drawing.Point(343, 102);
            this.placelab.Name = "placelab";
            this.placelab.Size = new System.Drawing.Size(58, 24);
            this.placelab.TabIndex = 18;
            this.placelab.Text = "地点";
            // 
            // starttimelab
            // 
            this.starttimelab.AutoSize = true;
            this.starttimelab.Font = new System.Drawing.Font("华文隶书", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.starttimelab.Location = new System.Drawing.Point(340, 191);
            this.starttimelab.Name = "starttimelab";
            this.starttimelab.Size = new System.Drawing.Size(106, 24);
            this.starttimelab.TabIndex = 19;
            this.starttimelab.Text = "开始时间";
            // 
            // endtimelab
            // 
            this.endtimelab.AutoSize = true;
            this.endtimelab.Font = new System.Drawing.Font("华文隶书", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endtimelab.Location = new System.Drawing.Point(339, 278);
            this.endtimelab.Name = "endtimelab";
            this.endtimelab.Size = new System.Drawing.Size(106, 24);
            this.endtimelab.TabIndex = 20;
            this.endtimelab.Text = "截止时间";
            // 
            // statelab
            // 
            this.statelab.AutoSize = true;
            this.statelab.Font = new System.Drawing.Font("华文隶书", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statelab.Location = new System.Drawing.Point(343, 363);
            this.statelab.Name = "statelab";
            this.statelab.Size = new System.Drawing.Size(58, 24);
            this.statelab.TabIndex = 21;
            this.statelab.Text = "状态";
            // 
            // placeBox
            // 
            this.placeBox.Location = new System.Drawing.Point(334, 129);
            this.placeBox.Multiline = true;
            this.placeBox.Name = "placeBox";
            this.placeBox.Size = new System.Drawing.Size(151, 43);
            this.placeBox.TabIndex = 22;
            // 
            // starttimeBox
            // 
            this.starttimeBox.Location = new System.Drawing.Point(334, 227);
            this.starttimeBox.Name = "starttimeBox";
            this.starttimeBox.Size = new System.Drawing.Size(151, 25);
            this.starttimeBox.TabIndex = 23;
            this.starttimeBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // endtimeBox
            // 
            this.endtimeBox.Location = new System.Drawing.Point(334, 316);
            this.endtimeBox.Name = "endtimeBox";
            this.endtimeBox.Size = new System.Drawing.Size(151, 25);
            this.endtimeBox.TabIndex = 24;
            // 
            // stateBox
            // 
            this.stateBox.Location = new System.Drawing.Point(334, 402);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(151, 25);
            this.stateBox.TabIndex = 25;
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ScheduleManagement.Properties.Resources.背景;
            this.Controls.Add(this.stateBox);
            this.Controls.Add(this.endtimeBox);
            this.Controls.Add(this.starttimeBox);
            this.Controls.Add(this.placeBox);
            this.Controls.Add(this.statelab);
            this.Controls.Add(this.endtimelab);
            this.Controls.Add(this.starttimelab);
            this.Controls.Add(this.placelab);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Name = "Schedule";
            this.Size = new System.Drawing.Size(501, 592);
            this.Load += new System.EventHandler(this.UserControl5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label placelab;
        private System.Windows.Forms.Label starttimelab;
        private System.Windows.Forms.Label endtimelab;
        private System.Windows.Forms.Label statelab;
        private System.Windows.Forms.TextBox placeBox;
        private System.Windows.Forms.TextBox starttimeBox;
        private System.Windows.Forms.TextBox endtimeBox;
        private System.Windows.Forms.TextBox stateBox;
    }
}
