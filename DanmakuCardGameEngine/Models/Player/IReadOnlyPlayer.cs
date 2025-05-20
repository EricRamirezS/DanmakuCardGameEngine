using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Models.Player {

    public interface IReadOnlyPlayer : IEquatablePlayer {
        int Life { get; }
        int MaxLife { get; }
        bool IsDefeated { get; }
        int MaxHandSize { get; }
        bool IsSpellCardUsed { get; }
        int DanmakuEffectiveCount { get; }
        int DanmakuCount { get; }
        int DanmakuLimit { get; }
        int Range { get; }
        int DistanceBonus { get; }
        bool IsRoleRevealed { get; }
        ICharacterCard MainCharacterCard { get; }
        IReadOnlyHand Hand { get; }
        IRoleCard RoleCard { get; }
        IItemField ItemField { get; }
        IModifiers Modifiers { get; }
    }

}