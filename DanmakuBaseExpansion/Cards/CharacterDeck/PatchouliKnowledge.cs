using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class PatchouliKnowledge : BaseCharacterCard {
        public PatchouliKnowledge() : base(17, "Patchouli Knowledge", Seasons.Winter) { }
        public override ICardTiming CardTiming => CardTimings.Action;

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.MaxHand, this, 3, Durations.Active),
        };
    }
}