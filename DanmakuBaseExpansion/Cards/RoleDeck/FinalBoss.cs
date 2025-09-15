using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    /// <summary>
    /// Represents the "Final Boss" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Final Boss</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 5+</para>
    /// <para><b>Goal:</b> Defeat the Heroine after at least one Partner has been defeated.</para>
    /// </remarks>
        public class FinalBoss : BaseRoleCard {
        public FinalBoss(int id) : base(id, "Final Boss", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;
        public override int? RequiredPlayers => 5;

    }
}