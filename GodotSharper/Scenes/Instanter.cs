using Godot;

namespace GodotSharper.Instancing;

/// <summary>
///     A static class that provides a method for instantiating Godot nodes.
/// </summary>
public static class Instanter
{
    private static readonly IDictionary<Type, string> s_typePathLookup =
        new Dictionary<Type, string>();

    /// <summary>
    ///     Instantiates a Godot node of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the node to instantiate.</typeparam>
    /// <returns>The instantiated node.</returns>
    /// <exception cref="FileNotFoundException">Thrown if the PackedSceneAttribute for the specified type is not found.</exception>
    public static T Instantiate<T>()
        where T : Node
    {
        var type = typeof(T);
        string path;

        if (s_typePathLookup.TryGetValue(type, out var value))
        {
            path = value;
        }
        else
        {
            var attr = (SceneAttribute)Attribute.GetCustomAttribute(type, typeof(SceneAttribute));

            if (attr == null)
                throw new ArgumentException(
                    $"Type {type} does not have a {nameof(SceneAttribute)}"
                );

            path = attr.Path;
            s_typePathLookup[type] = path;
        }

        var scene = GDX.LoadOrFail<PackedScene>(path);
        return scene.Instantiate<T>();
    }
}
