using System;
using System.Collections;
using System.Collections.Generic;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public abstract class ReadOnlyDeckManager : IReadOnlyDeckManager {
        protected readonly Dictionary<Type, IList> Decks = new Dictionary<Type, IList>();

        public IReadOnlyDeck<TCard> GetReadOnlyDeck<TCard>() where TCard : ICard {
            if (!Decks.ContainsKey(typeof(TCard))) return null;

            IList deck = Decks[typeof(TCard)];
            return ((IDeck<TCard>)deck).ToReadOnly();
        }

        public bool ContainsDeck<TCard>() where TCard : ICard {
            return Decks.ContainsKey(typeof(TCard));
        }
    }
}