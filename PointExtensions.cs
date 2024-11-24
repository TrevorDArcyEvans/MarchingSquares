namespace MarchingSquares;

using Raylib_cs;

public static class PointExtensions
{
  public static void Draw(this Point pt)
  {
    var C = pt.Value > 0 ? Color.White : Color.DarkGray;
    Raylib.DrawCircleLines(pt.X, pt.Y, 1.0f, C);
  }
}
