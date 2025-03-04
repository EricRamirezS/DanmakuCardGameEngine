using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KazamiYuuka : BaseCharacterCard {
        public KazamiYuuka() : base(11, "Kazami Yuuka", Seasons.Spring) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}