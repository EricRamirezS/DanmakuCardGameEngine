using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDrawEventBefore"/> and <see cref="IDrawEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DrawEvent"/>.
    /// </summary>
    public interface IDrawEvent : IDrawEventBefore, IDrawEventAfter { }
}