using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DanmakuPlayedEvent"/> *after* its main action.
    /// Implementers react to the danmaku played once it has occurred.
    /// </summary>
    public interface IDanmakuPlayedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DanmakuPlayedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DanmakuPlayedEventArgs"/> for the event.</param>
        void OnDanmakuPlayedAfter(DanmakuPlayedEventArgs args);
    }
}