using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Card Name:</b> Mini-Hakkero<br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point Value:</b> 5<br/>
    /// <para><b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Item"/>, <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Artifact"/></para>
    /// <b>Text:</b><br/>
    /// You have +3 range.<br/><br/>
    /// You may discard two cards to activate your Spell Card.<br/><br/>
    /// You can only activate one Spell Card per round. You can only have one Artifact card in play at a time.
    /// </summary>
    /// <para><b>Card FAQ and errata</b></para>
    /// <list type="bullet">
    /// <item>You can activate the effect of Mini-Hakkero whenever you could normally use your Spell Card.</item>
    /// </list>
    [Serializable]
    public class MiniHakkero : SingleModeBaseMainCard, IItemMainTiming, IItemCard {
        public MiniHakkero(int id, ISeason season) : base(id,
            "Mini-Hakkero",
            season,
            5,
            new ItemMiniHakkero()) { }

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.Range, this, 3, Durations.Active),
        };
    }
}