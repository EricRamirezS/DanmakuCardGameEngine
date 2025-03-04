using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class Heroine : BaseRoleCard { 
        public Heroine(int id) : base(id, "Heroine", Seasons.Summer) { }
        public override IRoleType RoleType => RoleTypes.Heroine;
        public override int? RequiredPlayers => 4;

    }
}