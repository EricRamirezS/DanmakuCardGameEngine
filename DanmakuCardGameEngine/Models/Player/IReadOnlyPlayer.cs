using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Models.Player {

    public interface IReadOnlyPlayer : IEquatablePlayer {
        byte Life { get; }
        byte MaxLife { get; }
        bool IsDefeated { get; }
        byte MaxHandSize { get; }
        bool IsSpellCardUsed { get; }
        byte DanmakuEffectiveCount { get; }
        byte DanmakuCount { get; }
        byte DanmakuLimit { get; }
        byte Range { get; }
        byte DistanceBonus { get; }
        bool IsRoleRevealed { get; }
        ICharacterCard MainCharacterCard { get; }
        IReadOnlyHand Hand { get; }
        IRoleCard RoleCard { get; }
        IItemField ItemField { get; }
        IModifiers Modifiers { get; }
    }

}