namespace MarchingSquares;

using System.Numerics;

internal static class MarchingSquares
{
  // Run the marching squares algorithm on the given list
  public static List<Tuple<Vector2, Vector2>> Run(Point[,] Points)
  {
    var LineSegments = new List<Tuple<Vector2, Vector2>>();

    for (var X = 0; X < Points.GetLength(0) - 1; X++)
    {
      for (var Y = 0; Y < Points.GetLength(1) - 1; Y++)
      {
        var A = new Vector2(X + 0.5f, Y);
        var B = new Vector2(X + 1, Y + 0.5f);
        var C = new Vector2(X + 0.5f, Y + 1);
        var D = new Vector2(X, Y + 0.5f);

        var State = GetState(
          Points[X, Y].Value,
          Points[X + 1, Y].Value,
          Points[X + 1, Y + 1].Value,
          Points[X, Y + 1].Value
        );

        // https://en.wikipedia.org/wiki/Marching_squares
        switch (State)
        {
          case 0:
            break;
          case 1:
            LineSegments.Add(new Tuple<Vector2, Vector2>(D, C));
            break;
          case 2:
            LineSegments.Add(new Tuple<Vector2, Vector2>(C, B));
            break;
          case 3:
            LineSegments.Add(new Tuple<Vector2, Vector2>(D, B));
            break;
          case 4:
            LineSegments.Add(new Tuple<Vector2, Vector2>(B, A));
            break;
          case 5:
            LineSegments.Add(new Tuple<Vector2, Vector2>(D, A));
            LineSegments.Add(new Tuple<Vector2, Vector2>(C, B));
            break;
          case 6:
            LineSegments.Add(new Tuple<Vector2, Vector2>(C, A));
            break;
          case 7:
            LineSegments.Add(new Tuple<Vector2, Vector2>(D, A));
            break;
          case 8:
            LineSegments.Add(new Tuple<Vector2, Vector2>(A, D));
            break;
          case 9:
            LineSegments.Add(new Tuple<Vector2, Vector2>(A, C));
            break;
          case 10:
            LineSegments.Add(new Tuple<Vector2, Vector2>(D, C));
            LineSegments.Add(new Tuple<Vector2, Vector2>(A, B));
            break;
          case 11:
            LineSegments.Add(new Tuple<Vector2, Vector2>(A, B));
            break;
          case 12:
            LineSegments.Add(new Tuple<Vector2, Vector2>(B, D));
            break;
          case 13:
            LineSegments.Add(new Tuple<Vector2, Vector2>(B, C));
            break;
          case 14:
            LineSegments.Add(new Tuple<Vector2, Vector2>(C, D));
            break;
          case 15:
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }

    return LineSegments;
  }

  // Get the base 10 state of a cell based on the binary values given
  private static int GetState(bool A, bool B, bool C, bool D)
  {
    return Convert.ToInt32(A) * 8 + Convert.ToInt32(B) * 4 + Convert.ToInt32(C) * 2 + Convert.ToInt32(D);
  }
}
