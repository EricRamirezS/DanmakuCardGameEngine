using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class IbukiSuika : BaseCharacterCard {
        public IbukiSuika() : base(7, "Ibuki Suika", Seasons.Summer) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}