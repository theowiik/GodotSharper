using System.Collections.Generic;
using Godot;

namespace GoSharper.Scripts.GoSharper
{
  /// <summary>
  ///   Useful methods for signals.
  /// </summary>
  public static class Signals
  {
    /// <summary>
    ///   Checks if a signal is connected and connects it if not.
    /// </summary>
    /// <param name="emitter">The Object that emits the signal.</param>
    /// <param name="signal">The signal to connect.</param>
    /// <param name="target">The Object that gets connected to the signal.</param>
    /// <param name="method">The method to run when the signal is emitted.</param>
    public static void TryConnect(Object emitter, string signal, Object target, string method)
    {
      if (emitter == null || signal == null || target == null || method == null) return;
      if (emitter.IsConnected(signal, target, method)) return;
      emitter.Connect(signal, target, method);
    }

    /// <summary>
    ///   Checks if a signal is connected and connects it if not for all the provided Objects.
    /// </summary>
    /// <param name="emitters">The Objects that emits the signal.</param>
    /// <param name="signal">The signal to connect.</param>
    /// <param name="target">The Object that gets connected to the signal.</param>
    /// <param name="method">The method to run when the signal is emitted.</param>
    public static void TryConnectAll(IEnumerable<Object> emitters, string signal, Object target, string method)
    {
      if (emitters == null) return;

      foreach (var emitter in emitters)
        TryConnect(emitter, signal, target, method);
    }
  }
}