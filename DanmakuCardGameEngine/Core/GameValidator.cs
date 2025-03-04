using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    internal static class GameValidator {
        public static void ValidateNumberOfPlayers(int nPlayers) {
            if (nPlayers < 4) throw new NoEnoughPlayersException(nPlayers);
            if (nPlayers > 8) throw new TooManyPlayersException(nPlayers);
        }

        public static void ValidateRoles(Deck<RoleCard> getDeck) {
            throw new System.NotImplementedException();
        }
    }
}