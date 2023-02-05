using ClassLibrary;
using System.Text;

namespace Ср2
{
    public class Program
    {
        static void Main(string[] args)
        {
            double n, m;
            int flag = 0;
            bool check;
            bool checkName, checkExistence;
            do
            {
                try
                {
                    /// Предложения по улучшению программы.
                    /// Можно улучшить меню, разделив первый пункт на несколько. А именно создать отдельный пункт для установки пути файла и отдельный для фильтрации фигур.
                    do
                    {
                        Console.WriteLine("МЕНЮ\nВведите:\n-1, чтобы завершить программу\n1, чтобы ввести название файла, праметры N и M  и отфильтровать файл\n" +
                            "2, чтобы вывести в консоль информацию обо всех фигурах в файле.\n");
                        check = !int.TryParse(Console.ReadLine(), out flag) || (flag != -1 && flag != 1 && flag != 2);
                        Console.WriteLine();
                        if (check)
                            Console.WriteLine("Введено неверное значение. Повторите ввод.\n");
                        else if (flag == -1)
                            return;
                        else if(flag == 2)
                            FigureProcessing.PrintInfo();
                    }
                    while (check);
                    if (flag == 1)
                    {
                        do
                        {
                            Console.WriteLine("Введите полное название файла с исходными данными.\n");
                            string name = Console.ReadLine();
                            Console.WriteLine();
                            FileWork.FileName = name;
                            checkName = FileWork.CheckFileName();
                            checkExistence = FileWork.CheckFileExistence();
                        }
                        while (!checkExistence || !checkName);
                        /// Предложение по улучшению программы.
                        /// Можно реализовать отдельные циклы do-while для значения N и M, чтобы при одном ошибочном значении пользователю не приходилось 
                        /// повторно воодить 2 значения.
                        do
                        {
                            Console.WriteLine("Введите 2 значения в отдельных строках: N и M(для фильтрации файла).\n");
                        }
                        while (!double.TryParse(Console.ReadLine(), out n) | !double.TryParse(Console.ReadLine(), out m));
                        FileWork.ReadFile(n, m);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(NoFileNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(EmptyFileException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (flag != -1);
        }
    }
}
