using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Defines a read-only interface for a player in the Danmaku Card Game Engine.
    /// This interface provides access to essential player statistics and components
    /// without allowing direct modification, suitable for displaying player information
    /// to other players or for game logic that only needs to read player state.
    /// </summary>
    public interface IReadOnlyPlayer : IEquatablePlayer {
        /// <summary>
        /// Gets the current life points of the player.
        /// </summary>
        byte Life { get; }
        /// <summary>
        /// Gets the maximum life points the player can have.
        /// </summary>
        byte MaxLife { get; }
        /// <summary>
        /// Gets a value indicating whether the player has been defeated in the game.
        /// </summary>
        bool IsDefeated { get; }
        /// <summary>
        /// Gets the maximum number of cards the player can hold in their hand.
        /// </summary>
        byte MaxHandSize { get; }
        /// <summary>
        /// Gets a value indicating whether the player has used their spell card this ROUND.
        /// </summary>
        bool IsSpellCardUsed { get; }
        /// <summary>
        /// Gets the effective count of danmaku the player has played this round.
        /// </summary>
        byte DanmakuEffectiveCount { get; }
        /// <summary>
        /// Gets the current count of danmaku the player has played this round.
        /// </summary>
        byte DanmakuCount { get; }
        /// <summary>
        /// Gets the maximum limit of danmaku Cards the player can play each round.
        /// </summary>
        byte DanmakuLimit { get; }
        /// <summary>
        /// Gets the current range of the player's attacks.
        /// </summary>
        byte Range { get; }
        /// <summary>
        /// Gets any bonus to the player's distance calculation.
        /// </summary>
        byte DistanceBonus { get; }
        /// <summary>
        /// Gets a value indicating whether the player's role card has been revealed.
        /// </summary>
        bool IsRoleRevealed { get; }
        /// <summary>
        /// Gets the main character card currently associated with the player.
        /// </summary>
        ICharacterCard MainCharacterCard { get; }
        /// <summary>
        /// Gets the player's hand of cards in a read-only format.
        /// </summary>
        IReadOnlyHand Hand { get; }
        /// <summary>
        /// Gets the role card assigned to the player, null if the Role Card is Hidden.
        /// </summary>
        IRoleCard RoleCard { get; }
        /// <summary>
        /// Gets the player's item field, where item cards are played.
        /// </summary>
        IItemField ItemField { get; }
        /// <summary>
        /// Gets the collection of modifiers currently affecting the player.
        /// </summary>
        IModifiers Modifiers { get; }
    }

}