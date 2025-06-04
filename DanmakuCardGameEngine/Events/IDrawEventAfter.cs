using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawEvent"/> *after* its main action.
    /// Implementers react to the card draw once it has occurred.
    /// </summary>
    public interface IDrawEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DrawEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawEventArgs"/> for the event.</param>
        void OnDrawAfter(DrawEventArgs args);
    }
}