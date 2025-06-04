using System;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when a game operation is attempted before the game has been properly set up or initialized.
    /// </summary>
    public class GameNotSetException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameNotSetException"/> class with a default error message.
        /// </summary>
        public GameNotSetException() : base("Game has not been set up or initialized.") { }
    }
}