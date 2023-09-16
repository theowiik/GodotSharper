using System.Reflection;
using Godot;

namespace GodotSharper.AutoGetNode;

public static class AutoGetNode
{
    public static void GetNodes(this Node node)
    {
        WireMembers(node, GetFields(node));
        WireMembers(node, GetProperties(node));
    }

    private static IEnumerable<FieldInfo> GetFields(Node node)
    {
        return GetMembers<FieldInfo>(node);
    }

    private static IEnumerable<PropertyInfo> GetProperties(Node node)
    {
        return GetMembers<PropertyInfo>(node);
    }

    private static IEnumerable<T> GetMembers<T>(Node node)
        where T : MemberInfo
    {
        if (node == null)
        {
            return new List<T>();
        }

        var members = node.GetType().GetMembers(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).OfType<T>();

        return new List<T>(members);
    }

    private static void WireMembers<T>(Node node, IEnumerable<T> members) where T : MemberInfo
    {
        foreach (var member in members)
        {
            member.GetCustomAttribute<GetNodeAttribute>()?.SetNode(member, node);
        }
    }
}