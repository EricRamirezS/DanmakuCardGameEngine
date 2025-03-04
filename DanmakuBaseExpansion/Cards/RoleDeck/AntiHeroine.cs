using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class AntiHeroine : BaseRoleCard {
        public AntiHeroine(int id) : base(id, "Anti Heroine", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;

        public override int? RequiredPlayers => 6;
    }
}