using Godot;

namespace GoSharper.Scripts.GoSharper
{
  /// <summary>
  ///   Methods for date and time related stuff.
  /// </summary>
  public static class Dates
  {
    /// <summary>
    ///   Gets a date-time object representing the current date and time.
    /// </summary>
    /// <returns>The current date and time in a string representation</returns>
    public static string Now()
    {
      var date = OS.GetDatetime();
      return $"{date["year"]}.{date["month"]}.{date["day"]} - {date["hour"]}.{date["minute"]}.{date["second"]}";
    }
  }
}