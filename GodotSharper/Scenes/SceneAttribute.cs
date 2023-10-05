namespace GodotSharper.Instancing;

/// <summary>
///     Attribute used to mark a class as a scene and specify its path.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class SceneAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SceneAttribute" /> class with the specified path.
    /// </summary>
    /// <param name="path">The path of the scene.</param>
    public SceneAttribute(string path)
    {
        Path = path;
    }

    /// <summary>
    ///     Gets the path of the scene.
    /// </summary>
    public string Path { get; }
}
