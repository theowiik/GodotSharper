using System;
using System.Collections.Generic;
using Godot;

namespace GoSharper.Scripts.GoSharper
{
  /// <summary>
  ///   Helper methods for creating shapes.
  /// </summary>
  public static class ShapeUtils
  {
    /// <summary>
    ///   Creates a array of points that resembles a hexagon.
    ///   With the the coordinate (0, 0) as the center.
    /// </summary>
    /// <param name="sideLength">The length of the side.</param>
    /// <exception cref="ArgumentOutOfRangeException">If the sideLength isn't greater than zero.</exception>
    /// <returns>A array of points.</returns>
    public static Vector2[] CreateHexagon(float sideLength)
    {
      if (sideLength <= 0)
        throw new ArgumentOutOfRangeException(nameof(sideLength), "Side length must be greater than zero");

      var points = new Vector2[6];

      // Start at the top-left most point.
      // Move back half the side length to center the width.
      // Move up cos(30) * sideLength to center height (hexagon specific trigonometry).
      var lastPoint       = new Vector2(-sideLength / 2f, -Mathf.Cos(Mathf.Deg2Rad(30)) * sideLength);
      var rotationRadians = Mathf.Deg2Rad(60);

      for (var i = 0; i < 6; i++)
      {
        points[i] = lastPoint + new Vector2(sideLength, 0).Rotated(rotationRadians * i);
        lastPoint = points[i];
      }

      return points;
    }

    /// <summary>
    ///   Creates a line.
    /// </summary>
    /// <param name="start">The start point of the line.</param>
    /// <param name="end">The end point of the line.</param>
    /// <param name="color">The color of the line.</param>
    /// <returns>The created line.</returns>
    public static Line2D CreateLine(Vector2 start, Vector2 end, Color color)
    {
      var line = new Line2D {Width = 0.5f, DefaultColor = color};
      line.AddPoint(start);
      line.AddPoint(end);

      return line;
    }

    /// <summary>
    ///   Returns a array of points representing a circle with the coordinate (0, 0) as the center.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <exception cref="ArgumentOutOfRangeException">If the radius isn't greater than zero.</exception>
    /// <returns>A array of points representing a circle.</returns>
    public static Vector2[] CreateCircle(float radius)
    {
      if (radius <= 0)
        throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be greater than zero");

      const int   edges       = 100;
      var         originPoint = new Vector2(radius, 0);
      const float rotationRad = Mathf.Pi * 2f / edges;
      var         output      = new List<Vector2>();

      for (var i = 0; i < edges; i++)
        output.Add(originPoint.Rotated(rotationRad * i));

      return output.ToArray();
    }

    /// <summary>
    ///   Returns a list of "lines" (start and end coordinates).
    /// </summary>
    /// <param name="start">The start coordinate of the arrow.</param>
    /// <param name="end">The end coordinate of the arrow.</param>
    public static IList<Tuple<Vector2, Vector2>> CreateArrow(Vector2 start, Vector2 end)
    {
      const float arrowheadLength = 5f;
      var         arrowAngleRad   = Mathf.Deg2Rad(45);
      var         directionBack   = end.DirectionTo(start);
      var         firstArrowSide  = end + arrowheadLength * directionBack.Rotated(arrowAngleRad  / 2f);
      var         secondArrowSide = end + arrowheadLength * directionBack.Rotated(-arrowAngleRad / 2f);

      return new List<Tuple<Vector2, Vector2>>
      {
        new Tuple<Vector2, Vector2>(start,          end),
        new Tuple<Vector2, Vector2>(end,            firstArrowSide),
        new Tuple<Vector2, Vector2>(end,            secondArrowSide),
        new Tuple<Vector2, Vector2>(firstArrowSide, secondArrowSide)
      };
    }

    /// <summary>
    ///   Gets a array of vectors representing a half circle with the extruding part to the right, and the flat side to the
    ///   left.
    /// </summary>
    /// <param name="radius">The radius of the arc.</param>
    /// <param name="rotationDegrees">The rotation in degrees of the half circle.</param>
    /// <param name="nbPoints">The amount of points, the more, the more precise.</param>
    /// <returns>A array of vectors representing a half circle.</returns>
    public static Vector2[] CreateHalfCircle(float radius, float rotationDegrees = 0f, int nbPoints = 5)
    {
      var globalRotationRad   = Mathf.Deg2Rad(rotationDegrees);
      var points              = new Vector2[nbPoints + 1];
      var angleBetweenDegrees = 180f / nbPoints;

      for (var i = 0; i < nbPoints; i++)
      {
        var rotRad = Mathf.Deg2Rad(-angleBetweenDegrees * i);
        var vec    = new Vector2(0, radius).Rotated(rotRad).Rotated(globalRotationRad);
        points[i] = vec;
      }

      points[nbPoints] = new Vector2(0, radius).Rotated(-Mathf.Pi).Rotated(globalRotationRad);

      return points;
    }
  }
}