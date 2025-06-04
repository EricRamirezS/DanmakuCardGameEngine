using System;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when an invalid number of players is provided, specifically when too many players are present.
    /// </summary>
    public class TooManyPlayersException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyPlayersException"/> class with a specified error message.
        /// </summary>
        /// <param name="nPlayers">The number of players provided that exceeded the limit.</param>
        public TooManyPlayersException(int nPlayers) : base(
            $"Game requires a least 4 players, but {nPlayers} were provided.") { }
    }
}