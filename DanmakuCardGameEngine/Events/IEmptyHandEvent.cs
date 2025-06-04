using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IEmptyHandEventBefore"/> and <see cref="IEmptyHandEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="EmptyHandEvent"/>.
    /// </summary>
    public interface IEmptyHandEvent : IEmptyHandEventBefore, IEmptyHandEventAfter { }
}