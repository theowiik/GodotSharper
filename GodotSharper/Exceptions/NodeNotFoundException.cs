namespace GodotSharper.Exceptions;

public sealed class NodeNotFoundException : Exception
{
    public NodeNotFoundException(string message) : base(message)
    {
    }
}