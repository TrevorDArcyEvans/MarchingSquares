namespace MarchingSquares;

using System.Numerics;

internal static class MarchingSquares
{
  // Run the marching squares algorithm on the given list
  public static List<Tuple<Vector2, Vector2>> Run(Point[,] points)
  {
    var lineSegments = new List<Tuple<Vector2, Vector2>>();

    for (var x = 0; x < points.GetLength(0) - 1; x++)
    {
      for (var y = 0; y < points.GetLength(1) - 1; y++)
      {
        var a = new Vector2(x + 0.5f, y);
        var b = new Vector2(x + 1, y + 0.5f);
        var c = new Vector2(x + 0.5f, y + 1);
        var d = new Vector2(x, y + 0.5f);

        var state = GetState(
          points[x, y].Value,
          points[x + 1, y].Value,
          points[x + 1, y + 1].Value,
          points[x, y + 1].Value
        );

        // https://en.wikipedia.org/wiki/Marching_squares
        switch (state)
        {
          case 0:
            break;
          case 1:
            lineSegments.Add(new Tuple<Vector2, Vector2>(d, c));
            break;
          case 2:
            lineSegments.Add(new Tuple<Vector2, Vector2>(c, b));
            break;
          case 3:
            lineSegments.Add(new Tuple<Vector2, Vector2>(d, b));
            break;
          case 4:
            lineSegments.Add(new Tuple<Vector2, Vector2>(b, a));
            break;
          case 5:
            lineSegments.Add(new Tuple<Vector2, Vector2>(d, a));
            lineSegments.Add(new Tuple<Vector2, Vector2>(c, b));
            break;
          case 6:
            lineSegments.Add(new Tuple<Vector2, Vector2>(c, a));
            break;
          case 7:
            lineSegments.Add(new Tuple<Vector2, Vector2>(d, a));
            break;
          case 8:
            lineSegments.Add(new Tuple<Vector2, Vector2>(a, d));
            break;
          case 9:
            lineSegments.Add(new Tuple<Vector2, Vector2>(a, c));
            break;
          case 10:
            lineSegments.Add(new Tuple<Vector2, Vector2>(d, c));
            lineSegments.Add(new Tuple<Vector2, Vector2>(a, b));
            break;
          case 11:
            lineSegments.Add(new Tuple<Vector2, Vector2>(a, b));
            break;
          case 12:
            lineSegments.Add(new Tuple<Vector2, Vector2>(b, d));
            break;
          case 13:
            lineSegments.Add(new Tuple<Vector2, Vector2>(b, c));
            break;
          case 14:
            lineSegments.Add(new Tuple<Vector2, Vector2>(c, d));
            break;
          case 15:
            break;
          default:
            throw new ArgumentOutOfRangeException($"State {state} is not supported");
        }
      }
    }

    return lineSegments;
  }

  // Get the base 10 state of a cell based on the binary values given
  private static int GetState(bool a, bool b, bool c, bool d)
  {
    return Convert.ToInt32(a) * 8 + Convert.ToInt32(b) * 4 + Convert.ToInt32(c) * 2 + Convert.ToInt32(d);
  }
}
