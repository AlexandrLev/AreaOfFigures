using AreaOfFigures.Interfaces;

namespace AreaOfFigures.Figures
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// Сторона треугольника - A
        /// </summary>
        public double EdgeA { get; set; }
        /// <summary>
        /// Сторона треугольника - A
        /// </summary>
        public double EdgeB { get; set; }
        /// <summary>
        /// Сторона треугольника - C
        /// </summary>
        public double EdgeC { get; set; }

        /// <inheritdoc /> 
        public double CalculateArea()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2d;
            double result = Math.Sqrt(
                halfP
                * (halfP - EdgeA)
                * (halfP - EdgeB)
                * (halfP - EdgeC)
            );
            if (result == double.PositiveInfinity) throw new OverflowException("Слишком большой результат");
            return result;
        }

        /// <summary>
        /// Вычислить площадь треугольника по трем сторонам (Формула Герона)
        /// </summary>
        /// <param name="edgeA">Сторона треугольника - A</param>
        /// <param name="edgeB">Сторона треугольника - B</param>
        /// <param name="edgeC">Сторона треугольника - C</param>
        public static double CalculateArea(double edgeA, double edgeB, double edgeC)
        {
            CheckTriangleArguments(edgeA, edgeB, edgeC);
            var halfP = (edgeA + edgeB + edgeC) / 2d;
            double result = Math.Sqrt(
                halfP
                * (halfP - edgeA)
                * (halfP - edgeB)
                * (halfP - edgeC)
            );
            if (result == double.PositiveInfinity) throw new OverflowException("Слишком большой результат");
            return result;
        }

        /// <summary>
        /// Проверка на прямоугольность треугольника
        /// </summary>
        /// <param name="edgeA">Сторона треугольника - A</param>
        /// <param name="edgeB">Сторона треугольника - B</param>
        /// <param name="edgeC">Сторона треугольника - C</param>
        public static bool GetIsRightTriangle(double edgeA, double edgeB, double edgeC)
        {
            CheckTriangleArguments(edgeA, edgeB, edgeC);
            if (edgeA * edgeA + edgeB * edgeB == edgeC * edgeC || edgeA * edgeA + edgeC * edgeC == edgeB * edgeB || edgeB * edgeB + edgeC * edgeC == edgeA * edgeA)
                return true;
            return false;
        }

        /// <summary>
        /// Проверка на прямоугольность треугольника
        /// </summary>
        public bool GetIsRightTriangle()
        {
            return GetIsRightTriangle(this.EdgeA, this.EdgeB, this.EdgeC);
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="edgeA">Сторона треугольника - A</param>
        /// <param name="edgeB">Сторона треугольника - B</param>
        /// <param name="edgeC">Сторона треугольника - C</param>
        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            CheckTriangleArguments(edgeA, edgeB, edgeC);
            this.EdgeA = edgeA;
            this.EdgeB = edgeB;
            this.EdgeC = edgeC;
        }

        /// <summary>
        /// Проверка правильности передачи параметров треугольника
        /// </summary>
        /// <param name="edgeA">Сторона треугольника - A</param>
        /// <param name="edgeB">Сторона треугольника - B</param>
        /// <param name="edgeC">Сторона треугольника - C</param>
        private static void CheckTriangleArguments(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA <= 0)
                throw new ArgumentException("Неверно указана сторона.", nameof(edgeA));

            if (edgeB <= 0)
                throw new ArgumentException("Неверно указана сторона.", nameof(edgeB));

            if (edgeC <= 0)
                throw new ArgumentException("Неверно указана сторона.", nameof(edgeC));

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if (2 * maxEdge - perimeter > 0)
                throw new ArgumentException("Наибольшая сторона треугольника должна быть меньше суммы других сторон");
        }
    }
}
