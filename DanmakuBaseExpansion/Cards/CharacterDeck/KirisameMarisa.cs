using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KirisameMarisa : BaseCharacterCard {
        public KirisameMarisa() : base(12, "Kirisame Marisa", Seasons.Summer) { }
        public override ICardTiming CardTiming { get; }
    }
}