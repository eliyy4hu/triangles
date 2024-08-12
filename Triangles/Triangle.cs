namespace Triangles;

public struct Triangle
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public AngleType AngleType { get; }

    public Triangle(double a, double b, double c) : this()
    {
        if (new[] { a, b, c }.Any(x => x <= 0))
        {
            throw new ArgumentException(
                $"Triangle with side lengths {a}, {b}, {c} is invalid. All sides should have positive length");
        }

        if (!IsTriangleInequalityValid(a, b, c))
        {
            throw new ArgumentException(
                $"Triangle with side lengths {a}, {b}, {c} is invalid. The sum of any two lengths must be greater than the third");
        }

        A = a;
        B = b;
        C = c;
        AngleType = GetTriangleType();
    }

    private AngleType GetTriangleType()
    {
        var ordered = new[] { A, B, C }.OrderByDescending(x => x).ToArray();
        var maxSquare = Math.Pow(ordered[0], 2);
        var aSquare = Math.Pow(ordered[1], 2);
        var bSquare = Math.Pow(ordered[2], 2);

        return (aSquare + bSquare - maxSquare) switch
        {
            < 0 => AngleType.Obtuse,
            0 => AngleType.Rectangular,
            > 0 => AngleType.Acute,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static bool IsTriangleInequalityValid(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}

public enum AngleType
{
    Acute,
    Rectangular,
    Obtuse
}