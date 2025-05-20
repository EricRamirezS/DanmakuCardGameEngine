using System;

namespace DanmakuCardGameEngine.Exceptions {
    public class TooManyPlayersException : Exception {
        public TooManyPlayersException(int nPlayers) : base(
            $"Game requires a least 4 players, but {nPlayers} were provided.") { }
    }
}