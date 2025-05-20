using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IReadOnlyDeck<TCard>: IReadOnlyList<IReadOnlyCard> where TCard : ICard {
        IDiscard<TCard> Discard { get; }
    }
}