namespace MarchingSquares;

public class Point
{
  public int X { get; set; }
  public int Y { get; set; }
  public bool Value { get; set; }

  public Point(int x, int y, bool value)
  {
    X = x;
    Y = y;
    Value = value;
  }
}
