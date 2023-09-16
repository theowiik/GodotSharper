using Godot;

namespace GodotSharper;

public static class GDX
{
    public static T LoadOrFail<T>(string path) where T : class
    {
        var node = GD.Load<T>(path);

        if (node != null)
        {
            return node;
        }

        var msg = $"Could not load resource at {path}";
        GD.PrintErr(msg);
        throw new FileNotFoundException(msg);
    }
}
