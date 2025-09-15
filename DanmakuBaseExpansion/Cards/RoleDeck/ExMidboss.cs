using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    
    /// <summary>
    /// Represents the "EX Midboss" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> EX Midboss</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 7+</para>
    /// <para><b>Goal:</b> Defeat all Stage Bosses, then defeat the Heroine.</para>
    /// <para><b>Special:</b> If the Extra Boss is defeated, reveal this card. You count as both an Extra Boss and a Partner for other players’ goals.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>If the Extra Boss dies after all Stage Bosses have been defeated, the Heroine does not win immediately. Instead, the EX Midboss reveals her role card and counts as the Extra Boss role. 
    /// The Heroine (and the other Partner if one exists) must now defeat the EX Midboss in order to win.</item>
    /// <item>The EX Midboss, whether revealed or not, counts as a Partner role for the purposes of other players’ goals, such as for the Final Boss.</item>
    /// </list>
    /// </remarks>
    public class ExMidboss : BaseRoleCard { public ExMidboss(int id) : base(id, "Ex Midboss", Seasons.Spring) { }
        public override IRoleType RoleType => RoleTypes.Partner;
        public override IRoleType AltRoleType => RoleTypes.ExtraBoss;
        public override int? RequiredPlayers => 7;

    }
}