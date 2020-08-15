using System;
using System.Collections.Generic;
using Godot;

namespace GoSharper.Scripts.GoSharper.Instancing
{
  public static class PackedSceneFactory
  {
    private static readonly object _lock = new object();

    /// <summary>
    ///   Cache of mappings between types and resource paths (so we don't need to use reflection each time).
    /// </summary>
    private static readonly IDictionary<Type, string> TypePathLookup = new Dictionary<Type, string>();

    /// <summary>
    ///   Instances the type given that the type has a PackedSceneAttribute.
    /// </summary>
    /// <typeparam name="T">The type to instance.</typeparam>
    /// <returns>A new instance of type T.</returns>
    /// <exception cref="Exception">If there is no PackedSceneAttribute for type T.</exception>
    /// <exception cref="NullReferenceException">If the scene could not be loaded.</exception>
    public static T Instance<T>() where T : Node
    {
      lock (_lock)
      {
        var    type = typeof(T);
        string path;

        if (TypePathLookup.ContainsKey(type))
        {
          path = TypePathLookup[type];
        }
        else
        {
          var attr = (PackedSceneAttribute) Attribute.GetCustomAttribute(type, typeof(PackedSceneAttribute));

          if (attr == null)
            throw new Exception("Could not find a PackedSceneAttribute for " + type);

          path                 = attr.Path;
          TypePathLookup[type] = path;
        }

        return Nodes.InstanceNotNull<T>(path);
      }
    }
  }
}