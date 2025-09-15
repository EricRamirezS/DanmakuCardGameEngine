using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Focus</b><br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point value:</b> 3<br/>
    /// <b>Card Types:</b> Item, <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Defense"/>
    /// </summary>
    /// <remarks>
    /// You have +2 <see cref="DanmakuCardGameEngine.Enums.ModifierNames.Distance"/>.<br/>
    /// You can only activate one Defense card in play at a time.
    /// </remarks>
    public class Focus : SingleModeBaseMainCard, IItemMainTiming, IItemCard {
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