using System.Collections;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    // ReSharper disable once PossibleInterfaceMemberAmbiguity
    public interface IDeck<TCard> : IReadOnlyDeck<TCard>, IList<TCard>, IReadOnlyList<TCard>, IShuffleable
        where TCard : ICard {
        TCard Draw();

        IList<TCard> Draw(int numberOfCard);

        void AddToDiscard(TCard card);
    }

    public interface IShuffleable {
        void Shuffle();
    }
}