using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IAbilityActivatedEventBefore"/> and <see cref="IAbilityActivatedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="AbilityActivatedEvent"/>.
    /// </summary>
    public interface IAbilityActivatedEvent : IAbilityActivatedEventBefore, IAbilityActivatedEventAfter { }
}