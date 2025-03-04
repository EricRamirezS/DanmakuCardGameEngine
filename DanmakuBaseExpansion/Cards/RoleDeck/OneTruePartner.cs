using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class OneTruePartner : BaseRoleCard { public OneTruePartner(int id) : base(id, "One True Partner", Seasons.Spring) { }
        public override IRoleType RoleType => RoleTypes.Partner;
        public override int? RequiredPlayers => 7;
    }
}