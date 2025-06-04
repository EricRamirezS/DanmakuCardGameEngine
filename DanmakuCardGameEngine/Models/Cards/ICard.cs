using System;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Defines the fundamental interface for any card within the Danmaku Card Game Engine.
    /// This interface provides core properties common to all cards, such as ID, name,
    /// associations with seasons and expansions, card type, and any modifiers it applies.
    /// It also includes methods for event subscription/unsubscription and equality comparison.
    /// </summary>
    public interface ICard : IEquatable<ICard>, IReadOnlyConverter<IReadOnlyCard> {
        /// <summary>
        /// Gets the unique identifier for the card.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Gets the display name of the card.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the season associated with the card.
        /// </summary>
        ISeason Season { get; }
        /// <summary>
        /// Gets the expansion set to which the card belongs.
        /// </summary>
        IExpansion Expansion { get; }
        /// <summary>
        /// Gets the type of the card (e.g., Character, Item, Spell).
        /// </summary>
        ICardType CardType { get; }
        /// <summary>
        /// Gets the collection of modifiers associated with this card.
        /// </summary>
        IModifiers Modifiers { get; }

        /// <summary>
        /// Subscribes the card to relevant events managed by the provided event manager.
        /// </summary>
        /// <param name="eventManager">The event manager to subscribe to.</param>
        void Subscribe(IEventManager eventManager);
        /// <summary>
        /// Unsubscribes the card from events managed by the provided event manager.
        /// </summary>
        /// <param name="eventManager">The event manager to unsubscribe from.</param>
        void Unsubscribe(IEventManager eventManager);
    }
}