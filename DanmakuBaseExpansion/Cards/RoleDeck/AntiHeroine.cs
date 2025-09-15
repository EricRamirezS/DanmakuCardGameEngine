using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    /// <summary>
    /// Represents the "Anti-Heroine" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Anti-Heroine</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 6+</para>
    /// <para><b>Goal:</b> Defeat the Heroine after at least one other Stage Boss has been defeated.</para>
    /// </remarks>
    public class AntiHeroine : BaseRoleCard {
        public AntiHeroine(int id) : base(id, "Anti Heroine", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;

        public override int? RequiredPlayers => 6;
    }
}