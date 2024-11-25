namespace MarchingSquares;

using MathNet.Numerics.LinearAlgebra;

public struct PointValue : IEquatable<PointValue>, IFormattable
{
  private readonly Vector<float> _vector = Vector<float>.Build.Dense(2);

  public int X
  {
    get => (int) _vector[0];

    set => _vector[0] = value;
  }

  public int Y
  {
    get => (int) _vector[1];

    set => _vector[1] = value;
  }

  public bool Value { get; set; }

  public PointValue(int x, int y, bool value)
  {
    X = x;
    Y = y;
    Value = value;
  }

  public bool Equals(PointValue other)
  {
    throw new NotImplementedException();
  }

  public string ToString(string? format, IFormatProvider? formatProvider)
  {
    throw new NotImplementedException();
  }
}
