using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace MarchingSquares;

class Program {
    static void Main(string[] args) {
        var RNG = new RNG();

        var CellSize = 40;
        var WindowSize = new Vector2(1200, 800);
        var MaxPoints = new Vector2(WindowSize.X / CellSize + 1, WindowSize.Y / CellSize + 1);

        var Points = new Point[(int)MaxPoints.X, (int)MaxPoints.Y];
        for (int x = 0; x < MaxPoints.X; x++) {
            for (int y = 0; y < MaxPoints.Y; y++) {
                var Value = RNG.CoinFlip() ? 1 : 0;
                Points[x, y] = new Point(x * CellSize, y * CellSize, Value);
            }
        }

        InitWindow((int)WindowSize.X, (int)WindowSize.Y, "Marching Squares");
        SetTargetFPS(60);

        while (!WindowShouldClose()) {
            // Get Line Segments
            var LineSegments = MarchingSquares.Run(Points, CellSize, 0, 0, (int)MaxPoints.X, (int)MaxPoints.Y);

            BeginDrawing();
            ClearBackground(Color.BLACK);

            // Draw Points
            foreach (var Point in Points) {
                Point.Draw();
            }

            // Draw Line Segments
            foreach (var Line in LineSegments) {
                DrawLineEx(Line.Item1 * CellSize, Line.Item2 * CellSize, 1.0f, Color.WHITE);
            }

            EndDrawing();
        }
    }
}
