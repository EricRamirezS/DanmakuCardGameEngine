using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck.RevealedRole {
    /// <summary>
    /// Represents the "True Phantom Boss" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> True Phantom Boss</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> —</para>
    /// <para><b>Goal:</b> Defeat all Stage Bosses, then defeat the Heroine.</para>
    /// <para><b>Mastermind:</b> You have +1 max life. At the start of your turn, you may resolve the current incident. 
    /// If you do, look at the top three cards from the Incident deck and put them on the top or bottom in any order. 
    /// Then skip your Incident step.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>Incidents that have already been played go into the Incident discard pile. The True Phantom Boss cannot choose one of those incidents to place on the Incident deck.</item>
    /// <item>The True Phantom Boss may choose to skip their Incident step whether they resolved the current incident or not.</item>
    /// <item>If there is no active incident at the start of the True Phantom Boss’s turn, they may not search the Incident deck for a new incident.</item>
    /// <item>If the True Phantom Boss skips their Incident step when there is no active incident, or after resolving the current incident, 
    /// they will not play the current incident. That incident will come into play on the next player’s Incident step.</item>
    /// </list>
    /// </remarks>
    public class TruePhantasmBoss : BaseRoleCard {
        public TruePhantasmBoss() : base(8, "True Phantasm Boss", Seasons.Winter) { }
        public override IRoleType RoleType => RoleTypes.ExtraBoss;
    }
}