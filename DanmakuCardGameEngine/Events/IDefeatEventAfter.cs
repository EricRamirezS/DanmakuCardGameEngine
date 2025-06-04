using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DefeatEvent"/> *after* its main action.
    /// Implementers react to the defeat once it has occurred.
    /// </summary>
    public interface IDefeatEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DefeatEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DefeatEventArgs"/> for the event.</param>
        void OnDefeatAfter(DefeatEventArgs args);
    }
}