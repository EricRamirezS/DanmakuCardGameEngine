using System;
using DanmakuBaseExpansion.Cards.CharacterDeck;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Card Name:</b> Last Word<br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point Value:</b> 3<br/>
    /// <para><b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/> , <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/></para>
    /// <b>Text:</b><br/>
    /// Attack all other players, regardless of range.<br/><br/>
    /// By default you can only play one <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/> card per round.
    /// </summary>
    /// <para><b>Card FAQ and errata</b></para>
    /// <list type="bullet">
    /// <item> <see cref="KonpakuYoumu">Konpaku Youmu</see> does not get a free attack from her Ability when she plays Last Word. </item>
    /// <item> If <see cref="ReisenUdongeinInaba">Reisen Udongein Inaba</see> plays Last Word and one or more players avoid an attack, Reisen may attack one player in range. This can be a player who was attacked by Last Word, whether they avoided the attack or not, as long as it is not the only player who had avoided an attack. </item>
    /// <item> If <see cref="ReisenUdongeinInaba">Reisen Udongein Inaba</see> uses Lunatic Red Eyes to cancel and copy Last Word, she must attack all other players, regardless of range. </item>
    /// <item> <see cref="ShameimaruAya">Shameimaru Aya</see> can use her Ability to cancel Last Word just like any other <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/> card. </item>
    /// </list>
    [Serializable]
    public class LastWord : SingleModeBaseMainCard, IActionMainTiming {
        public LastWord(int id, ISeason season) : base(id,
            "Last Word",
            season,
            3,
            new ActionLastWord()) { }
    }
}