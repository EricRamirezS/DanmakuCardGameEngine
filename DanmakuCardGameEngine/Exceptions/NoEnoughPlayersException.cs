using System;

namespace DanmakuCardGameEngine.Exceptions {
    public class NoEnoughPlayersException : Exception {
        public NoEnoughPlayersException(int nPlayers) : base(
            $"Game requires at most 8 players, but {nPlayers} were provided.") { }
    }
}