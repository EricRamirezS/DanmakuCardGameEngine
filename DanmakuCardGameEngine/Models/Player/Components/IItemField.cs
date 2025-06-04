using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuCardGameEngine.Models.Player.Components {
    /// <summary>
    /// Defines an interface for a player's item field, which holds <see cref="IItemCard"/> objects.
    /// It provides both mutable (<see cref="IList{T}"/>) and read-only (<see cref="IReadOnlyList{T}"/>)
    /// list functionalities for the item cards and is associated with a read-only player owner.
    /// </summary>
    // ReSharper disable once PossibleInterfaceMemberAmbiguity
    public interface IItemField : IList<IItemCard>, IReadOnlyList<IItemCard> {
        /// <summary>
        /// Gets the read-only representation of the player who owns this item field.
        /// </summary>
        IReadOnlyPlayer Owner { get; }
    }
}