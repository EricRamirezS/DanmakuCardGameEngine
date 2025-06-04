namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for an alternate timing specifically for Reaction-like effects.
    /// This is typically used by "Split cards" where one of the alternate usages behaves like a reaction.
    /// </summary>
    public interface IReactionAltTiming : IAltTiming { }
}