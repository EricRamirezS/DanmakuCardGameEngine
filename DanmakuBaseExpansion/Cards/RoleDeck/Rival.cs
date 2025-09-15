using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    
    /// <summary>
    /// Represents the "Rival" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Rival</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 8</para>
    /// <para><b>Goal:</b> Defeat the Heroine, then defeat all Stage Bosses and Extra Bosses.</para>
    /// <para><b>Special:</b> The game does not end the first time the Heroine is defeated. 
    /// When the Heroine is defeated, reveal this role, take the Heroine role card, and gain 1 life.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>When playing with 8 players, any player whose goal is to defeat the Heroine must defeat both the Heroine and the Rival. This can happen in any order.</item>
    /// <item>The Heroine, Stage Bosses, and Extra Bosses can be defeated in any order, as long as the Heroine is defeated before the last Stage Boss or Extra Boss is defeated. 
    /// Otherwise, the Heroine will declare victory and end the game.</item>
    /// </list>
    /// </remarks>
    public class Rival : BaseRoleCard { public Rival(int id) : base(id, "Rival", Seasons.Summer) { }
        public override IRoleType RoleType => RoleTypes.Heroine;
        public override int? RequiredPlayers => 8;
    }
}