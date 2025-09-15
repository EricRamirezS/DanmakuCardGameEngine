using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class ToyosatomimiNoMiko : BaseCharacterCard {
        public ToyosatomimiNoMiko() : base(22, "Toyosatomimi No Miko", Seasons.Summer) { }
        public override ICardTiming CardTiming { get; }
    }
}