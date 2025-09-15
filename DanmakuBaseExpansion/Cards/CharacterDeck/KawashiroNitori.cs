using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KawashiroNitori : BaseCharacterCard {
        public KawashiroNitori() : base(10, "Kawashiro Nitori", Seasons.Autumn) { }
        public override ICardTiming CardTiming => CardTimings.Action;

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.Distance, this, 1, Durations.Active),
        };
    }
}