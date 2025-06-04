using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IMainStepEventBefore"/> and <see cref="IMainStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="MainStepEvent"/>.
    /// </summary>
    public interface IMainStepEvent : IMainStepEventBefore, IMainStepEventAfter { }
}