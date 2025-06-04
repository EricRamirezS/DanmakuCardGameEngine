using System;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when a role deck is found but contains no cards.
    /// This indicates an empty deck, which prevents proper game setup.
    /// </summary>
    internal class RoleDeckEmptyException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDeckEmptyException"/> class with a default error message.
        /// </summary>
        public RoleDeckEmptyException() : base("A role deck was found, but it has no cards.") { }
    }
}