using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawStepEvent"/> *after* its main action.
    /// Implementers react to the draw step once it has occurred.
    /// </summary>
    public interface IDrawStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DrawStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawStepEventArgs"/> for the event.</param>
        void OnDrawStepAfter(DrawStepEventArgs args);
    }
}