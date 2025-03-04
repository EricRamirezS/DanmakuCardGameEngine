using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Deck {
    public class Deck<TCard> : List<TCard>, IDeck<TCard> where TCard : ICard {
        private readonly IRandomGenerator _rng;
        public Discard<TCard> Discard = new Discard<TCard>();

        public Deck() : this(new RandomGenerator()) { }

        public Deck(IRandomGenerator randomGenerator) {
            _rng = randomGenerator;
        }

        public static implicit operator ReadOnlyDeck<TCard>(Deck<TCard> m) {
            return new ReadOnlyDeck<TCard>(m.Count);
        }

        public void Shuffle() {
            int n = Count;
            while (n > 1) {
                n--;
                int k = _rng.Next(n + 1);
                (this[k], this[n]) = (this[n], this[k]);
            }
        }

        public TCard Draw() {
            if (Count <= 0) {
                AddRange(Discard);
                Discard.Clear();
                Shuffle();
            }

            try {
                int lastIndex = Count - 1;
                TCard card = this[lastIndex];
                RemoveAt(lastIndex);
                return card;
            }
            catch (ArgumentOutOfRangeException) {
                throw new NoCardsLeftException<TCard>(this);
            }
        }

        public IList<TCard> Draw(int numberOfCard) {
            IList<TCard> list = new List<TCard>();
            while (numberOfCard-- > 0) {
                list.Add(Draw());
            }

            return list;
        }

        public void AddToDiscard(TCard card) {
            Discard.Add(card);
        }
    }
}