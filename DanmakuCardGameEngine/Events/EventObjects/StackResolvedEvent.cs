using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when the stack resolves and all pending actions are executed.
    /// Allows cleanup or end-of-stack reactions.
    /// </summary>
    public class StackResolvedEvent : BubblingEvent<StackResolvedEventArgs> { }
}