using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace MarchingSquares;

class Point
{
  public int X { get; set; }
  public int Y { get; set; }
  public int Value { get; set; }

  public Point(int x, int y, int value)
  {
    X = x;
    Y = y;
    Value = value;
  }

  public void Draw()
  {
    var C = Value > 0 ? Color.White : Color.DarkGray;
    DrawCircleLines(X, Y, 1.0f, C);
  }
}
