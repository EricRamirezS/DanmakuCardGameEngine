using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardResolvedEvent"/> *after* its main action.
    /// Implementers react to the card resolution once it has occurred.
    /// </summary>
    public interface ICardResolvedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardResolvedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardResolvedEventArgs"/> for the event.</param>
        void OnCardResolvedAfter(CardResolvedEventArgs args);
    }
}