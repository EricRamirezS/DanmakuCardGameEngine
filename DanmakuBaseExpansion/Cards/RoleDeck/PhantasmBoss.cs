using DanmakuBaseExpansion.Cards.RoleDeck.BaseImplementation;
using DanmakuBaseExpansion.Cards.RoleDeck.RevealedRole;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    /// <summary>
    /// Represents the "Phantasm Boss" role card from the "Role" deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Phantasm Boss</para>
    /// <para><b>Deck:</b> Role</para>
    /// <para><b>Players:</b> 4+</para>
    /// <para><b>Goal:</b> Defeat all Stage Bosses, then defeat the Heroine.</para>
    /// <para><b>Sinister Plan:</b> At any time, if at least one other player has been defeated, you may reveal this role. 
    /// If you do, replace it with the True Phantasm Boss role card and gain 1 life.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>If at least one other player has already been defeated, the Phantasm Boss can use Sinister Plan at any time, including to save themselves after losing their last life.</item>
    /// <item>If an effect prevents the Phantasm Boss from gaining life, such as the <see cref="VoyageToMakai"/> incident, they will not gain life. 
    /// In this case, even if they reveal their role when they lose their last life, they will still be defeated.</item>
    /// </list>
    /// </remarks>
    public class PhantasmBoss : BaseRoleCard { public PhantasmBoss() : base(7, "Phantasm Boss", Seasons.Winter) { }
        public override IRoleType RoleType => RoleTypes.ExtraBoss;
        public override int? RequiredPlayers => 4;
        public override IRoleCard RevealedForm => new TruePhantasmBoss();
    }
}