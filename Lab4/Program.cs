using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Шлях не знайдено");
                return -1;
            }
            else if (args.Length == 1 && args[0] == "help")
            {
                Console.WriteLine("Введiть шлях, атрибут файлiв(H - для hidden, A - для archive, R - для read-only)" +
                "\n та шаблон файлу (наприклад: *.exe) як параметри утiлiти" + 
                "\n Вводити наступним чином: {шлях} -{аргументи} {шаблон}");
                return 0;
            }
            try
            {
                string fileAttr = "";
                int extStart = 1;
                int count = 0;

                if (args.Length > 1 && args[1].Contains('-'))
                {
                    fileAttr = args[1];
                    extStart = 2;
                }

                if (args.Length == extStart)
                {
                    string[] fileFirst = Directory.GetFiles(args[0]);
                    foreach (string file in fileFirst)
                    {
                        if (fileAttr.Length == 0)
                            count++;
                        else if (fileAttr.Contains('H') &&
                            (File.GetAttributes(file) & FileAttributes.Hidden) == FileAttributes.Hidden)
                            count++;
                        else if (fileAttr.Contains('R') &&
                            (File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                            count++;
                        else if (fileAttr.Contains('A') &&
                            (File.GetAttributes(file) & FileAttributes.Archive) == FileAttributes.Archive)
                            count++;
                    }
                    Console.WriteLine("Файлiв в каталозi: " + args[0] + " = " + count);
                }
                else if (!args[1].Contains('-'))
                {
                    extStart = 1;
                    for (int i = extStart; i < args.Length; i++)
                    {
                        string[] fileFirst = Directory.GetFiles(args[0], args[i]);
                        foreach (string file in fileFirst)
                        {
                            count++;
                        }
                        Console.WriteLine("Файлiв в каталозi: " + args[0] + " = " + count);
                    }
                }
                else
                {
                    extStart = 2;
                    for (int i = extStart; i < args.Length; i++)
                    {
                        string[] fileFirst = Directory.GetFiles(args[0], args[i]);
                        foreach (string file in fileFirst)
                        {
                            if (fileAttr.Length == 0)
                                count++;
                            else if (fileAttr.Contains('H') &&
                                (File.GetAttributes(file) & FileAttributes.Hidden) == FileAttributes.Hidden)
                                count++;
                            else if (fileAttr.Contains('R') &&
                                (File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                count++;
                            else if (fileAttr.Contains('A') &&
                                (File.GetAttributes(file) & FileAttributes.Archive) == FileAttributes.Archive)
                                count++;
                        }
                        Console.WriteLine("Файлiв в каталозi: " + args[0] + " = " + count);
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message + "\n");
                return -2;
            }
        }
    }
}
