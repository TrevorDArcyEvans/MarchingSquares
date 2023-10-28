using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace MarchingSquares;

class Point {
    public int X { get; set; }
    public int Y { get; set; }
    public double Value { get; set; }
    public int State { get; set; } = 0;

    public Point(int x, int y, double value) {
        X = x;
        Y = y;
        Value = value;
    }

    public void Draw() {
        var C = Value > 0 ? Color.WHITE : Color.BLACK;
        DrawCircleLines(X, Y, 1.0f, C);
    }
}