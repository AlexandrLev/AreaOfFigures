using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures.Interfaces
{
    /// <summary>
    ///  Интерфейс фигуры
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        ///  Вычислить площадь фигуры
        /// </summary>
        public double CalculateArea();
    }
}
