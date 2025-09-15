using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    /// <summary>
    /// Represents the "Challenger" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Challenger</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 5+</para>
    /// <para><b>Goal:</b> Defeat the Heroine after the Extra Boss has been defeated.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>If one of the Partner roles is the EX Midboss, both the original Extra Boss and the EX Midboss must be defeated in order for the Challenger to declare victory.</item>
    /// </list>
    /// </remarks>
    public class Challenger : BaseRoleCard {
        public Challenger(int id) : base(id, "Challenger", Seasons.Autumn) { }

        public override IRoleType RoleType => RoleTypes.StageBoss;
        public override int? RequiredPlayers => 6;

    }
}