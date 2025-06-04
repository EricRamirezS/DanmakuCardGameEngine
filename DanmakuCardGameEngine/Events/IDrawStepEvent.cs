using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDrawStepEventBefore"/> and <see cref="IDrawStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DrawStepEvent"/>.
    /// </summary>
    public interface IDrawStepEvent : IDrawStepEventBefore, IDrawStepEventAfter { }
}