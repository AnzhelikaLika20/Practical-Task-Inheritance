using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Класс правильного треугольника.
    /// </summary>
    public class EqTriangle : Figure
    {
        public EqTriangle(double a, int m = 1) : base(3, m)
        {
            if (a < 0 || m < 0)
                throw new ArgumentException("Параметры треугольника не могут быть отрицательными.\n");
            base.a = a;
        }
        /// <summary>
        /// Свойство возвращает площадь фигуры.
        /// </summary>
        public override double Area
        {
            get
            {
                return a * a * Math.Sqrt(3) / 4;
            }
        }
        public override string ToString()
        {
            return this.GetType().ToString()[13..] + $" {a} {M} {Area:f2} {ConditionalDensity:f2}";
        }
    }
}
