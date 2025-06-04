using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ICardsCollectedEventBefore"/> and <see cref="ICardsCollectedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardsCollectedEvent"/>.
    /// </summary>
    public interface ICardsCollectedEvent : ICardsCollectedEventBefore, ICardsCollectedEventAfter { }
}