using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Defines an interface for a player entity that supports equality comparisons based on a unique identifier.
    /// This interface combines <see cref="IEquatable{T}"/> for instance-level equality and
    /// <see cref="IEqualityComparer{T}"/> for external comparison logic, ensuring consistent
    /// identification of players throughout the game.
    /// </summary>
    public interface IEquatablePlayer : IEquatable<IEquatablePlayer>, IEqualityComparer<IEquatablePlayer> {
        /// <summary>
        /// Gets the unique identifier for the player.
        /// This ID should be immutable and serve as the primary key for player identification.
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Gets the display name of the player.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Determines whether the player currently possesses or is associated with a specific character card.
        /// </summary>
        /// <param name="card">The character card to check for.</param>
        /// <returns><c>true</c> if the player has the character card; otherwise, <c>false</c>.</returns>
        bool HasCharacter(ICharacterCard card);
    }
}