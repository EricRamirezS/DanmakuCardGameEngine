using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class StageBoss : BaseRoleCard {
        public StageBoss(int id) : base(id, "Stage Boss", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;
        public override int? RequiredPlayers => 4;
    }
}