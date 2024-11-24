namespace MarchingSquares;

using Raylib_cs;

public static class PointExtensions
{
  public static void Draw(this PointValue pt)
  {
    var C = pt.Value ? Color.White : Color.DarkGray;
    Raylib.DrawCircleLines(pt.X, pt.Y, 1.0f, C);
  }
}
