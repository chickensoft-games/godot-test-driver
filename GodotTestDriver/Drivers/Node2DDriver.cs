namespace GodotTestDriver.Drivers;

using System;
using Godot;
using JetBrains.Annotations;

/// <summary>
/// Driver for <see cref="Node2D"/> nodes.
/// </summary>
/// <typeparam name="T">Node2D Type.</typeparam>
[PublicAPI]
public class Node2DDriver<T> : CanvasItemDriver<T> where T : Node2D
{
    public Node2DDriver(Func<T> producer, string description = "") : base(producer, description)
    {
    }

    /// <summary>
    /// The global position of the node.
    /// </summary>
    public Vector2 GlobalPosition => PresentRoot.GlobalPosition;

    /// <summary>
    /// The position of the node relative to its parent.
    /// </summary>
    public Vector2 Position => PresentRoot.Position;
}
