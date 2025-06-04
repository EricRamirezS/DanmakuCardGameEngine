using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="INewIncidentEventBefore"/> and <see cref="INewIncidentEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="NewIncidentEvent"/>.
    /// </summary>
    public interface INewIncidentEvent : INewIncidentEventBefore, INewIncidentEventAfter { }
}