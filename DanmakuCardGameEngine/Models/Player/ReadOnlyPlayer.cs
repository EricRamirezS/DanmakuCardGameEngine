using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Provides a concrete read-only implementation of a player, encapsulating their current state
    /// and properties without exposing mutable operations. This class is designed to offer a snapshot
    /// of a player's data at a given moment, suitable for display, logging, or game logic that
    /// requires immutable player information.
    /// </summary>
    public class ReadOnlyPlayer : EquatablePlayer, IReadOnlyPlayer {
        /// <inheritdoc />
        public override string Id { get; }

        /// <inheritdoc />
        public override string Name { get; }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the read-only player currently possesses or is associated with a specific character card.
        /// </summary>
        /// <param name="card">The character card to check for.</param>
        /// <returns><c>true</c> if the player has the character card; otherwise, <c>false</c>.</returns>
        public override bool HasCharacter(ICharacterCard card) {
            return card == MainCharacterCard;
        }

        /// <inheritdoc />
        public byte Life { get; }

        /// <inheritdoc />
        public byte MaxLife { get; }

        /// <inheritdoc />
        public bool IsDefeated { get; }

        /// <inheritdoc />
        public byte MaxHandSize { get; }

        /// <inheritdoc />
        public bool IsSpellCardUsed { get; }

        /// <inheritdoc />
        public byte DanmakuEffectiveCount { get; }

        /// <inheritdoc />
        public byte DanmakuCount { get; }

        /// <inheritdoc />
        public byte DanmakuLimit { get; }

        /// <inheritdoc />
        public byte Range { get; }

        /// <inheritdoc />
        public byte DistanceBonus { get; }

        /// <inheritdoc />
        public bool IsRoleRevealed { get; }

        /// <inheritdoc />
        public IReadOnlyHand Hand { get; }

        /// <inheritdoc />
        public IRoleCard RoleCard { get; }

        /// <inheritdoc />
        public IItemField ItemField { get; }

        /// <inheritdoc />
        public ICharacterCard MainCharacterCard { get; }

        /// <inheritdoc />
        public IModifiers Modifiers { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyPlayer"/> class
        /// by copying the current state from a mutable <see cref="IPlayer"/> instance.
        /// All properties are set to reflect the player's state at the time of creation.
        /// </summary>
        /// <param name="player">The mutable <see cref="IPlayer"/> instance from which to create the read-only view.</param>
        public ReadOnlyPlayer(IPlayer player) {
            Id = player.Id;
            Name = player.Name;
            Life = player.Life;
            MaxLife = player.MaxLife;
            MaxHandSize = player.MaxHandSize;
            IsSpellCardUsed = player.IsSpellCardUsed;
            IsDefeated = player.IsDefeated;
            DanmakuEffectiveCount = player.DanmakuEffectiveCount;
            DanmakuCount = player.DanmakuCount;
            DanmakuLimit = player.DanmakuLimit;
            MainCharacterCard = player.MainCharacterCard;
            IsRoleRevealed = player.IsRoleRevealed;
            // Only copy the RoleCard if it is revealed, otherwise it remains null in the read-only view.
            if (IsRoleRevealed) {
                RoleCard = player.RoleCard;
            }

            ItemField = player.ItemField;
            Range = player.Range;
            DistanceBonus = player.DistanceBonus;
            Modifiers = player.Modifiers;
            Hand = player.Hand.ToReadOnly();
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a JSON string representation of the current <see cref="ReadOnlyPlayer"/> object,
        /// formatted with indentation for readability.
        /// </summary>
        /// <returns>A JSON string representing the player's read-only state.</returns>
        public override string ToString() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}