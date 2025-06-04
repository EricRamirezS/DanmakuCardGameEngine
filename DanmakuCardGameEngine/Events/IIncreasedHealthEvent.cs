using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IIncreasedHealthEventBefore"/> and <see cref="IIncreasedHealthEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="IncreasedHealthEvent"/>.
    /// </summary>
    public interface IIncreasedHealthEvent : IIncreasedHealthEventBefore, IIncreasedHealthEventAfter { }
}