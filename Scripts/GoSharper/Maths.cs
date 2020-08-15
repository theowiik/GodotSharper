using System;

namespace GoSharper.Scripts.GoSharper
{
  /// <summary>
  ///   Useful methods for mathematical functions that is missing from the standard library or are just abstracted for
  ///   convenience.
  /// </summary>
  public static class Maths
  {
    #region Rounding

    /// <summary>
    ///   Rounds down a float the next int.
    /// </summary>
    /// <param name="f">The float to round down.</param>
    /// <returns>The rounded down int.</returns>
    public static int Down(float f)
    {
      return (int) Math.Floor(f);
    }

    #endregion

    #region Ranges

    /// <summary>
    ///   Gets the closest legal number in a range.
    /// </summary>
    /// <param name="min">The smallest allowed value.</param>
    /// <param name="max">The largest allowed value.</param>
    /// <param name="value">The value to make sure is in a valid range.</param>
    /// <returns>The closest legal value.</returns>
    public static float ClosestLegal(float min, float max, float value)
    {
      if (value <= min) return min;
      if (value >= max) return max;
      return value;
    }

    /// <summary>
    ///   Gets the closest legal number in a range.
    /// </summary>
    /// <param name="min">The smallest allowed value.</param>
    /// <param name="max">The largest allowed value.</param>
    /// <param name="value">The value to make sure is in a valid range.</param>
    /// <returns>The closest legal value.</returns>
    public static int ClosestLegal(int min, int max, int value)
    {
      if (value <= min) return min;
      if (value >= max) return max;
      return value;
    }

    /// <summary>
    ///   Gets the closest legal value that is greater or equal to the smallest allowed value.
    /// </summary>
    /// <param name="min">The smallest allowed value.</param>
    /// <param name="value">The value to constraint.</param>
    /// <returns>The closest legal value that is greater or equal to the smallest allowed value</returns>
    private static float GreaterThan(float min, float value)
    {
      return value <= min ? min : value;
    }

    /// <summary>
    ///   Gets the closest legal value that is greater or equal to the smallest allowed value.
    /// </summary>
    /// <param name="min">The smallest allowed value.</param>
    /// <param name="value">The value to constraint.</param>
    /// <returns>The closest legal value that is greater or equal to the smallest allowed value</returns>
    private static int GreaterThan(int min, int value)
    {
      return value <= min ? min : value;
    }

    /// <summary>
    ///   <returns>
    ///     Returns 0 if the the provided value is smaller or equal to zero, otherwise simply returns the value
    ///     provided.
    ///   </returns>
    /// </summary>
    /// <param name="value">The value to constrain.</param>
    public static float ZeroOrGreater(float value)
    {
      return GreaterThan(0, value);
    }

    /// <summary>
    ///   <returns>
    ///     Returns 0 if the the provided value is smaller or equal to zero, otherwise simply returns the value
    ///     provided.
    ///   </returns>
    /// </summary>
    /// <param name="value">The value to constrain.</param>
    public static int ZeroOrGreater(int value)
    {
      return GreaterThan(0, value);
    }

    #endregion
  }
}