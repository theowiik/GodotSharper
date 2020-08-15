using System;

namespace GoSharper.Scripts.GoSharper.Instancing
{
  /// <summary>
  ///   Explanation here
  ///   Credits to Andy Savage (https://github.com/andy-noisyduck) which is the original creator of this class.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public sealed class PackedSceneAttribute : Attribute
  {
    /// <summary>
    ///   Specifies an associated PackedScene path to be coupled with this class.
    /// </summary>
    /// <param name="path">The path to the PackedScene resource.</param>
    public PackedSceneAttribute(string path)
    {
      Path = path;
    }

    /// <summary>
    ///   The path to the PackedScene resource.
    /// </summary>
    public string Path { get; }
  }
}