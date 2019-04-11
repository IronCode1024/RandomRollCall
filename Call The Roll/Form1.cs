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
    public partial class Form1 : Form
    {
        //定义IrisSkin皮肤引擎对象
        //Sunisoft.IrisSkin.SkinEngine skinEngine = null;

        public Form1()
        {
            InitializeComponent();
        }


        Random Rd = new Random();

        //窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "随机点名";
            //skinEngine = new Sunisoft.IrisSkin.SkinEngine();
            //skinEngine.SkinAllForm = true;
            //skinEngine.SkinFile = "ssk皮肤/Wave.ssk";

            this.richTextBox1.Visible = false;

            NameFiles.nameWay = "随机点名";
            this.label5.Visible = false;
        }

        //开始按钮单击事件
        private void button2_Click(object sender, EventArgs e)
        {
            //判断是否获取了txt文本，以及txt中是否有数据
            if (this.Text == "随机点名" || NameFiles.randomLength == 0)
            {
                this.label2.Text = "无数据";
                this.label2.ForeColor = Color.Red;
            }
            else
            {
                //设置开始按钮事件
                NameFiles.Judge = true;

                this.button2.Visible = false;
                this.button1.Visible = true;
            }
        }

        //暂停按钮单击事件
        private void button1_Click(object sender, EventArgs e)
        {
            //设置暂停按钮事件
            NameFiles.Judge = false;

            this.button1.Visible = false;
            this.button2.Visible = true;

            //根据用户选择的点名方式暂停显示不同的模式
            switch (NameFiles.nameWay)
            {
                case "不重复点名":
                    //判断label值是否为空，否则直接将值赋给下面的RichTextBox文本框
                    if (this.label2.Text == "")
                    {
                        int over = 0;//定义最大数据变量，当大于某个值时结束此次点名
                        do
                        {
                            NameFiles.randomNum = Rd.Next(0, NameFiles.randomLength);
                            if (NameFiles.name[NameFiles.randomNum] == "")
                            {
                                NameFiles.randomNum = Rd.Next(0, NameFiles.randomLength);
                            }
                            //将每次点名的值赋给label显示在界面上
                            this.label2.Text = NameFiles.name[NameFiles.randomNum];

                            over += 1;
                            //大于当前名单名时结束点名此类型
                            if (over > NameFiles.randomLength)
                            {
                                this.label2.Text = "结束";
                                return;
                            }

                        } while (this.label2.Text == "");
                        //记录每次点名的值，把当前点到的赋值给RichTextBox文本框，此次点名方式的下次不再点到此值
                        this.richTextBox1.Text += NameFiles.name[NameFiles.randomNum];
                        //并清空此条数组
                        NameFiles.name[NameFiles.randomNum] = "";

                    }
                    else
                    {
                        //记录每次点名的值，把当前点到的赋值给RichTextBox文本框，此次点名方式的下次不再点到此值
                        this.richTextBox1.Text += NameFiles.name[NameFiles.randomNum];
                        //并清空此条数组
                        NameFiles.name[NameFiles.randomNum] = "";

                    }
                    //获取已点人数
                    if (this.label2.Text != "结束")
                    {
                        NameFiles.knownNum += 1;
                        this.label5.Text = "已点人数：" + NameFiles.knownNum;
                    }
                    break;
            }
        }
        //计时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            //点名频率
            timer1.Interval = NameFiles.rollSpeed;
            //根据方式变量进入相应的case
            switch (NameFiles.nameWay)
            {
                case "随机点名":
                    //判断开始
                    if (NameFiles.Judge)
                    {
                        NameFiles.randomNum = Rd.Next(0, NameFiles.randomLength);
                        this.label2.Text = NameFiles.listName[NameFiles.randomNum];
                    }
                    break;
                case "不重复点名":
                    //判断开始
                    if (NameFiles.Judge)
                    {
                        NameFiles.randomNum = Rd.Next(0, NameFiles.randomLength);
                        if (NameFiles.name[NameFiles.randomNum] == "")
                        {
                            NameFiles.randomNum = Rd.Next(0, NameFiles.randomLength);
                        }
                        this.label2.Text = NameFiles.name[NameFiles.randomNum];
                    }
                    break;
            }
        }

        //随机点名
        private void button4_Click(object sender, EventArgs e)
        {
            this.label2.Text = "-- --";
            this.label5.Visible = false;
            //清空RichTextBox内容
            this.richTextBox1.Lines = null;
            this.richTextBox1.Visible = false;

            this.label5.Text = "已点人数：";
            NameFiles.knownNum = 0;
            NameFiles.nameWay = "随机点名";
            for (int j = 0; j < NameFiles.listName.Length; j++)
            {
                NameFiles.name[j] = NameFiles.listName[j];
            }
        }
        //不重复点名
        private void button3_Click(object sender, EventArgs e)
        {
            this.label5.Visible = true;
            this.richTextBox1.Visible = true;
            NameFiles.nameWay = "不重复点名";
        }
        //右键菜单“清除”单击事件
        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //清空RichTextBox内容
            this.richTextBox1.Lines = null;

            this.label2.Text = "-- --";
            this.label5.Text = "已点人数：";
            NameFiles.knownNum = 0;
            for (int j = 0; j < NameFiles.listName.Length; j++)
            {
                NameFiles.name[j] = NameFiles.listName[j];
            }
        }

        //选择名单，单击事件
        private void 选择名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string path;
            //path = NameFiles.name;
            //StreamReader sr = new StreamReader(NameFiles.name, System.Text.Encoding.UTF8);
            //string content;
            //while ((content = sr.ReadLine()) != null)
            //{
            //    //Console.WriteLine(content.ToString());
            //    this.label2.Text = content.ToString();
            //}
            //sr.Close();


            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();
            //过滤文件类型 默认显示.txt文件         
            fileDialog.Filter = "(*.txt)|*.txt";
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //清空RichTextBox内容
                this.richTextBox1.Lines = null;
                this.label2.Text = "-- --";
                this.label5.Text = "已点人数：";
                NameFiles.knownNum = 0;

                //清空数组内容
                for (int k = 0; k < NameFiles.listName.Length && k < NameFiles.name.Length; k++)
                {
                    NameFiles.listName[k] = null;
                    NameFiles.name[k] = null;
                }


                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名
                string[] str = new string[] { ".txt" };
                //判断用户打开的是否为指定文件
                if (!(str).Contains(extension))
                {
                    //弹出提示框
                    MessageBox.Show("仅能打开txt格式的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    //判断所选文件是否超过规定大小
                    if (fileInfo.Length > 20480)
                    {
                        MessageBox.Show("文件不能大于20K", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //this.richTextBox1.Text = File.ReadAllText(fileDialog.FileName, System.Text.Encoding.GetEncoding("gb2312"));
                        //显示当前名单文件路径到窗体标题
                        this.Text = "当前名单路径：" + fileDialog.FileName;
                        //将数据添加到名单数组


                        //定义一个变量
                        int lineCount = 0;
                        //文件路径
                        string path = fileDialog.FileName;
                        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("gb2312")))//编码格式为GBK：gb2312 
                        {
                            // 调用Array抽象类,提供的Resize方法重新动态调整数组大小
                            //Array.Resize<string>(ref NameFiles.listName, NameFiles.listName.Length + 11);
                            //Array.Resize<string>(ref NameFiles.name, NameFiles.name.Length + 11);

                            //循环读取txt文件中的每一行数据
                            while (sr.Peek() >= 0)
                            {
                                //sr.ReadLine()获取行数据
                                NameFiles.listName[lineCount] = sr.ReadLine() + "\n";
                                lineCount++;
                            }
                            //随机数最大值
                            NameFiles.randomLength = lineCount;

                            //this.label4.ForeColor = Color.Red;
                            this.label4.Text = "总人数：" + NameFiles.randomLength.ToString();
                        }
                        //将数组赋给另一个数组，用于不同的点名方式
                        for (int j = 0; j < NameFiles.listName.Length; j++)
                        {
                            NameFiles.name[j] = NameFiles.listName[j];
                        }
                    }
                }
                this.label2.ForeColor = Color.Blue;
            }
        }

        private void 录入名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        //设置
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = MessageBox.Show("确定要退出程序吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
 
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
