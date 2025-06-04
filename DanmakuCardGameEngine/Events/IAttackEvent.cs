using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IAttackEventBefore"/> and <see cref="IAttackEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="AttackEvent"/>.
    /// </summary>
    public interface IAttackEvent : IAttackEventBefore, IAttackEventAfter { }
}