using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    /// <summary>
    /// Represents a player's hand of cards, managing the collection of <see cref="IHandCard"/> objects.
    /// This class extends <see cref="List{T}"/> and implements the <see cref="IHand"/> interface,
    /// providing both mutable list functionalities and hand-specific operations.
    /// </summary>
    public class Hand : List<IHandCard>, IHand {
        private readonly IPlayer _player;

        /// <inheritdoc />
        public int MaxHandSize => _player.MaxHandSize;

        /// <inheritdoc />
        public int CardCount() => Count;
        /// <inheritdoc />
        public int CardCount<T>() where T : IHandCard => this.Count(e => e.GetType() == typeof(T));

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand"/> class for a specific player.
        /// </summary>
        /// <param name="player">The player to whom this hand belongs. The hand's <see cref="MaxHandSize"/>
        /// will be determined by this player's <see cref="IPlayer.MaxHandSize"/> property.</param>
        public Hand(IPlayer player) {
            _player = player;
        }
        /// <inheritdoc />
        public IReadOnlyHand ToReadOnly() {
            return new ReadOnlyHand(this);
        }
    }
}