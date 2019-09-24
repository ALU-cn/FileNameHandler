using System;
using System.IO;


namespace AlterName
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = Environment.CurrentDirectory;
            string[] files = Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly);
            Console.WriteLine("当前目录为" + dir);
            Console.WriteLine("找到" + files.Length + "个文件");
            Console.WriteLine("请输入要替换的字符：");
            string replaceNameInput = Console.ReadLine();
            Console.WriteLine("将以上字符替换为：（或直接按回车删除以上字符）");
            string newNameInput = Console.ReadLine();

            int replacedNum = 0;
            foreach (string str in files)
            {
                string currentName = Path.GetFileNameWithoutExtension(str);
                if (currentName.Contains(replaceNameInput))
                {
                    string newName = currentName.Replace(replaceNameInput, newNameInput);
                    File.Move(str, Path.GetDirectoryName(str) + "\\" + newName + Path.GetExtension(str));
                    replacedNum++;
                }
                else
                {
                    Console.WriteLine(currentName + "这个文件名不包含" + newNameInput);
                }

            }

            Console.WriteLine("修改完了" + replacedNum + "个，按任意键退出");
            Console.ReadKey();
        }
    }
}
