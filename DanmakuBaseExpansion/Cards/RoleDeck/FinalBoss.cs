using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class FinalBoss : BaseRoleCard {
        public FinalBoss(int id) : base(id, "Final Boss", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;
        public override int? RequiredPlayers => 5;

    }
}