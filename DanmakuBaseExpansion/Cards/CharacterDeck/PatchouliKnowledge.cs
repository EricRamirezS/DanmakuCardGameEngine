using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class PatchouliKnowledge : BaseCharacterCard {
        public PatchouliKnowledge() : base(17, "Patchouli Knowledge", Seasons.Winter) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}