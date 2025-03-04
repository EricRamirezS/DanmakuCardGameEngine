using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class IzayoiSakuya : BaseCharacterCard {
        public IzayoiSakuya() : base(8, "Izayoi Sakuya", Seasons.Winter) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}