namespace MarchingSquares;

public class PointValue : Point
{
  public bool Value { get; set; }

  public PointValue(int x, int y, bool value) :
    base(x, y)
  {
    Value = value;
  }
}
