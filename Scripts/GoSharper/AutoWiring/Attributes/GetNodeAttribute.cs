using System;
using System.Reflection;
using Godot;

namespace GoSharper.Scripts.GoSharper.AutoWiring.Attributes
{
  /// <summary>
  ///   A attribute used for retrieving nodes in the tree.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
  public sealed class GetNodeAttribute : Attribute
  {
    private readonly string _path;

    public GetNodeAttribute(string nodePath)
    {
      _path = nodePath;
    }

    /// <summary>
    ///   Sets the node.
    /// </summary>
    /// <param name="fieldInfo">The field info.</param>
    /// <param name="node">The node.</param>
    public void SetNode(FieldInfo fieldInfo, Node node)
    {
      var childNode = node.GetNodeOrNull(_path);

      if (childNode == null)
        throw new Exception($"Cannot find Node for NodePath '{_path}'");

      if (childNode.GetType() == fieldInfo.FieldType || childNode.GetType().IsSubclassOf(fieldInfo.FieldType))
        fieldInfo.SetValue(node, childNode);
      else
        throw new Exception($"Node is not a valid type. Expected {fieldInfo.FieldType} got {childNode.GetType()}");
    }
  }
}