using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для обработки фигур в зависимости от их типа.
    /// </summary>
    public class FigureProcessing
    {
        static List<Figure> figures;
        public static List<Figure> Figures{ get { return figures; } }

        ///ДОПОЛНИТЕЛЬНЫЙ ФУНКЦИОНАЛ
        /// <summary>
        /// Вывод информации обо всех фигурах на экран.
        /// </summary>
        /// <exception cref="NoFileNameException">Исключение возникает если ранее не было введено имя файла.</exception>
        public static void PrintInfo()
        {
            if (figures == null)
                throw new NoFileNameException();
            for (int i = 0; i < figures.Count; i++)
                Console.WriteLine(figures[i]);
            Console.WriteLine();
        }

        /// <summary>
        /// Определение типа фигуры по названию в файле и добавление её в лист с фигурами.
        /// </summary>
        /// <param name="n">Если площадь фигуры больше этого значения, то данные о ней будут записаны в файл.</param>
        /// <param name="m">Если плотность фигуры больше этого значения, то данные о ней будут записаны в файл.</param>
        public static void DefineFigure(double n, double m)
        {
            double side;
            int weight;
            figures = new List<Figure>();
            try
            {
                for (int i = 0; i < FileWork.Lines.Length; i++)
                {
                    string[] line = FileWork.Lines[i].Split();
                    if (line.Length == 3 && double.TryParse(line[1], out side) && int.TryParse(line[2], out weight))
                    {
                        if (line[0] == "Square")
                            figures.Add(new Square(side, weight));
                        else if (line[0] == "EqTriangle")
                            figures.Add(new EqTriangle(side, weight));
                        else
                            Console.WriteLine($"Некорректный тип фигуры в {i + 1} строке.\n");
                    }
                    else if (line.Length == 2 && double.TryParse(line[1], out side))
                    {
                        if (line[0] == "Square")
                            figures.Add(new Square(side));
                        else if (line[0] == "EqTriangle")
                            figures.Add(new EqTriangle(side));
                        else
                            Console.WriteLine($"Некорректный тип фигуры в {i + 1} строке файла.\n");
                    }
                    else
                        Console.WriteLine($"Некороректный формат данных в {i + 1} строке файла.\n");
                }
                if (FileWork.Lines.Length != 0)
                    FileWork.WriteFile(n, m);
                else
                    throw new EmptyFileException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }    
        }
    }
}
