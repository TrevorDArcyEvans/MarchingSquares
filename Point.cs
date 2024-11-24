namespace MarchingSquares;

using MathNet.Numerics.LinearAlgebra;

public class Point
{
  private readonly Vector<Single> _vector;

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

  public Point(int x, int y)
  {
    _vector = Vector<float>.Build.Dense(2);
    X = x;
    Y = y;
  }
}
