using Godot;

namespace GodotSharper.AutoGetNode;

/// <summary>
///     Attribute used to automatically get a node from the scene tree via the path to the Node.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class GetNodeAttribute : BaseGetNode
{
    public GetNodeAttribute(string nodeNodeIdentifier) : base(nodeNodeIdentifier)
    {
    }

    protected override Node GetNode(Node node, string path)
    {
        return node.GetNodeOrNull(path);
    }
}
