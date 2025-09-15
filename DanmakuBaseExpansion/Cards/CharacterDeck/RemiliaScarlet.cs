using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class RemiliaScarlet : BaseCharacterCard {
        public RemiliaScarlet() : base(20, "Remilia Scarlet", Seasons.Autumn) { }
        public override ICardTiming CardTiming { get; }
    }
}