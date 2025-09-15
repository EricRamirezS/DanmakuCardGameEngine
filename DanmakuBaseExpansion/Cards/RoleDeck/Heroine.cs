using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    
    /// <summary>
    /// Represents the "Heroine" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Heroine</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 4+</para>
    /// <para><b>Text:</b> Start with this role revealed.</para>
    /// <para><b>Goal:</b> Defeat all Stage Bosses and Extra Bosses.</para>
    /// <para><b>Ability - Plot Armor:</b> You have +1 max life and +1 max hand size.</para>
    /// </remarks>
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