using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuCardGameEngine.Models.Player.Components {
    /// <summary>
    /// Represents a player's item field, which holds a collection of <see cref="IItemCard"/> objects.
    /// This class extends <see cref="List{T}"/> and implements the <see cref="IItemField"/> interface,
    /// providing both mutable list functionalities and associating the field with its owner.
    /// </summary>
    public class ItemField : List<IItemCard>, IItemField {
        private readonly IPlayer _owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemField"/> class for a specific player owner.
        /// </summary>
        /// <param name="owner">The player who owns this item field.</param>
        public ItemField(IPlayer owner) {
            _owner = owner;
        }

        /// <summary>
        /// Gets the read-only representation of the player who owns this item field.
        /// </summary>
        public IReadOnlyPlayer Owner => _owner.ToReadOnly();
    }
}