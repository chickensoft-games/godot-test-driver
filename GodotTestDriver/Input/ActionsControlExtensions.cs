namespace GodotTestDriver.Input;

using System.Threading.Tasks;
using Godot;
using GodotTestDriver.Util;
using JetBrains.Annotations;

/// <summary>
/// Input action extensions.
/// </summary>
[PublicAPI]
public static class ActionsControlExtensions
{
    /// <summary>
    /// Hold an input action for a given duration.
    /// </summary>
    /// <param name="node">Node to supply input to.</param>
    /// <param name="seconds">Time, in seconds.</param>
    /// <param name="actionName">Name of the action.</param>
    /// <returns>Task that completes when the input finishes.</returns>
    public static async Task HoldActionFor(
        this Node node,
        float seconds,
        string actionName
    )
    {
        node.StartAction(actionName);
        await node.Wait(seconds);
        node.EndAction(actionName);
    }

    /// <summary>
    /// Start an input action.
    /// </summary>
    /// <param name="_">Node to supply input to.</param>
    /// <param name="actionName">Name of the action.</param>
    /// <returns>Task that completes when the input finishes.</returns>
    public static void StartAction(this Node _, string actionName)
    {
        Input.ParseInputEvent(new InputEventAction
        {
            Action = actionName,
            Pressed = true
        });
        Input.ActionPress(actionName);
        Input.FlushBufferedEvents();
    }

    /// <summary>
    /// End an input action.
    /// </summary>
    /// <param name="_">Node to supply input to.</param>
    /// <param name="actionName">Name of the action.</param>
    /// <returns>Task that completes when the input finishes.</returns>
    public static void EndAction(this Node _, string actionName)
    {
        Input.ParseInputEvent(new InputEventAction
        {
            Action = actionName,
            Pressed = false
        });
        Input.ActionRelease(actionName);
        Input.FlushBufferedEvents();
    }

    /// <summary>
    /// Trigger an input action by immediately starting and ending it.
    /// </summary>
    /// <param name="node">Node to supply input to.</param>
    /// <param name="actionName">Name of the action.</param>
    /// <returns>Task that completes when the input finishes.</returns>
    public static void TriggerAction(this Node node, string actionName)
    {
        node.StartAction(actionName);
        node.EndAction(actionName);
    }
}
