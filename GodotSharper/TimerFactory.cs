using Timer = Godot.Timer;

namespace GodotSharper;

/// <summary>
///     A factory class for creating Timer objects with various configurations.
/// </summary>
public static class TimerFactory
{
    /// <summary>
    ///     Creates a new Timer object that starts automatically and triggers only once after the specified wait time.
    /// </summary>
    /// <param name="waitTime">The time to wait before triggering the timer, in seconds.</param>
    /// <param name="onTimeout">An optional action to execute when the timer triggers.</param>
    /// <returns>The newly created Timer object.</returns>
    public static Timer StartedOneShot(double waitTime, Action onTimeout = null)
    {
        var timer = InternalCreateTimer(true, true, waitTime);
        timer.Timeout += () => onTimeout?.Invoke();

        return timer;
    }

    /// <summary>
    ///     Creates a new Timer object that starts automatically, triggers only once after the specified wait time, and
    ///     destroys itself after triggering.
    /// </summary>
    /// <param name="waitTime">The time to wait before triggering the timer, in seconds.</param>
    /// <param name="onTimeout">An optional action to execute when the timer triggers.</param>
    /// <returns>The newly created Timer object.</returns>
    public static Timer StartedSelfDestructingOneShot(double waitTime, Action onTimeout = null)
    {
        var timer = InternalCreateTimer(true, true, waitTime);
        timer.Timeout += () =>
        {
            onTimeout?.Invoke();
            timer.QueueFree();
        };

        return timer;
    }

    /// <summary>
    ///     Creates a new Timer object that starts automatically and triggers repeatedly after the specified wait time.
    /// </summary>
    /// <param name="waitTime">The time to wait before each trigger of the timer, in seconds.</param>
    /// <param name="onTimeout">An optional action to execute when the timer triggers.</param>
    /// <returns>The newly created Timer object.</returns>
    public static Timer StartedRepeating(double waitTime, Action onTimeout = null)
    {
        var timer = InternalCreateTimer(true, false, waitTime);
        timer.Timeout += () => onTimeout?.Invoke();

        return timer;
    }

    private static Timer InternalCreateTimer(bool autostart, bool oneShot, double waitTime)
    {
        return new Timer
        {
            Autostart = autostart,
            OneShot = oneShot,
            WaitTime = waitTime
        };
    }
}
