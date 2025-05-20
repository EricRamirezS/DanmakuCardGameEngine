using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class Focus : SingleModeMainCard, IItemMainMode, IItemCard {
        public Focus(int id, ISeason season) : base(
            id,
            "Focus",
            season,
            3,
            new ItemFocus()) { }

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.Distance, this, 2, Durations.Active),
        };
    }
}