using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Defines the comprehensive interface for a player in the Danmaku Card Game Engine.
    /// This interface extends various other interfaces to encapsulate all aspects of a player's
    /// state, actions, and decision-making capabilities.
    /// </summary>
    public interface IPlayer : IDecisionMaker, IReadOnlyConverter<IReadOnlyPlayer>, IEquatablePlayer, IEquatable<IReadOnlyPlayer>{
        /// <summary>
        /// Gets or sets the current life points of the player.
        /// </summary>
        byte Life { get; set; }
        /// <summary>
        /// Gets the maximum life points the player can have.
        /// </summary>
        byte MaxLife { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the player has used their spell card this turn/round.
        /// </summary>
        bool IsSpellCardUsed { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the player has been defeated in the game.
        /// </summary>
        bool IsDefeated { get; set; }
        /// <summary>
        /// Gets or sets the effective count of danmaku (bullets) the player has accumulated.
        /// This might be used for mechanics that scale with danmaku count.
        /// </summary>
        byte DanmakuEffectiveCount { get; set; }
        /// <summary>
        /// Gets or sets the current count of danmaku (bullets) the player has.
        /// </summary>
        byte DanmakuCount { get; set; }
        /// <summary>
        /// Gets the maximum limit of danmaku (bullets) the player can hold.
        /// </summary>
        byte DanmakuLimit { get; }
        /// <summary>
        /// Gets the maximum number of cards the player can hold in their hand.
        /// </summary>
        byte MaxHandSize { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the player's role card has been revealed.
        /// </summary>
        bool IsRoleRevealed { get; set; }
        /// <summary>
        /// Gets the current range of the player's attacks.
        /// </summary>
        byte Range { get; }
        /// <summary>
        /// Gets any bonus to the player's distance calculation.
        /// </summary>
        byte DistanceBonus { get; }
        /// <summary>
        /// Gets the player's hand of cards.
        /// </summary>
        IHand Hand { get; }
        /// <summary>
        /// Gets or sets the main character card currently associated with the player.
        /// </summary>
        ICharacterCard MainCharacterCard { get; set; }
        /// <summary>
        /// Gets or sets the role card assigned to the player.
        /// </summary>
        IRoleCard RoleCard { get; set; }
        /// <summary>
        /// Gets the player's item field, where item cards are played.
        /// </summary>
        IItemField ItemField { get; }
        /// <summary>
        /// Gets the collection of modifiers currently affecting the player.
        /// </summary>
        IModifiers Modifiers { get; }

        /// <summary>
        /// Gets or sets the default data associated with the player, potentially for resetting or initial state.
        /// </summary>
        IDefaultData DefaultData { get; set; }

        /// <summary>
        /// Asynchronously draws a specified quantity of cards of a particular type into the player's hand.
        /// </summary>
        /// <typeparam name="TCard">The type of <see cref="IHandCard"/> to draw.</typeparam>
        /// <param name="quantity">The number of cards to draw.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DrawCards<TCard>(int quantity) where TCard : IHandCard;
        /// <summary>
        /// Asynchronously plays a specified card from the player's hand or other valid location.
        /// </summary>
        /// <param name="card">The card to play.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task PlayCard(ICard card);
        /// <summary>
        /// Asynchronously initiates an attack from this player towards a target read-only player.
        /// </summary>
        /// <param name="player">The read-only representation of the player to attack.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Attack(IReadOnlyPlayer player);
        /// <summary>
        /// Asynchronously applies damage to the player's life points.
        /// </summary>
        /// <param name="damage">The amount of damage to take.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task TakeDamage(int damage);

        /// <summary>
        /// Initializes or re-initializes the player's core statistics and components.
        /// </summary>
        void InitStats();
    }
}
