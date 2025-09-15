using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    
    /// <summary>
    /// Represents the "One True Partner" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> One True Partner</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 7+</para>
    /// <para><b>Goal:</b> Defeat all other Partners, Stage Bosses, and the Extra Boss. Protect the Heroine.</para>
    /// <para><b>Shared Fate:</b> When you are defeated, the Heroine must discard all Item cards in play, 
    /// then choose up to two cards in her hand and discard the rest.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>In an 8-player game, the One True Partner can still win if the Heroine is defeated, as long as the Rival is still alive to become the new Heroine.</item>
    /// <item>As soon as the One True Partner is defeated and reveals her role card, the Heroine must discard immediately. She may not play any cards in response.</item>
    /// </list>
    /// </remarks>
    public class OneTruePartner : BaseRoleCard { public OneTruePartner(int id) : base(id, "One True Partner", Seasons.Spring) { }
        public override IRoleType RoleType => RoleTypes.Partner;
        public override int? RequiredPlayers => 7;
    }
}