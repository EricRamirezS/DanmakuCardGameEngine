using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KamishirasawaKeine : BaseCharacterCard {
        public KamishirasawaKeine() : base(9, "Kamishirasawa Keine", Seasons.Winter) { }
        public override ICardTiming CardTiming { get; }
    }
}