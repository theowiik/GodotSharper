using Godot;

namespace GodotSharper;

/// <summary>
///     Extended "GD" class providing utility methods for working with Godot Engine.
/// </summary>
public static class GDX
{
    /// <summary>
    ///     Loads a resource from the specified path and returns it as a strongly-typed object.
    /// </summary>
    /// <typeparam name="T">The type of the resource to load.</typeparam>
    /// <param name="path">The path to the resource to load.</param>
    /// <returns>The loaded resource as a strongly-typed object.</returns>
    /// <exception cref="FileNotFoundException">Thrown if the resource could not be loaded.</exception>
    public static T LoadOrFail<T>(string path)
        where T : class
    {
        var node = GD.Load<T>(path);

        if (node != null)
            return node;

        var msg = $"Could not load resource at {path}";
        GD.PrintErr(msg);
        throw new FileNotFoundException(msg);
    }
}
