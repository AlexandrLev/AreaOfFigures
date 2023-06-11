using Xunit;
using AreaOfFigures.Figures;
namespace AreaOfFigures.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 0, 0)]
        public void ThrowArgumentExceptionTest(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            Assert.Throws<ArgumentException>(() => Triangle.CalculateArea(a, b, c));
        }
        [Fact]
        public void InitNotTriangleTest()
        {
            // Data.
            double a = 5d, b = 1d, c = 1d;

            // Assert
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            Assert.Throws<ArgumentException>(() => Triangle.CalculateArea(a, b, c));
        }

        [Fact]
        public void RightAreaResult()
        {
            // Data.
            double a = 3d, b = 4d, c = 5d;
            var triangle = new Triangle(a, b, c);

            // Assert
            Assert.Throws<OverflowException>(() => Triangle.CalculateArea(double.MaxValue, double.MaxValue, double.MaxValue));
            Assert.Equal(6d, Triangle.CalculateArea(a, b, c));
            Assert.Equal(6d, triangle.CalculateArea());
        }

        [Fact]
        public void GetIsRightTriangleTest()
        {
            Assert.False(Triangle.GetIsRightTriangle(2, 3, 4));
            Assert.True(Triangle.GetIsRightTriangle(3, 4, 5));
        }
    }
}
