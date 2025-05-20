using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public class Hand : List<IHandCard>, IHand {
        private readonly IPlayer _player;
        public int MaxHandSize => _player.MaxHandSize;
        public int CardCount() => Count;
        public int CardCount<T>() where T : IHandCard => this.Count(e => e.GetType() == typeof(T));

        public Hand(IPlayer player) {
            _player = player;
        }
        public IReadOnlyHand ToReadOnly() {
            return new ReadOnlyHand(this);
        }
    }
}