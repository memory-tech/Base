using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clawNBA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string mylove;
        //保存下关注的球队
        public void button1_Click(object sender, EventArgs e)
        {
            mylove = textBox1.Text;
        }
}
