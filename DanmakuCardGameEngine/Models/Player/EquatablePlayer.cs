using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Provides an abstract base class for player entities that implement equality comparisons
    /// based on their unique identifier and name. This class handles the core logic for
    /// <see cref="IEquatable{T}"/> and <see cref="IEqualityComparer{T}"/> for player objects.
    /// </summary>
    public abstract class EquatablePlayer : IEquatablePlayer {
        /// <inheritdoc />
        public abstract string Id { get; }
        /// <inheritdoc />
        public abstract string Name { get; }
        /// <inheritdoc />
        public abstract bool HasCharacter(ICharacterCard card);

        /// <summary>
        /// Overloads the equality operator (==) for <see cref="EquatablePlayer"/> instances.
        /// Compares two <see cref="EquatablePlayer"/> objects for equality using the <see cref="AreEquals(IEquatablePlayer, IEquatablePlayer)"/> method.
        /// </summary>
        /// <param name="left">The first <see cref="EquatablePlayer"/> to compare.</param>
        /// <param name="right">The second <see cref="EquatablePlayer"/> to compare.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(EquatablePlayer left, EquatablePlayer right) {
            return AreEquals(left, right);
        }

        /// <summary>
        /// Overloads the inequality operator (!=) for <see cref="EquatablePlayer"/> instances.
        /// </summary>
        /// <param name="left">The first <see cref="EquatablePlayer"/> to compare.</param>
        /// <param name="right">The second <see cref="EquatablePlayer"/> to compare.</param>
        /// <returns><c>true</c> if the objects are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(EquatablePlayer left, EquatablePlayer right) {
            return !(left == right);
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method implements the <see cref="IEquatable{T}.Equals(T)"/> interface for <see cref="IEquatablePlayer"/>.
        /// Equality is determined by comparing the <see cref="Id"/> and <see cref="Name"/> properties.
        /// </remarks>
        public bool Equals(IEquatablePlayer other) {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Name == other.Name;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method overrides the base <see cref="object.Equals(object)"/> method.
        /// It checks for null, reference equality, and then attempts to cast the object to <see cref="IEquatablePlayer"/>
        /// before calling the type-specific <see cref="Equals(IEquatablePlayer)"/> method.
        /// </remarks>
        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is IEquatablePlayer e) return Equals(e);
            return false;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method overrides the base <see cref="object.GetHashCode()"/> method.
        /// The hash code is generated based on the <see cref="Id"/> and <see cref="Name"/> properties,
        /// ensuring that equal objects have the same hash code.
        /// </remarks>
        public override int GetHashCode() {
            unchecked {
                return (Id != null ? Id.GetHashCode() : 0) * 397 ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// Determines whether two <see cref="IEquatablePlayer"/> instances are equal.
        /// This static method provides a null-safe way to compare two player objects based on their ID and Name.
        /// </summary>
        /// <param name="x">The first <see cref="IEquatablePlayer"/> to compare.</param>
        /// <param name="y">The second <see cref="IEquatablePlayer"/> to compare.</param>
        /// <returns><c>true</c> if the two players are equal; otherwise, <c>false</c>.</returns>
        public static bool AreEquals(IEquatablePlayer x, IEquatablePlayer y) {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method implements the <see cref="IEqualityComparer{T}.Equals(T, T)"/> interface for <see cref="IEquatablePlayer"/>.
        /// It provides a way to compare two <see cref="IEquatablePlayer"/> objects for equality, handling nulls.
        /// </remarks>
        public bool Equals(IEquatablePlayer x, IEquatablePlayer y) {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method implements the <see cref="IEqualityComparer{T}.GetHashCode(T)"/> interface for <see cref="IEquatablePlayer"/>.
        /// It provides a hash code for the specified <see cref="IEquatablePlayer"/> object,
        /// ensuring that equal objects have the same hash code.
        /// </remarks>
        public int GetHashCode(IEquatablePlayer obj) {
            unchecked {
                return (obj.Id != null ? obj.Id.GetHashCode() : 0) * 397 ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }
    }
}
