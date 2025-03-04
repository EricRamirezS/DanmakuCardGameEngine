using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class ExBossUnlocked : BaseRoleCard { public ExBossUnlocked() : base(6, "Ex Boss Unlocked", Seasons.Winter) { }
        public override IRoleType RoleType => RoleTypes.ExtraBoss;
    }
}