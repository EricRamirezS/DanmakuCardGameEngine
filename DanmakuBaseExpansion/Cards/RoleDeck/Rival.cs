using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class Rival : BaseRoleCard { public Rival(int id) : base(id, "Rival", Seasons.Summer) { }
        public override IRoleType RoleType => RoleTypes.Heroine;
        public override int? RequiredPlayers => 8;
    }
}