using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Provides an abstract base implementation for a player in the Danmaku Card Game Engine.
    /// This class handles common player properties and behaviors, and serves as a foundation
    /// for concrete player implementations (e.g., human players, AI players).
    /// It implements <see cref="IPlayer"/> and extends <see cref="EquatablePlayer"/> for equality.
    /// </summary>
    public abstract partial class Player : EquatablePlayer, IPlayer {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with a specified name.
        /// A unique ID is generated for the player upon creation.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        protected Player(string name) {
            Id = Guid.NewGuid().ToString(); // Generates a unique ID for the player
            Name = name;
            MainCharacterCard = null; // Default to no main character card
            RoleCard = null; // Default to no role card
            ItemField = new ItemField(this); // Initializes the player's item field
            IsRoleRevealed = false; // Role is initially hidden
            Life = 4; // Default starting life
            IsSpellCardUsed = false; // Spell card not used at start
            IsDefeated = false; // Player is not defeated at start
            DanmakuEffectiveCount = 0; // Initial effective danmaku count
            DanmakuCount = 0; // Initial danmaku count
            Hand = new Hand(this); // Initializes the player's hand
        }

        /// <inheritdoc />
        public override string Id { get; }
        /// <inheritdoc />
        public override string Name { get; }
        /// <inheritdoc />
        public byte Life { get; set; }
        /// <summary>
        /// Gets the maximum life points the player can have.
        /// This value is determined by the <see cref="GetMaxLife"/> method, allowing for dynamic calculation.
        /// </summary>
        public byte MaxLife => GetMaxLife();
        /// <summary>
        /// Gets the maximum number of cards the player can hold in their hand.
        /// This value is determined by the <see cref="GetMaxHandSize"/> method.
        /// </summary>
        public byte MaxHandSize => GetMaxHandSize();

        /// <inheritdoc />
        public bool IsSpellCardUsed { get; set; }
        /// <inheritdoc />
        public bool IsDefeated { get; set; }
        /// <inheritdoc />
        public byte DanmakuEffectiveCount { get; set; }
        /// <inheritdoc />
        public byte DanmakuCount { get; set; }
        /// <summary>
        /// Gets the maximum limit of danmaku (bullets) the player can hold.
        /// This value is determined by the <see cref="GetDanmakuLimit"/> method.
        /// </summary>
        public byte DanmakuLimit => GetDanmakuLimit();
        /// <inheritdoc />
        public bool IsRoleRevealed { get; set; }
        /// <summary>
        /// Gets the current range of the player's attacks.
        /// This value is determined by the <see cref="GetRange"/> method.
        /// </summary>
        public byte Range => GetRange();
        /// <summary>
        /// Gets any bonus to the player's distance calculation.
        /// This value is determined by the <see cref="GetDistanceBonus"/> method.
        /// </summary>
        public byte DistanceBonus => GetDistanceBonus();
        /// <inheritdoc />
        public IHand Hand { get; }
        /// <inheritdoc />
        public ICharacterCard MainCharacterCard { get; set; }
        /// <inheritdoc />
        public IRoleCard RoleCard { get; set; }
        /// <inheritdoc />
        public IItemField ItemField { get; }
        /// <summary>
        /// Gets the collection of modifiers currently affecting the player.
        /// This collection is determined by the <see cref="GetModifiers"/> method.
        /// </summary>
        public IModifiers Modifiers => GetModifiers();

        /// <inheritdoc />
        /// <remarks>
        /// The <see cref="JsonIgnoreAttribute"/> is applied to prevent this property from being
        /// serialized by JSON.NET, as it likely represents transient or derived data.
        /// </remarks>
        [JsonIgnore] public IDefaultData DefaultData { get; set; }

        /// <inheritdoc />
        public async Task DrawCards<TCard>(int quantity) where TCard : IHandCard {
            await GameCore.Instance.DrawCards<TCard>(this, quantity);
        }

        /// <inheritdoc />
        public abstract Task PlayCard(ICard card);
        /// <inheritdoc />
        public abstract Task Attack(IReadOnlyPlayer player);
        /// <inheritdoc />
        public abstract Task TakeDamage(int damage);
        /// <inheritdoc />
        public abstract Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState, CancellationToken cancellationToken = default);
        /// <inheritdoc />
        public abstract T Choose<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);

        /// <inheritdoc />
        public void InitStats() {
            // If the player's role is Heroine, reveal it at the start of stats initialization.
            if (RoleCard.Id == 1 && RoleCard.Name == "Heroine" &&
                RoleCard.RoleType == RoleTypes.Heroine) {
                RevealRole();
            }

            Life = MaxLife; // Reset life to maximum
            IsSpellCardUsed = false; // Reset spell card usage
            IsDefeated = false; // Ensure player is not marked as defeated
        }

        /// <summary>
        /// Sets the <see cref="IsRoleRevealed"/> property to <c>true</c>, indicating that the player's role is now public.
        /// </summary>
        private void RevealRole() {
            IsRoleRevealed = true;
        }

        /// <inheritdoc />
        public IReadOnlyPlayer ToReadOnly() {
            return new ReadOnlyPlayer(this);
        }

        /// <inheritdoc />
        public override bool HasCharacter(ICharacterCard card) {
            // Checks if the player's MainCharacterCard is the same as the provided card.
            return MainCharacterCard == card;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method implements the <see cref="IEquatable{T}.Equals(T)"/> for <see cref="IReadOnlyPlayer"/>
        /// by deferring to the base <see cref="EquatablePlayer.Equals(IEquatablePlayer)"/> implementation.
        /// </remarks>
        public bool Equals(IReadOnlyPlayer other) {
            return base.Equals(other);
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method overrides the base <see cref="EquatablePlayer.Equals(object)"/> method,
        /// ensuring consistent equality checks for player objects.
        /// </remarks>
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method overrides the base <see cref="EquatablePlayer.GetHashCode()"/> method,
        /// ensuring that the hash code is consistently generated based on the player's ID and Name.
        /// </remarks>
        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode(); // Start with base hash code
                hashCode = hashCode * 397 ^ (Id != null ? Id.GetHashCode() : 0); // Include Id hash code
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0); // Include Name hash code
                return hashCode;
            }
        }

        /// <summary>
        /// Overloads the equality operator (==) for <see cref="Player"/> and <see cref="IReadOnlyPlayer"/> instances.
        /// Compares two player objects for equality using the <see cref="EquatablePlayer.AreEquals(IEquatablePlayer, IEquatablePlayer)"/> method.
        /// </summary>
        /// <param name="left">The <see cref="Player"/> instance on the left side of the operator.</param>
        /// <param name="right">The <see cref="IReadOnlyPlayer"/> instance on the right side of the operator.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Player left, IReadOnlyPlayer right) {
            return AreEquals(left, right);
        }

        /// <summary>
        /// Overloads the inequality operator (!=) for <see cref="Player"/> and <see cref="IReadOnlyPlayer"/> instances.
        /// </summary>
        /// <param name="left">The <see cref="Player"/> instance on the left side of the operator.</param>
        /// <param name="right">The <see cref="IReadOnlyPlayer"/> instance on the right side of the operator.</param>
        /// <returns><c>true</c> if the objects are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Player left, IReadOnlyPlayer right) {
            return !AreEquals(left, right);
        }

        /// <summary>
        /// Overloads the equality operator (==) for <see cref="IReadOnlyPlayer"/> and <see cref="Player"/> instances.
        /// Compares two player objects for equality using the <see cref="EquatablePlayer.AreEquals(IEquatablePlayer, IEquatablePlayer)"/> method.
        /// </summary>
        /// <param name="left">The <see cref="IReadOnlyPlayer"/> instance on the left side of the operator.</param>
        /// <param name="right">The <see cref="Player"/> instance on the right side of the operator.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(IReadOnlyPlayer left, Player right) {
            return AreEquals(left, right);
        }

        /// <summary>
        /// Overloads the inequality operator (!=) for <see cref="IReadOnlyPlayer"/> and <see cref="Player"/> instances.
        /// </summary>
        /// <param name="left">The <see cref="IReadOnlyPlayer"/> instance on the left side of the operator.</param>
        /// <param name="right">The <see cref="Player"/> instance on the right side of the operator.</param>
        /// <returns><c>true</c> if the objects are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(IReadOnlyPlayer left, Player right) {
            return !AreEquals(left, right);
        }
    }
}