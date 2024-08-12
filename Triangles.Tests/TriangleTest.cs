using FluentAssertions;

namespace Triangles.Tests;

public class TriangleTest
{
    [TestCase(1, 1, 0)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, -1)]
    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    public void Constructor_ShouldThrow_IfSidesHasNotPositiveLength(double a, double b, double c)
    {
        Action x = () => new Triangle(a, b, c);
        x.Should().Throw<ArgumentException>()
            .WithMessage($"Triangle with side lengths {a}, {b}, {c} is invalid. All sides should have positive length");
    }

    [TestCase(1, 1, 3)]
    [TestCase(3, 1, 1)]
    [TestCase(1, 3, 1)]
    public void Constructor_ShouldThrow_IfSidesDoesNotSatisfyTriangleInequality(double a, double b, double c)
    {
        Action x = () => new Triangle(a, b, c);
        x.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Triangle with side lengths {a}, {b}, {c} is invalid. The sum of any two lengths must be greater than the third");
    }

    [TestCase(2, 3, 4)]
    [TestCase(2, 4, 3)]
    [TestCase(3, 4, 2)]
    [TestCase(3, 2, 4)]
    [TestCase(4, 2, 3)]
    [TestCase(4, 3, 2)]
    public void AngleType_Obtuse(double a, double b, double c)
    {
        new Triangle(a, b, c).AngleType.Should().Be(AngleType.Obtuse);
    }

    [TestCase(3, 4, 5)]
    [TestCase(3, 5, 4)]
    [TestCase(4, 3, 5)]
    [TestCase(4, 5, 3)]
    [TestCase(5, 4, 3)]
    [TestCase(5, 3, 4)]
    public void AngleType_Rectangular(double a, double b, double c)
    {
        new Triangle(a, b, c).AngleType.Should().Be(AngleType.Rectangular);
    }

    [TestCase(6, 7, 8)]
    [TestCase(6, 8, 7)]
    [TestCase(7, 6, 8)]
    [TestCase(7, 8, 6)]
    [TestCase(8, 7, 6)]
    [TestCase(8, 6, 7)]
    public void AngleType_Acute(double a, double b, double c)
    {
        new Triangle(a, b, c).AngleType.Should().Be(AngleType.Acute);
    }
}