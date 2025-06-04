namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for a main timing specifically for Action-like effects.
    /// This is typically used by "Action cards" or "Split cards" where one of the main usages behaves like an action.
    /// </summary>
    public interface IActionMainTiming : IMainTiming { }
}