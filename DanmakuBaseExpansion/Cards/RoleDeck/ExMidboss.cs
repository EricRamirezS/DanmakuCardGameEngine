using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class ExMidboss : BaseRoleCard { public ExMidboss(int id) : base(id, "Ex Midboss", Seasons.Spring) { }
        public override IRoleType RoleType => RoleTypes.Partner;
        public override IRoleType AltRoleType => RoleTypes.ExtraBoss;
        public override int? RequiredPlayers => 7;

    }
}