using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Класс квадрата.
    /// </summary>
    public class Square : Figure
    {
        /// <summary>
        /// Свойство возвращает площадь фигуры.
        /// </summary>
        public override double Area
        {
            get
            {
                return a * a;
            }
        }
        public Square(double a, int m = 1) : base(4, m)
        {
            if (a < 0 || m < 0)
                throw new ArgumentException("Параметры квадрата не могут быть отрицательными.\n");
            this.a = a;
        }
        public override string ToString()
        {
            return this.GetType().ToString()[13..] + $" {a} {M} {Area:f2} {ConditionalDensity:f2}";
        }
    }
}
