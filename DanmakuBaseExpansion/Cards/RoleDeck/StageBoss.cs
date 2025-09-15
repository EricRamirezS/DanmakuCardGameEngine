using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    /// <summary>
    /// Represents the "Stage Boss" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Stage Boss</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 4+</para>
    /// <para><b>Goal:</b> Defeat the Heroine.</para>
    /// </remarks>
    public class StageBoss : BaseRoleCard {
        public StageBoss(int id) : base(id, "Stage Boss", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;
        public override int? RequiredPlayers => 4;
    }
}