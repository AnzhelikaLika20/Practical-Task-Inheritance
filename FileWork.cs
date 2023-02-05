using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для работы с файловой системой.
    /// </summary>
    public static class FileWork
    {
        static string[] lines;
        public static string[] Lines { get { return lines; } }
        public static string FileName { get; set; }
        /// <summary>
        /// Проверка корректности расширения файла. Оно должно быть .txt(файл текстовый).
        /// </summary>
        /// <returns>Значение bool</returns>
        public static bool CheckFileName()
        {
            if (Path.GetExtension(FileName) != ".txt")
            {
                Console.WriteLine("Некорректное расширение файла. Повторите ввод.\n");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка существования файла в директории с исполняемым файлом.
        /// </summary>
        /// <returns>Значение bool</returns>
        public static bool CheckFileExistence()
        {
            if(!File.Exists(FileName))
            {
                Console.WriteLine("В директории с исполняемым файлом не найден файл с данным названием.\n");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Метод для чтения файла.
        /// </summary>
        /// <param name="n">Если площадь фигуры больше этого значения, то данные о ней будут записаны в файл.</param>
        /// <param name="m">Если плотность фигуры больше этого значения, то данные о ней будут записаны в файл.</param>
        public static void ReadFile(double n, double m)
        {
            lines = File.ReadAllLines(FileName);
            FigureProcessing.DefineFigure(n, m);
        }
        /// <summary>
        /// Метод для записи обработанных данных в файлы.
        /// </summary>
        /// <param name="n">Если площадь фигуры больше этого значения, то данные о ней будут записаны в файл.</param>
        /// <param name="m">Если плотность фигуры больше этого значения, то данные о ней будут записаны в файл.</param>
        public static void WriteFile(double n, double m)
        {
            ///Разрешение доступа к кодировкам, не поддерживаемым на текущей платформе платформа .NET Framework.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            File.WriteAllText("TriangleArea.txt", "");
            File.WriteAllText("SquareConditionalDensity.txt", "");
            for (int i = 0; i < FigureProcessing.Figures.Count(); i++)
            {
                var figure = FigureProcessing.Figures[i];
                ///Запись в файл в кодировке Windows-1251.
                if (figure is EqTriangle && figure.Area > n)
                    File.AppendAllText("TriangleArea.txt", figure.ToString() + "\n", Encoding.GetEncoding(1251));
                if(figure is Square && figure.ConditionalDensity > m)
                    File.AppendAllText("SquareConditionalDensity.txt", figure.ToString() + "\n", Encoding.GetEncoding(1251));
            }
            Console.WriteLine("Обработанные данные записаны в файлы TriangleArea.txt и SquareConditionalDensity.txt.\n");
        }
    }
}
