using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class ReadOnlyDeck<TCard> : List<IReadOnlyCard>, IReadOnlyDeck<TCard> where TCard : ICard {
        public ReadOnlyDeck(IDeck<TCard> deck) {
            Discard = deck.Discard;
            foreach (TCard card in deck) {
                Add(card.ToReadOnly());
            }
        }

        public IDiscard<TCard> Discard { get; }
    }
}