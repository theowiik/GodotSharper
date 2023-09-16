namespace GodotSharper.Instancing;

/// <summary>
///     Attribute used to mark a class as instantiable in Godot.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class InstantiableAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="InstantiableAttribute" /> class with the specified path.
    /// </summary>
    /// <param name="path">The path to the scene file for the instantiable class.</param>
    public InstantiableAttribute(string path)
    {
        Path = path;
    }

    /// <summary>
    ///     Gets the path to the scene file for the instantiable class.
    /// </summary>
    public string Path { get; }
}
