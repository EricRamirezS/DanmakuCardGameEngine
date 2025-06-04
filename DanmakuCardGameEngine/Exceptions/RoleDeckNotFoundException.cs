using System;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when no role deck is found in the game.
    /// This typically indicates a misconfiguration or missing game component.
    /// </summary>
    internal class RoleDeckNotFoundException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDeckNotFoundException"/> class with a default error message.
        /// </summary>
        public RoleDeckNotFoundException() : base("No role deck was found.") { }
    }
}