using Godot;

namespace GoSharper.TestDir;

public static class Greeter
{
    public static string Greet(string name) => $"Hello, {name}!";

    public static void GDGreet(string name) => GD.Print($"Hello, {name}!");
}
