using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DanmakuPlayedEvent"/> *before* its main action.
    /// Implementers can influence whether the danmaku plays or is stopped.
    /// </summary>
    public interface IDanmakuPlayedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DanmakuPlayedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DanmakuPlayedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main danmaku played action.</param>
        void OnDanmakuPlayedBefore(DanmakuPlayedEventArgs args, out bool bubbleEvent);
    }
}