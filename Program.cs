namespace MarchingSquares;

using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

public static class Program
{
  public static void Main(string[] args)
  {
    var rng = new Rng();

    const int CellSize = 40;
    var WindowSize = new Vector2(1200, 800);
    var maxPoints = new Vector2(WindowSize.X / CellSize + 1, WindowSize.Y / CellSize + 1);

    var points = new Point[(int) (WindowSize.X / CellSize + 1), (int) (WindowSize.Y / CellSize + 1)];
    for (var x = 0; x < points.GetLength(0); x++)
    {
      for (var y = 0; y < points.GetLength(1); y++)
      {
        points[x, y] = new Point(x * CellSize, y * CellSize, rng.CoinFlip());
      }
    }

    InitWindow((int) WindowSize.X, (int) WindowSize.Y, "Marching Squares");
    SetTargetFPS(60);

    while (!WindowShouldClose())
    {
      // Get Line Segments
      var lineSegments = MarchingSquares.Run(points);

      BeginDrawing();
      ClearBackground(Color.Black);

      // Draw Points
      foreach (var point in points)
      {
        point.Draw();
      }

      // Draw Line Segments
      foreach (var line in lineSegments)
      {
        DrawLineEx(line.Item1 * CellSize, line.Item2 * CellSize, 1.0f, Color.White);
      }

      EndDrawing();
    }
  }
}
