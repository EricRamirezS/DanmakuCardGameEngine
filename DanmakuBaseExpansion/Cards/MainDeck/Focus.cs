using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class Focus : SingleModeMainCard, IItemMainMode {
        public Focus(int id, ISeason season) : base(
            id,
            "Focus",
            season,
            3,
            new ItemFocus()) { }

        public override IModifiers Modifiers => new Modifiers {
            { ModifierNames.Distance, new ModifierData(this, 2, Durations.Active) }
        };
    }
}