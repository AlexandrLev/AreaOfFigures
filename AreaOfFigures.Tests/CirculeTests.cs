using Xunit;
using AreaOfFigures.Figures;
namespace AreaOfFigures.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ThrowArgumentExceptionTest(double a)
        {
            Assert.Throws<ArgumentException>(() => new Circle(a));
            Assert.Throws<ArgumentException>(() => Circle.CalculateArea(a));
        }

        [Fact]
        public void RightAreaResult()
        {
            // Data.
            double r = 1;
            var circule = new Circle(r);

            // Assert
            Assert.Equal(double.Pi, Circle.CalculateArea(r));
            Assert.Equal(double.Pi, circule.CalculateArea());
        }
    }
}
