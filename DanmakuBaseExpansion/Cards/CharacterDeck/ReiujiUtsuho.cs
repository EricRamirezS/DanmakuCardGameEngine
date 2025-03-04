using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class ReiujiUtsuho : BaseCharacterCard {
        public ReiujiUtsuho() : base(19, "Reiuji Utsuho", Seasons.Summer) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}