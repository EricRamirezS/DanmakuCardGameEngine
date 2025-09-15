using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck.RevealedRole {
    /// <summary>
    /// Represents the "EX Boss Revealed" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> EX Boss Revealed</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> —</para>
    /// <para><b>Goal:</b> Defeat all Stage Bosses, then defeat the Heroine.</para>
    /// <para><b>Final Form:</b> You have +1 max life and +1 max hand size. Draw an extra card during your draw step.</para>
    /// </remarks>
    public class ExBossUnlocked : BaseRoleCard { public ExBossUnlocked() : base(6, "Ex Boss Unlocked", Seasons.Winter) { }
        public override IRoleType RoleType => RoleTypes.ExtraBoss;
    }
}