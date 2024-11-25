namespace MarchingSquares;

using MathNet.Numerics.LinearAlgebra;

public struct Vector2
{
  private readonly Vector<float> _vector= Vector<float>.Build.Dense(2);

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

  public Vector2(int x, int y)
  {
    X = x;
    Y = y;
  }

  public Vector2(float x, float y)
  {
    _vector[0] = x;
    _vector[1] = y;
  }
}
