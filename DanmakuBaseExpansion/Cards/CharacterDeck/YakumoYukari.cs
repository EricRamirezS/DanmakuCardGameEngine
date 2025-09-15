using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class YakumoYukari : BaseCharacterCard {
        public YakumoYukari() : base(24, "Yakumo Yukari", Seasons.Spring) { }
        public override ICardTiming CardTiming { get; }
    }
}