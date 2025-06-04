using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IFlipEventBefore"/> and <see cref="IFlipEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="FlipEvent"/>.
    /// </summary>
    public interface IFlipEvent : IFlipEventBefore, IFlipEventAfter { }
}