﻿
namespace ScheduleManagement
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.TimeSet = new System.Windows.Forms.Label();
            this.BreakSet = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRemindStyle = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(91, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "番茄时长:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(260, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "休息时长:";
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.Transparent;
            this.btnBegin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin.Location = new System.Drawing.Point(71, 266);
            this.btnBegin.Margin = new System.Windows.Forms.Padding(4);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(108, 44);
            this.btnBegin.TabIndex = 8;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.Location = new System.Drawing.Point(276, 266);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(113, 44);
            this.btnEnd.TabIndex = 9;
            this.btnEnd.Text = "结束";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // TimeSet
            // 
            this.TimeSet.AutoSize = true;
            this.TimeSet.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeSet.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.TimeSet.Location = new System.Drawing.Point(81, 75);
            this.TimeSet.Name = "TimeSet";
            this.TimeSet.Size = new System.Drawing.Size(122, 40);
            this.TimeSet.TabIndex = 10;
            this.TimeSet.Text = "15:00";
            // 
            // BreakSet
            // 
            this.BreakSet.AutoSize = true;
            this.BreakSet.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BreakSet.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.BreakSet.Location = new System.Drawing.Point(257, 75);
            this.BreakSet.Name = "BreakSet";
            this.BreakSet.Size = new System.Drawing.Size(122, 40);
            this.BreakSet.TabIndex = 11;
            this.BreakSet.Text = "05:00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.cmbRemindStyle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BreakSet);
            this.panel1.Controls.Add(this.TimeSet);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 192);
            this.panel1.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(485, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "提醒方式";
            // 
            // cmbRemindStyle
            // 
            this.cmbRemindStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemindStyle.FormattingEnabled = true;
            this.cmbRemindStyle.Items.AddRange(new object[] {
            "响铃",
            "震动",
            "响铃且震动"});
            this.cmbRemindStyle.Location = new System.Drawing.Point(242, 147);
            this.cmbRemindStyle.Name = "cmbRemindStyle";
            this.cmbRemindStyle.Size = new System.Drawing.Size(121, 23);
            this.cmbRemindStyle.TabIndex = 14;
            // 
            // Tomato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ScheduleManagement.Properties.Resources.背景;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Tomato";
            this.Size = new System.Drawing.Size(485, 375);
            this.Load += new System.EventHandler(this.Tomato_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label TimeSet;
        private System.Windows.Forms.Label BreakSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbRemindStyle;
        private System.Windows.Forms.Label label5;
    }
}