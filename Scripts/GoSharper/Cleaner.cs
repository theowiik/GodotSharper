using System.Linq;
using System.Text;
using Godot;

namespace GoSharper.Scripts.GoSharper
{
  /// <summary>
  ///   Useful methods for cleaning strings and numbers.
  /// </summary>
  public static class Cleaner
  {
    /// <summary>
    ///   Removes all non integer characters (including "-", "." and ",").
    /// </summary>
    /// <param name="toBeCleaned">The string to clean.</param>
    /// <returns>The "integer value" of the string.</returns>
    public static int String2PositiveInteger(string toBeCleaned)
    {
      if (toBeCleaned == null || toBeCleaned.Empty()) return 0;

      var legalChars   = toBeCleaned.Where(char.IsDigit);
      var concatenated = string.Join("", legalChars);

      return concatenated.Empty() ? 0 : int.Parse(concatenated);
    }

    /// <summary>
    ///   Cleans the string and returns the float value. Takes the first . or , as the first decimal.
    /// </summary>
    /// <param name="toBeCleaned">The string to clean.</param>
    /// <returns>The "float value" of the string</returns>
    /// <example>
    ///   null -> 0f
    ///   "" -> 0f
    ///   "123" -> 123f
    ///   "123.45" -> 123.45f
    ///   "123,45" -> 123.45f
    ///   ".123" -> 0.123f
    ///   ",123" -> 0.123f
    ///   "0...,,,,...44,,,...4" -> 0.444f
    /// </example>
    public static float String2Float(string toBeCleaned)
    {
      if (toBeCleaned == null) return 0f;

      var legalChars    = "0123456789.".ToCharArray();
      var onlyDots      = toBeCleaned.Replace(',', '.');
      var stringBuilder = new StringBuilder();
      var decimalAdded  = false;

      foreach (var c in onlyDots.Where(c => legalChars.Contains(c)))
        if (c.Equals('.'))
        {
          if (decimalAdded) continue;
          decimalAdded = true;
          stringBuilder.Append(c);
        }
        else
        {
          stringBuilder.Append(c);
        }

      var stringToParse = stringBuilder.ToString();

      return stringToParse.Empty() ? 0f : float.Parse(stringToParse);
    }

    /// <summary>
    ///   Given a float where 0 = 0% and 1 = 100%, returns a string of the percentage in a readable format. See examples.
    /// </summary>
    /// <param name="number">The float to convert to a percentage representation.</param>
    /// <returns>A clean representation of the string</returns>
    /// <example>
    ///   0.346789 -> "34.67%"
    ///   1.5 -> "150%"
    /// </example>
    public static string ReadablePercentage(float number)
    {
      return $"{number:P2}";
    }
  }
}