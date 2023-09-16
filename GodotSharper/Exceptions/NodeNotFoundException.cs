/// <summary>
/// Represents an exception that is thrown when a node is not found in the scene tree.
/// </summary>
namespace GodotSharper.Exceptions;

public sealed class NodeNotFoundException : Exception
{
    public NodeNotFoundException(string message)
        : base(message) { }
}
