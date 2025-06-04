using System;

namespace DanmakuCardGameEngine.Exceptions {

    /// <summary>
    /// Exception thrown when an attempt is made to access a deck that has not been found or registered.
    /// </summary>
    public class DeckNotFoundException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeckNotFoundException"/> class with a default error message.
        /// </summary>
        public DeckNotFoundException() : base("The requested deck was not found.") { }
    }
}
