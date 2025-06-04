using System;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when an invalid number of players is provided, specifically when too few players are present.
    /// </summary>
    public class NoEnoughPlayersException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEnoughPlayersException"/> class with a specified error message.
        /// </summary>
        /// <param name="nPlayers">The number of players provided that was below the minimum limit.</param>
        public NoEnoughPlayersException(int nPlayers) : base(
            $"Game requires at most 8 players, but {nPlayers} were provided.") { }
    }
}