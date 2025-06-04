using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ICardEntersDiscardPileEventBefore"/> and <see cref="ICardEntersDiscardPileEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardsEnterDiscardPileEvent"/>.
    /// </summary>
    public interface ICardEntersDiscardPileEvent : ICardEntersDiscardPileEventBefore, ICardEntersDiscardPileEventAfter { }
}