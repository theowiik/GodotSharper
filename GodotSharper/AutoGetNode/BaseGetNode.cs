using System.Reflection;
using Godot;
using GodotSharper.Exceptions;

namespace GodotSharper.AutoGetNode;

public abstract class BaseGetNode : Attribute
{
    private readonly string _nodeIdentifier;

    protected BaseGetNode(string nodeIdentifier)
    {
        _nodeIdentifier = nodeIdentifier;
    }

    /// <summary>
    ///     Sets the node specified by the attribute on the given member of the provided node.
    /// </summary>
    /// <param name="memberInfo">The member to set the node on.</param>
    /// <param name="node">The node to get the child node from.</param>
    /// <exception cref="NodeNotFoundException">Thrown if the child node cannot be found.</exception>
    /// <exception cref="ArgumentException">Thrown if the child node is not of the expected type.</exception>
    public void SetNode(MemberInfo memberInfo, Node node)
    {
        var childNode = GetNode(node, _nodeIdentifier);

        if (childNode == null)
        {
            node.GetTree().Quit();
            throw new NodeNotFoundException($"Cannot find Node for NodePath '{_nodeIdentifier}'");
        }

        var expectedType = memberInfo is FieldInfo fieldInfo
            ? fieldInfo.FieldType
            : ((PropertyInfo)memberInfo).PropertyType;

        if (childNode.GetType() != expectedType && !childNode.GetType().IsSubclassOf(expectedType))
        {
            node.GetTree().Quit();
            throw new ArgumentException(
                $"Node is not a valid type. Expected {expectedType} got {childNode.GetType()}"
            );
        }

        switch (memberInfo)
        {
            case FieldInfo fieldInformation:
                fieldInformation.SetValue(node, childNode);
                break;
            case PropertyInfo propertyInformation:
                propertyInformation.SetValue(node, childNode);
                break;
            default:
                throw new ArgumentException(
                    $"MemberInfo is not a valid type. Expected {nameof(FieldInfo)} or {nameof(PropertyInfo)} got {memberInfo.GetType()}"
                );
        }
    }

    protected abstract Node GetNode(Node node, string path);
}