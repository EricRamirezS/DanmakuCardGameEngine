namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for an alternate timing specifically for Action-like effects.
    /// This is typically used by "Split cards" where one of the alternate usages behaves like an action.
    /// </summary>
    public interface IActionAltTiming : IAltTiming { }
}