namespace ClassLibrary
{
    public class Figure
    {
        /// <summary>
        /// Класс квадрата.
        /// </summary>
        int n, m;
        int N { get { return n; } }
        public int M { get { return m; } }
        public double a { get; set; }
        public virtual double Area { get { return 0; } }
        /// <summary>
        /// Свойство возвращает плотность фигуры.
        /// </summary>
        public double ConditionalDensity 
        { 
            get 
            {
                if (Area == 0)
                {
                    Console.WriteLine("Area is 0");
                    throw new DivideByZeroException();
                }    
                return m / Area; 
            } 
        }
        public Figure(int n, int m = 1)
        {
            if (n < 0 || m < 0)
                throw new ArgumentException("Параметры фигуры не могут быть отрицательными.\n");
            this.m = m;
            this.n = n;
        }
        public override string ToString()
        {
            return this.GetType().ToString()[13..] + $" {Area:f2} {ConditionalDensity:f2}";
        }
    }
}