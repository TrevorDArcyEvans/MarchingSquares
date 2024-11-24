﻿namespace MarchingSquares;

using System.Numerics;
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

    var Points = new Point[(int) MaxPoints.X, (int) MaxPoints.Y];
    for (var X = 0; X < MaxPoints.X; X++)
    {
      for (var Y = 0; Y < MaxPoints.Y; Y++)
      {
        var Value = Rng.CoinFlip() ? 1 : 0;
        Points[X, Y] = new Point(X * CellSize, Y * CellSize, Value);
      }
    }

    InitWindow((int) WindowSize.X, (int) WindowSize.Y, "Marching Squares");
    SetTargetFPS(60);

    while (!WindowShouldClose())
    {
      // Get Line Segments
      var LineSegments = MarchingSquares.Run(Points, 0, 0, (int) MaxPoints.X, (int) MaxPoints.Y);

      BeginDrawing();
      ClearBackground(Color.Black);

      // Draw Points
      foreach (var Point in Points)
      {
        Point.Draw();
      }

      // Draw Line Segments
      foreach (var Line in LineSegments)
      {
        DrawLineEx(Line.Item1 * CellSize, Line.Item2 * CellSize, 1.0f, Color.White);
      }

      EndDrawing();
    }
  }
}
