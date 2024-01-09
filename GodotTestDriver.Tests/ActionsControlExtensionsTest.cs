namespace GodotTestDriver.Tests;
using Chickensoft.GoDotTest;
using Godot;
using GodotTestDriver.Input;
using JetBrains.Annotations;
using Shouldly;

[UsedImplicitly]
public class ActionsControlExtensionsTest : DriverTest
{
    private const string TestAction = "test_action";

    public ActionsControlExtensionsTest(Node testScene) : base(testScene)
    {
    }

    [Test]
    public void StartActionSetsGlobalActionPressed()
    {
        Input.IsActionPressed(TestAction).ShouldBeFalse();
        RootNode.StartAction(TestAction);
        Input.IsActionPressed(TestAction).ShouldBeTrue();
        RootNode.EndAction(TestAction);
    }

    [Test]
    public void EndActionUnsetsGlobalActionPressed()
    {
        RootNode.StartAction(TestAction);
        RootNode.EndAction(TestAction);
        Input.IsActionPressed(TestAction).ShouldBeFalse();
    }

    [Test]
    public void StartActionSetsGlobalActionJustPressed()
    {
        RootNode.StartAction(TestAction);
        Input.IsActionJustPressed(TestAction).ShouldBeTrue();
        RootNode.EndAction(TestAction);
    }

    [Test]
    public void EndActionSetsGlobalActionJustReleased()
    {
        RootNode.StartAction(TestAction);
        RootNode.EndAction(TestAction);
        Input.IsActionJustReleased(TestAction).ShouldBeTrue();
    }
}
