using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StackResolvedEvent"/> *after* its main action.
    /// Implementers react to the stack resolution once it has occurred.
    /// </summary>
    public interface IStackResolvedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="StackResolvedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="StackResolvedEventArgs"/> for the event.</param>
        void OnStackResolvedAfter(StackResolvedEventArgs args);
    }
}