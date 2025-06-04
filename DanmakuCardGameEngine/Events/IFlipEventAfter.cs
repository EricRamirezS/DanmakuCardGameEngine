using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="FlipEvent"/> *after* its main action.
    /// Implementers react to the card flip once it has occurred.
    /// </summary>
    public interface IFlipEventAfter {
        /// <summary>
        /// Handler method for the <see cref="FlipEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="FlipEventArgs"/> for the event.</param>
        void OnFlipAfter(FlipEventArgs args);
    }
}