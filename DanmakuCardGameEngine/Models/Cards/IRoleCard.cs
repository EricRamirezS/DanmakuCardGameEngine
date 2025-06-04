using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Defines an interface for a Role Card in the Danmaku Card Game Engine.
    /// Role cards assign a specific role to a player, often granting unique abilities,
    /// defining victory conditions, or influencing gameplay mechanics.
    /// </summary>
    public interface IRoleCard : ICard {
        /// <summary>
        /// Gets the primary role type assigned by this card.
        /// </summary>
        IRoleType RoleType { get; }
        /// <summary>
        /// Gets an optional alternate role type for this card, typically used for "Split Role" cards
        /// that can function as one of two different roles. If not applicable, this will be null.
        /// </summary>
        IRoleType AltRoleType { get; }
        /// <summary>
        /// Gets the number of players required for this role card to be included in the game setup.
        /// If null, Role Card will not be added to RoleDeck.
        /// </summary>
        int? RequiredPlayers { get; }
        /// <summary>
        /// Gets the revealed form of this role card. Some role cards may transform or reveal
        /// a different set of properties or abilities once revealed. If null, the card does not have a separate revealed form.
        /// </summary>
        IRoleCard RevealedForm { get; }
    }

}