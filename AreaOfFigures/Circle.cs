using AreaOfFigures.Interfaces;

namespace AreaOfFigures.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get; set; }

        /// <inheritdoc /> 
        public double CalculateArea()
        {
            double result = double.Pi * Math.Pow(this.Radius, 2);
            if(result == double.PositiveInfinity) throw new OverflowException("Слишком большой радиус");
            return result;
        }

        /// <summary>
        ///  Вычислить площадь круга по радиусу
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public static double CalculateArea(double radius)
        {
            CheckCircleArguments(radius);
            double result = double.Pi * Math.Pow(radius, 2);
            if (result == double.PositiveInfinity) throw new OverflowException("Слишком большой радиус");
            return result;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius)
        {
            CheckCircleArguments(radius);
            this.Radius = radius;
        }

        /// <summary>
        /// Проверка правильности передачи параметров круга
        /// </summary>
        /// <param name="radius">Радус</param>
        private static void CheckCircleArguments(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Неверно указан радиус.", nameof(radius));
        }
    }
}
