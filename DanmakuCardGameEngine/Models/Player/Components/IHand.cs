using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IHand : IReadOnlyHand {
        List<IHandCard> Cards { get; }

        IReadOnlyHand ToReadOnlyHand();
    }

    public interface IReadOnlyHand {
        int Count { get; }
        int MaxHandSize { get; }
        int CardCount();
        int CardCount<T>() where T : IHandCard;
    }

    public class ReadOnlyHand : IReadOnlyHand {
        internal List<IHandCard> _cards = new List<IHandCard>();

        public int Count => _cards.Count;
        public int MaxHandSize { get; }
        public int CardCount() => _cards.Count;
        public int CardCount<T>() where T : IHandCard => _cards.Count(e => e.GetType() == typeof(T));

        internal ReadOnlyHand(int maxHandSize) {
            MaxHandSize = maxHandSize;
        }
    }

    public class Hand : ReadOnlyHand, IHand {
        private IPlayer _player;
        public new int MaxHandSize => _player.MaxHandSize;

        public Hand(IPlayer player) : base(0) {
            _player = player;
        }
        public List<IHandCard> Cards => _cards;
        public IReadOnlyHand ToReadOnlyHand() {
            return new ReadOnlyHand(maxHandSize: _player.MaxHandSize) {
                _cards = Cards,
            };
        }
    }
}