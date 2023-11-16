using System.Reflection;
using Godot;

namespace GodotSharper.AutoGetNode;

/// <summary>
///     A static class that provides extension methods to automatically get nodes in Godot game engine.
/// </summary>
public static class AutoGetNode
{
    /// <summary>
    ///     Gets all the nodes in the specified node and wires them to the corresponding fields and properties.
    /// </summary>
    /// <param name="node">The node to get the nodes from.</param>
    public static void GetNodes(this Node node)
    {
        WireMembers(node, GetFields(node));
        WireMembers(node, GetProperties(node));
    }

    /// <summary>
    ///     Gets all the fields in the specified node.
    /// </summary>
    /// <param name="node">The node to get the fields from.</param>
    /// <returns>An IEnumerable of FieldInfo objects.</returns>
    private static IEnumerable<FieldInfo> GetFields(Node node)
    {
        return GetMembers<FieldInfo>(node);
    }

    /// <summary>
    ///     Gets all the properties in the specified node.
    /// </summary>
    /// <param name="node">The node to get the properties from.</param>
    /// <returns>An IEnumerable of PropertyInfo objects.</returns>
    private static IEnumerable<PropertyInfo> GetProperties(Node node)
    {
        return GetMembers<PropertyInfo>(node);
    }

    /// <summary>
    ///     Gets all the members of the specified type in the specified node.
    /// </summary>
    /// <typeparam name="T">The type of member to get.</typeparam>
    /// <param name="node">The node to get the members from.</param>
    /// <returns>An IEnumerable of T objects.</returns>
    private static IEnumerable<T> GetMembers<T>(Node node)
        where T : MemberInfo
    {
        if (node == null)
            return new List<T>();

        var members = node.GetType()
            .GetMembers(
                BindingFlags.FlattenHierarchy
                    | BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance
            )
            .OfType<T>();

        return new List<T>(members);
    }

    /// <summary>
    ///     Wires all the members in the specified node to the corresponding nodes.
    /// </summary>
    /// <typeparam name="T">The type of member to wire.</typeparam>
    /// <param name="node">The node to wire the members to.</param>
    /// <param name="members">The members to wire.</param>
    private static void WireMembers<T>(Node node, IEnumerable<T> members)
        where T : MemberInfo
    {
        foreach (var member in members)
        {
            member.GetCustomAttribute<GetNodeAttribute>()?.SetNode(member, node);
            member.GetCustomAttribute<GetUniqueNodeAttribute>()?.SetNode(member, node);
        }
    }
}
