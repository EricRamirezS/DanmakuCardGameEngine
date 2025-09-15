using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class IzayoiSakuya : BaseCharacterCard {
        public IzayoiSakuya() : base(8, "Izayoi Sakuya", Seasons.Winter) { }
        public override ICardTiming CardTiming => CardTimings.Reaction;

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.AdditionalDanmaku, this, 2, Durations.Active),
        };
    }
}