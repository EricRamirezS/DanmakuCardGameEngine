using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ICardResolvedEventBefore"/> and <see cref="ICardResolvedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardResolvedEvent"/>.
    /// </summary>
    public interface ICardResolvedEvent : ICardResolvedEventBefore, ICardResolvedEventAfter { }
}