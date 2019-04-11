using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Call_The_Roll
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //保存按钮单击事件
        private void button1_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = File.Create.Text();

            // 利用SaveFileDialog，让用户指定文件的路径名
            //SaveFileDialog saveDlg = new SaveFileDialog();
            //saveDlg.Filter = "文本文件.txt";
            //if (saveDlg.ShowDialog() == DialogResult.OK)
            //{
            //    // 创建文件，将textBox1中的内容保存到文件中
            //    // saveDlg.FileName 是用户指定的文件路径
            //    FileStream fs = File.Open(saveDlg.FileName,
            //        FileMode.Create,
            //        FileAccess.Write);
            //    StreamWriter sw = new StreamWriter(fs);
            //    // 保存textBox1中所有内容（所有行）
            //    foreach (string line in richTextBox1.Lines)
            //    {
            //        sw.WriteLine(line);
            //    }
            //    //关闭文件
            //    sw.Flush();
            //    sw.Close();
            //    fs.Close();
            //    // 提示用户：文件保存的位置和文件名
            //    MessageBox.Show("文件已成功保存到" + saveDlg.FileName);

            //}



            if (this.richTextBox1.Text == "")
            {
                MessageBox.Show("请输入内容！");
                return;
            }
            // 利用SaveFileDialog，让用户指定文件的路径名
            SaveFileDialog saveDlg = new SaveFileDialog();
            
            //saveDlg.DefaultExt = "txt";
            //指定文件类型
            saveDlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //判断用户是否点击确定保存
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                // saveDlg.FileName 是用户指定的文件路径
                 //Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveDlg.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("文件已成功保存到：" + saveDlg.FileName);
            }
        }
        //取消按钮单击事件
        private void button2_Click(object sender, EventArgs e)
        {
            //清空文本框
            this.richTextBox1.Text =null;
        }

    }
}
