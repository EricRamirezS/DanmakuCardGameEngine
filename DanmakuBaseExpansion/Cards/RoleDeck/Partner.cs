using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class Partner : BaseRoleCard { public Partner(int id) : base(id, "Partner", Seasons.Spring) { }
        public override IRoleType RoleType => RoleTypes.Partner;
        public override int? RequiredPlayers => 5;

    }
}