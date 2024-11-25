namespace MarchingSquares;

using MathNet.Numerics.LinearAlgebra;
using Raylib_cs;
using static Raylib_cs.Raylib;

public static class Program
{
  public static void Main(string[] args)
  {
    var Rng = new Rng();

    const int CellSize = 40;
    var WindowSize = new Vector2(1200, 800);
    var MaxPoints = new Vector2(WindowSize.X / CellSize + 1, WindowSize.Y / CellSize + 1);

    var Points = Matrix<PointValue>.Build.Dense((int) (WindowSize.X / CellSize) + 1, (int) (WindowSize.Y / CellSize) + 1);
    for (var X = 0; X < Points.RowCount; X++)
    {
      for (var Y = 0; Y < Points.ColumnCount; Y++)
      {
        Points[X, Y] = new PointValue(X * CellSize, Y * CellSize, Rng.CoinFlip());
      }
    }

    InitWindow((int) WindowSize.X, (int) WindowSize.Y, "Marching Squares");
    SetTargetFPS(60);

    while (!WindowShouldClose())
    {
      // Get Line Segments
      var LineSegments = MarchingSquares.Run(Points);

      BeginDrawing();
      ClearBackground(Color.Black);

      // Draw Points
      for (var X = 0; X < Points.RowCount; X++)
      {
        for (var Y = 0; Y < Points.ColumnCount; Y++)
        {
          Points[X, Y].Draw();
        }
      }

      // Draw Line Segments
      foreach (var Line in LineSegments)
      {
        var x1 = Line.Item1.X * CellSize;
        var y1 = Line.Item1.Y * CellSize;
        var x2 = Line.Item2.X * CellSize;
        var y2 = Line.Item2.Y * CellSize;
        DrawLine(x1, y1, x2, y2, Color.White);
      }

      EndDrawing();
    }
  }
}
