using System.Collections.Generic;
using System.Reflection;
using Godot;
using GoSharper.Scripts.GoSharper.AutoWiring.Attributes;

namespace GoSharper.Scripts.GoSharper.AutoWiring
{
  /// <summary>
  ///   AutoWiring used for setting child nodes auto-magically.
  /// </summary>
  public static class NodeAutoWire
  {
    /// <summary>
    ///   Binds all GetNode attribute fields to the child nodes. <see cref="GetNodeAttribute" />
    /// </summary>
    /// <param name="node"></param>
    public static void AutoWire(this Node node)
    {
      WireFields(node);
    }

    private static void WireFields(Node node)
    {
      var fields = GetFields(node);

      foreach (var field in fields)
        field.GetCustomAttribute<GetNodeAttribute>()?.SetNode(field, node);
    }

    /// <summary>
    ///   Returns a enumerable of all the fields.
    /// </summary>
    /// <param name="node">The node to retrieve fields from.</param>
    /// <returns>A enumerable of all the fields.</returns>
    private static IEnumerable<FieldInfo> GetFields(Node node)
    {
      if (node == null) return new List<FieldInfo>();

      var fields = node.GetType().GetFields(
        BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
      );

      return new List<FieldInfo>(fields);
    }
  }
}