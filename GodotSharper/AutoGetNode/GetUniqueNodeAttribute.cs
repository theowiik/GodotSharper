using Godot;

namespace GodotSharper.AutoGetNode;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class GetUniqueNodeAttribute : BaseGetNode
{
    public GetUniqueNodeAttribute(string path) : base(path)
    {
    }

    /// <summary>
    /// Recursively searches for a child node with the given path, starting from the given node.
    /// </summary>
    /// <param name="node">The node to start the search from.</param>
    /// <param name="path">The path of the child node to search for.</param>
    /// <returns>The child node with the given path, or null if it was not found.</returns>
    protected override Node GetNode(Node node, string path)
    {
        var directChild = node.GetNodeOrNull(path);
        if (directChild != null)
            return directChild;

        var children = node.GetChildren();

        // Base case
        if (!children.Any())
            return null;

        foreach (var c in children)
        {
            var childNode = GetNode(c, path);

            if (childNode != null)
                return childNode;
        }

        return null;
    }
}