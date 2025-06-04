using System;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when an attempt is made to register a deck type that has already been registered.
    /// This prevents duplicate deck registrations within the game engine.
    /// </summary>
    public class DuplicatedDeckTypeException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatedDeckTypeException"/> class with a specified error message.
        /// </summary>
        /// <param name="type">The type of the deck that was attempted to be duplicated.</param>
        public DuplicatedDeckTypeException(Type type) : base($"A deck of type {type.Name} has already been registered.") { }
    }
}