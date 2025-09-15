using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class HinanawiTenshi : BaseCharacterCard {
        public HinanawiTenshi() : base(5, "Hinanawi Tenshi", Seasons.Summer) { }
        public override ICardTiming CardTiming { get; }
    }
}