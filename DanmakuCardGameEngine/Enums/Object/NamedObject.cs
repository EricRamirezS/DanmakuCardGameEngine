using System;

namespace DanmakuCardGameEngine.Enums.Object {
    /// <summary>
    /// Provides an abstract base class for objects that have a unique name and can be compared for equality.
    /// It implements the <see cref="INamedObject"/> interface and provides standard implementations
    /// for equality checks and hash code generation based on the object's <see cref="Name"/> and <see cref="UniqueGroup"/>.
    /// </summary>
    [Serializable]
    public abstract class NamedObject : INamedObject {
        /// <summary>
        /// Gets the unique name of the object.
        /// This name is used for identification and comparison.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets an optional unique group identifier for the object.
        /// This can be used to further distinguish objects with the same name but belonging to different categories or sets.
        /// </summary>
        private string UniqueGroup { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedObject"/> class with the specified name.
        /// The <see cref="UniqueGroup"/> will be initialized to <c>null</c>.
        /// </summary>
        /// <param name="name">The unique name of the object.</param>
        protected NamedObject(string name) {
            Name = name;
            UniqueGroup = null; // Initialize UniqueGroup to null by default
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedObject"/> class with the specified name and unique group.
        /// </summary>
        /// <param name="name">The unique name of the object.</param>
        /// <param name="uniqueGroup">An optional unique group identifier for the object.</param>
        protected NamedObject(string name, string uniqueGroup) {
            Name = name;
            UniqueGroup = uniqueGroup;
        }

        /// <summary>
        /// Overloads the equality operator (==) for <see cref="NamedObject"/> and <see cref="INamedObject"/>.
        /// Compares two objects for equality based on their <see cref="Name"/> and <see cref="UniqueGroup"/>.
        /// </summary>
        /// <param name="obj1">The first <see cref="NamedObject"/> to compare.</param>
        /// <param name="obj2">The second <see cref="INamedObject"/> to compare.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(NamedObject obj1, INamedObject obj2) {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            return !ReferenceEquals(obj2, null) && obj1.Equals(obj2);
        }

        /// <summary>
        /// Overloads the inequality operator (!=) for <see cref="NamedObject"/> and <see cref="INamedObject"/>.
        /// </summary>
        /// <param name="obj1">The first <see cref="NamedObject"/> to compare.</param>
        /// <param name="obj2">The second <see cref="INamedObject"/> to compare.</param>
        /// <returns><c>true</c> if the objects are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(NamedObject obj1, INamedObject obj2) => !(obj1 == obj2);

        /// <summary>
        /// Determines whether the current <see cref="NamedObject"/> is equal to another <see cref="NamedObject"/>.
        /// Equality is based on both <see cref="Name"/> and <see cref="UniqueGroup"/>.
        /// </summary>
        /// <param name="other">The <see cref="NamedObject"/> to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="NamedObject"/> is equal to the current object; otherwise, <c>false</c>.</returns>
        protected bool Equals(NamedObject other) {
            // If other is null, return false
            if (other is null) return false;
            return Name == other.Name && UniqueGroup == other.UniqueGroup;
        }

        /// <summary>
        /// Determines whether the current <see cref="NamedObject"/> is equal to the specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            // Check if the runtime type of the object is the same as this instance.
            // This is important for inheritance scenarios to ensure proper equality.
            if (obj.GetType() != GetType()) return false;
            return Equals((NamedObject)obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// A hash code for the current object is generated based on its <see cref="Name"/> and <see cref="UniqueGroup"/>.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() {
            unchecked {
                // Combine hash codes of Name and UniqueGroup.
                // Using a prime number (397) for multiplication helps in distributing hash values more evenly.
                return (Name != null ? Name.GetHashCode() : 0) * 397 ^ (UniqueGroup != null ? UniqueGroup.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// Determines whether the current <see cref="NamedObject"/> is equal to another <see cref="INamedObject"/>.
        /// This method is part of the <see cref="IEquatable{T}"/> interface implementation.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
        public bool Equals(INamedObject other) {
            // Cast to object and use the override Equals(object obj) for consistency.
            // This handles null checks and type checks implicitly.
            return Equals((object)other);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// By default, this returns the <see cref="Name"/> of the object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() {
            return Name;
        }
    }
}
