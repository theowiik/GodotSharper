using System;
using System.Collections.Generic;
using Godot;

namespace GoSharper.Scripts.GoSharper
{
  /// <summary>
  ///   Godot color utility class.
  /// </summary>
  public static class ColorUtil
  {
    /// <summary>
    ///   Gets a enumerable of n unique colors.
    /// </summary>
    /// <param name="n">The amount of colors to retrieve.</param>
    /// <returns>A enumerable of unique colors.</returns>
    public static IList<Color> UniqueColors(int n)
    {
      if (n <= 0) return new Color[0];

      var output = GetConstants();
      while (output.Count < n) output.Add(RandomColor());
      var trimmed = output.GetRange(0, n);
      trimmed.Shuffle();

      return trimmed;
    }

    /// <summary>
    ///   Gets a random color with no transparency.
    /// </summary>
    /// <returns>A random color</returns>
    private static Color RandomColor()
    {
      return new Color(GD.Randf(), GD.Randf(), GD.Randf());
    }

    /// <summary>
    ///   Gets a list of a few hand selected color constants.
    /// </summary>
    /// <returns>A list of colors.</returns>
    private static List<Color> GetConstants()
    {
      return new List<Color>
      {
        Colors.Gainsboro,
        Colors.Purple,
        Colors.Aqua,
        Colors.Lime,
        Colors.SlateBlue,
        Colors.DodgerBlue
      };
    }

    #region Shuffle

    private static void Shuffle<T>(this IList<T> list)
    {
      var rnd = new Random();
      for (var i = list.Count; i > 0; i--)
        list.Swap(0, rnd.Next(0, i));
    }

    private static void Swap<T>(this IList<T> list, int i, int j)
    {
      var temp = list[i];
      list[i] = list[j];
      list[j] = temp;
    }

    #endregion
  }
}