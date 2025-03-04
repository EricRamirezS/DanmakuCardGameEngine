namespace DanmakuCardGameEngine.Models.Player {
    public interface IReadOnlyPlayer {
        string Name { get; }
        int Life { get; }
        int MaxLife { get; }
        bool IsSpellCardUsed { get; }
        bool IsDefeated { get; }
        int DanmakuEffectiveCount { get; }
        int DanmakuCount { get; }
        int DanmakuLimit { get; }
        ICharacterCard CharacterCard { get; }
        bool IsRoleRevealed { get; }
        IRoleCard? RoleCard { get; }
        IRoleType? PlayerRoleType { get; }
        IItemField ItemField { get; }
        int Range { get; }
        int Distance { get; }
    }
}