using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class AliceMargatroid : BaseCharacterCard {
        public AliceMargatroid() : base(1, "Alice Margatroid", Seasons.Autumn) { }
        public override ICardTiming CardTiming { get; }
    }
}