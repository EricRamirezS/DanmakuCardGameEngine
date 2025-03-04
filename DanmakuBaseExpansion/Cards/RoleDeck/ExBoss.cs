using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class ExBoss : BaseRoleCard {
        public ExBoss() : base(5, "Ex Boss", Seasons.Winter) { }
        public override IRoleType RoleType => RoleTypes.ExtraBoss;
        public override int? RequiredPlayers => 4;
        public override IRoleCard RevealedForm => new ExBossUnlocked();
    }
}