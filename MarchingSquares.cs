using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace MarchingSquares;

static class MarchingSquares {

    // Run the marching squares algorithm on the given list
    public static void Run(Point[,] Points, int S, int X1, int Y1, int X2, int Y2) {
        for (int x = X1; x < X2 - 1; x++) {
            for (int y = Y1; y < Y2 - 1; y++) {
                var A = new Vector2(x + 0.5f, y);
                var B = new Vector2(x + 1, y + 0.5f);
                var C = new Vector2(x + 0.5f, y + 1);
                var D = new Vector2(x, y + 0.5f);

                var State = GetState(
                    Points[x, y].Value,
                    Points[x + 1, y].Value,
                    Points[x + 1, y + 1].Value,
                    Points[x, y + 1].Value
                );

                switch (State) {
                    case 1:
                        DrawLine(D, C, S);
                        break;
                    case 2:
                        DrawLine(C, B, S);
                        break;
                    case 3:
                        DrawLine(D, B, S);
                        break;
                    case 4:
                        DrawLine(A, B, S);
                        break;
                    case 5:
                        DrawLine(D, A, S);
                        DrawLine(C, B, S);
                        break;
                    case 6:
                        DrawLine(A, C, S);
                        break;
                    case 7:
                        DrawLine(D, A, S);
                        break;
                    case 8:
                        DrawLine(D, A, S);
                        break;
                    case 9:
                        DrawLine(C, A, S);
                        break;
                    case 10:
                        DrawLine(D, C, S);
                        DrawLine(A, B, S);
                        break;
                    case 11:
                        DrawLine(A, B, S);
                        break;
                    case 12:
                        DrawLine(D, B, S);
                        break;
                    case 13:
                        DrawLine(C, B, S);
                        break;
                    case 14:
                        DrawLine(D, C, S);
                        break;
                    case 15:
                        break;
                }
            }
        }
    }

    // Get the base 10 state of a cell based on the binary values given
    private static int GetState(double A, double B, double C, double D) {
        return (int)(A * 8 + B * 4 + C * 2 + D * 1);
    }

    // Draw a line from A to B in a specified color, or white (default)
    private static void DrawLine(Vector2 A, Vector2 B, int S, Color? C=null) {
        var Col = C ?? Color.WHITE;
        DrawLineEx(A * S, B * S, 2.0f, Col);
    }
}