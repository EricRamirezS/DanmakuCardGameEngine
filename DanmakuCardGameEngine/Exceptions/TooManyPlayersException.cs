using System;

namespace DanmakuCardGameEngine.Core {
    public class TooManyPlayersException : Exception {
        public TooManyPlayersException(int nPlayers) : base(
            $"Game requires a least 4 players, but {nPlayers} were provided.") { }
    }
}