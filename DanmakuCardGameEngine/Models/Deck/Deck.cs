using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Deck {
    public class Deck<TCard> : List<TCard>, IDeck<TCard> where TCard : ICard {
        private readonly IRandomGenerator _rng;
        public IDiscard<TCard> Discard { get; } = new Discard<TCard>();

        protected Deck() : this(new RandomGenerator()) { }

        private Deck(IRandomGenerator randomGenerator) {
            _rng = randomGenerator;
        }

        public static implicit operator ReadOnlyDeck<TCard>(Deck<TCard> m) {
            return new ReadOnlyDeck<TCard>(m);
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

        public Task AddToDiscard(TCard card) {
            Discard.Add(card);
            return Task.CompletedTask;
        }

        ICard IDeck.Draw() => Draw();

        IList<ICard> IDeck.Draw(int numberOfCards) => Draw(numberOfCards).Cast<ICard>().ToList();

        Task IDeck.AddToDiscard(ICard card) => AddToDiscard((TCard)card);

        IDiscard IDeck.GetDiscard() => Discard;

        public IReadOnlyDeck<TCard> ToReadOnly() {
            return new ReadOnlyDeck<TCard>(this);
        }
    }
}