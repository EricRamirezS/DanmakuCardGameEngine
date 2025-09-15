using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class Cirno : BaseCharacterCard {
        public Cirno() : base(2, "Cirno", Seasons.Winter) { }
        public override ICardTiming CardTiming => CardTimings.Action;

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.Range, this, 2, Durations.Active),
        };
    }
}