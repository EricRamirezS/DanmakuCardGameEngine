using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class IbukiSuika : BaseCharacterCard {
        public IbukiSuika() : base(7, "Ibuki Suika", Seasons.Summer) { }
        public override ICardTiming CardTiming => CardTimings.Action;

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.Range, this, 1, Durations.Active),
            new ModifierData(ModifierNames.AdditionalDanmaku, this, 1, Durations.Active),
        };
    }
}