using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDiscardStepEventBefore"/> and <see cref="IDiscardStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DiscardStepEvent"/>.
    /// </summary>
    public interface IDiscardStepEvent : IDiscardStepEventBefore, IDiscardStepEventAfter { }
}