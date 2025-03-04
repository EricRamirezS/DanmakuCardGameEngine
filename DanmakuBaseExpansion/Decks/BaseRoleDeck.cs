using DanmakuBaseExpansion.Cards.RoleDeck;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuBaseExpansion.Decks {
    internal static class BaseRoleDeck {
        public static IRoleDeck Get() => new RoleDeck() {
            new Heroine(1),
            new StageBoss(2),
            new StageBoss(3),
            new StageBoss(4),
            new ExBoss(),
            // new PhantasmBoss(),
            new Partner(9),
            new Partner(10),
            // new FinalBoss(11),
            // new AntiHeroine(12),
            // new Challenger(13),
            // new ExMidboss(14),
            // new OneTruePartner(15),
            // new Rival(16),
        };
    }
}