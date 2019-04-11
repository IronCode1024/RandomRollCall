using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Call_The_Roll
{
    class NameFiles
    {
        //定义已点人数变量
        public static int knownNum;

        //通过打开的文件数据，获取随机数和数组长度
        public static int randomLength = 0;

        //判断是否开始点名
        public static bool Judge = false;

        //listName数组：用于储存来自txt的文本文件（随机点名）
        public static string[] listName = new string[500];

        //name数组：通过遍历listName数组储存不同玩法的名单（不重复点名）
        public static string[] name = new string[500];

        //产生指定范围内的随机数变量
        public static int randomNum;

        //点名方式
        public static string nameWay;

        //设置点名频率变量
        public static int rollSpeed = 10;
    }
}
