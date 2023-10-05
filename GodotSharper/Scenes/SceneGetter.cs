using System.Reflection;
using Godot;

namespace GodotSharper.Instancing;

/// <summary>
///     A static class that provides a method to get the path of a scene associated with a given type.
/// </summary>
public static class SceneGetter
{
    /// <summary>
    ///     Gets the path of a scene associated with the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the node associated with the scene.</typeparam>
    /// <returns>The path of the scene associated with the specified type.</returns>
    /// <exception cref="ArgumentException">Thrown when the specified type does not have a SceneAttribute.</exception>
    public static string GetPath<T>()
        where T : Node
    {
        var type = typeof(T);
        var attribute = type.GetCustomAttribute<SceneAttribute>();

        if (attribute == null)
        {
            throw new ArgumentException($"Type {type} does not have a {nameof(SceneAttribute)}");
        }

        return attribute.Path;
    }
}
