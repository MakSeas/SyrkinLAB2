using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrk2LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбор пути:\n " +
                "0 - Ввести путь вручную\n" +
                "1 - Продолжить путь с C:\\Users\\koshm\\OneDrive\\ \n" +
                "2 - Сохранить на рабочий стол\n");

            int act=int.Parse(Console.ReadLine());

            string path="";

            switch (act) 
            {
                case 0:
                    {
                        path = Console.ReadLine();
                    }break;
                case 1:
                    {
                        Console.Write("C:\\Users\\koshm\\OneDrive\\");
                        path= "C:\\Users\\koshm\\OneDrive\\"+Console.ReadLine();
                    }break;
                case 2:
                    {
                        path = "C:\\Users\\koshm\\OneDrive\\Desktop\\";
                    }
                    break;
                default: break;
            }

            Console.WriteLine($"Выбран путь {path}\n");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.Write("Имя txt файла: ");
            string name = Console.ReadLine();

            path += $"{name}.txt";

            Console.WriteLine("Выбор кодировки:\n " +
                "0 - UTF-8\n" +
                "1 - Win1251\n" +
                "2 - DOC 866\n");

            act = int.Parse(Console.ReadLine());

            TextWriter textWriter=null;



            switch (act)
            {
                case 0:
                    {
                        textWriter = SetEncoding(path, Encoding.UTF8);
                    }
                    break;
                case 1:
                    {
                        textWriter = SetEncoding(path, Encoding.GetEncoding(1251));
                        // textWriter = SetEncoding(path, Encoding.Win1251);
                    }
                    break;
                case 2:
                    {
                        textWriter = SetEncoding(path, Encoding.GetEncoding(866));
                        // textWriter = SetEncoding(path, Encoding.DOC866);
                    }
                    break;
                default: break;
            }

            

            Console.Write("Текст, который будет отображен в txt файле: ");
            string text = Console.ReadLine();

            textWriter.WriteLine(text);

            textWriter.Close();
        }

        static TextWriter SetEncoding(string path, Encoding encoding)
        {
            return new StreamWriter(path, true, encoding); ;
        }
    }
}
