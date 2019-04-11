using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Call_The_Roll
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    NameFiles.rollSpeed = Convert.ToInt32(this.textBox1.Text);
                    this.Close();
            }
            catch (Exception)
            {
                if (this.textBox1.Text != "")
                {
                    MessageBox.Show("只能输入大于0的整数！");
                    this.textBox1.Text = null;
                }
                else
                {
                    MessageBox.Show("请输入数值！");
                }
                //throw;
            }
        }
    }
}
