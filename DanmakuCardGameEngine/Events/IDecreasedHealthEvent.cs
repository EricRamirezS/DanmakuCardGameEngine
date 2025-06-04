using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDecreasedHealthEventBefore"/> and <see cref="IDecreasedHealthEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DecreasedHealthEvent"/>.
    /// </summary>
    public interface IDecreasedHealthEvent : IDecreasedHealthEventBefore, IDecreasedHealthEventAfter { }
}