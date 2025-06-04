using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncreasedHealthEvent"/> *after* its main action.
    /// Implementers react to the health increase once it has occurred.
    /// </summary>
    public interface IIncreasedHealthEventAfter {
        /// <summary>
        /// Handler method for the <see cref="IncreasedHealthEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncreasedHealthEventArgs"/> for the event.</param>
        void OnIncreasedHealthAfter(IncreasedHealthEventArgs args);
    }
}