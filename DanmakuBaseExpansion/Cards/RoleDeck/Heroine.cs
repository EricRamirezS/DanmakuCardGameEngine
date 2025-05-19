using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public class Heroine : BaseRoleCard {
        public Heroine(int id) : base(id, "Heroine", Seasons.Summer) { }
        public override IRoleType RoleType => RoleTypes.Heroine;
        public override int? RequiredPlayers => 4;

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.MaxLife, this, 1, Durations.Active),
            new ModifierData(ModifierNames.MaxHand, this, 1, Durations.Active),
        };
    }
}