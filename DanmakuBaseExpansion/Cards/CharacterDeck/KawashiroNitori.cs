using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KawashiroNitori : BaseCharacterCard {
        public KawashiroNitori() : base(10, "Kawashiro Nitori", Seasons.Autumn) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}