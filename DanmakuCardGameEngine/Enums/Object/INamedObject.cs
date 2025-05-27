using System;

namespace DanmakuCardGameEngine.Enums.Object {
    /// <summary>
    /// Represents an object that has a unique name and can be compared for equality based on that name.
    /// This interface is useful for identifying various game elements (e.g., cards, players, abilities)
    /// by a consistent string identifier.
    /// </summary>
    public interface INamedObject :
        IEquatable<INamedObject> {
        /// <summary>
        /// Gets the unique name of the object.
        /// This name should be used for identification and comparison purposes.
        /// </summary>
        string Name { get; }
    }
}