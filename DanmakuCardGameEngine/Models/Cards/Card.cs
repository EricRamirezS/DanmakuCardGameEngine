using System;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Provides an abstract base implementation for a card in the Danmaku Card Game Engine.
    /// This class implements the <see cref="ICard"/> interface, providing common properties
    /// and behaviors for all types of cards, such as ID, name, associations, and basic equality.
    /// </summary>
    public class Card : ICard {
        /// <inheritdoc />
        public ICardType CardType { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the collection of modifiers associated with this card.
        /// By default, returns an empty collection of modifiers.
        /// Concrete card implementations can override this to provide specific modifiers.
        /// </summary>
        public virtual IModifiers Modifiers => Commons.Modifiers.Empty;

        /// <inheritdoc />
        /// <summary>
        /// Subscribes the card to relevant events managed by the provided event manager.
        /// This base implementation does nothing, allowing derived classes to implement
        /// specific event subscription logic.
        /// </summary>
        public virtual void Subscribe(IEventManager eventManager) { }

        /// <inheritdoc />
        /// <summary>
        /// Unsubscribes the card from events managed by the provided event manager.
        /// This base implementation does nothing, allowing derived classes to implement
        /// specific event unsubscription logic.
        /// </summary>
        public virtual void Unsubscribe(IEventManager eventManager) { }

        /// <inheritdoc />
        public int Id { get; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public ISeason Season { get; }

        /// <inheritdoc />
        public IExpansion Expansion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="cardType">The type of the card.</param>
        /// <param name="id">The unique identifier for the card.</param>
        /// <param name="name">The display name of the card.</param>
        /// <param name="season">The season associated with the card.</param>
        /// <param name="expansion">The expansion set to which the card belongs.</param>
        protected Card(ICardType cardType, int id, string name, ISeason season, IExpansion expansion) {
            CardType = cardType;
            Id = id;
            Name = name;
            Season = season;
            Expansion = expansion;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This implementation of <see cref="IEquatable{T}.Equals(T)"/> for <see cref="ICard"/>
        /// checks for null, reference equality, and then performs a type-safe comparison
        /// by deferring to the private <see cref="Equals(Card)"/> method.
        /// </remarks>
        public bool Equals(ICard obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            // Ensure the runtime types are the same before casting to Card for detailed comparison.
            return obj.GetType() == GetType() && Equals((Card)obj);
        }

        /// <inheritdoc />
        /// <summary>
        /// Converts the current card object into its read-only representation.
        /// </summary>
        /// <returns>A new <see cref="ReadOnlyCard"/> instance that wraps this card.</returns>
        public IReadOnlyCard ToReadOnly() {
            return new ReadOnlyCard(this);
        }

        /// <inheritdoc />
        public override string ToString() {
            return $"{Name} ({Id})";
        }

        /// <summary>
        /// Determines whether the current <see cref="Card"/> object is equal to another <see cref="Card"/> object.
        /// Equality is based on the <see cref="CardType"/>, <see cref="Id"/>, <see cref="Name"/>,
        /// <see cref="Season"/>, and <see cref="Expansion"/> properties.
        /// </summary>
        /// <param name="other">The <see cref="Card"/> object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="Card"/> is equal to the current object; otherwise, <c>false</c>.</returns>
        private bool Equals(Card other) {
            // Compares all relevant properties for equality.
            return Equals(CardType, other.CardType) &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Equals(Season, other.Season) &&
                   Equals(Expansion, other.Expansion);
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method overrides the base <see cref="object.Equals(object)"/> method.
        /// It checks for null, reference equality, and then performs a type-safe comparison
        /// by deferring to the private <see cref="Equals(Card)"/> method.
        /// </remarks>
        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            // Ensure the runtime type of the object is the same as this instance.
            // This is important for inheritance scenarios to ensure proper equality.
            if (obj.GetType() != GetType()) return false;
            return Equals((Card)obj);
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method overrides the base <see cref="object.GetHashCode()"/> method.
        /// The hash code is generated based on the <see cref="CardType"/>, <see cref="Id"/>,
        /// <see cref="Name"/>, <see cref="Season"/>, and <see cref="Expansion"/> properties,
        /// ensuring that equal objects have the same hash code.
        /// </remarks>
        public override int GetHashCode() {
            unchecked {
                // Combine hash codes of all relevant properties.
                // Using a prime number (397) for multiplication helps in distributing hash values more evenly.
                int hashCode = CardType != null ? CardType.GetHashCode() : 0;
                hashCode = hashCode * 397 ^ Id;
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ (Season != null ? Season.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ (Expansion != null ? Expansion.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}