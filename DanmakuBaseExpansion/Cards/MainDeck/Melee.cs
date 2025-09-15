using System;
using DanmakuBaseExpansion.Cards.CharacterDeck;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Card Name:</b> Melee<br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point Value:</b> 2<br/>
    /// <para><b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/>, <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/></para>
    /// <b>Text:</b><br/>
    /// Attack a player, regardless of range.<br/><br/>
    /// This does not count against your Danmaku card limit.<br/><br/>
    /// That player may then discard a Danmaku card to copy this effect.
    /// </summary>
    /// <para><b>Card FAQ and errata</b></para>
    /// <list type="bullet">
    /// <item>If the target of Melee chooses to copy it, they may choose to attack any player, not just the player who originally played it.</item>
    /// <item>As long as players continue to discard Danmaku cards, they can copy Melee any number of times. This ends when a player either can’t or chooses not to discard a Danmaku card.</item>
    /// <item>The copies of Melee count as Danmaku cards for the purpose of effects that depend on Danmaku cards being played.</item>
    /// <item>Players can copy Melee even if it is collected by an incident.</item>
    /// <item>Copies of Melee can be canceled by cards such as <see cref="Bomb"/> or <see cref="ShameimaruAya">Shameimaru Aya</see>'s Ability.</item>
    /// <item>If Melee is canceled, the target can no longer copy it.</item>
    /// <item>Players attacked by Melee can choose to copy it, even if that attack reduced them to 0 life. When the last copy of Melee resolves, all players still at 0 life are defeated at the same time.</item>
    /// <item><see cref="KonpakuYoumu">Konpaku Youmu</see> can use her Ability to attack another player in range when she plays this card or copies its effect.</item>
    /// <item>If <see cref="ReisenUdongeinInaba">Reisen Udongein Inaba</see> cancels and copies Melee with her Spell Card Lunatic Red Eyes, the new target may discard a Danmaku card to copy it like normal.</item>
    /// </list>
    [Serializable]
    public class Melee : SingleModeBaseMainCard, IActionMainTiming {
        public Melee(int id, ISeason season) : base(id,
            "Melee",
            season,
            2,
            new ActionMelee()) { }
    }
}