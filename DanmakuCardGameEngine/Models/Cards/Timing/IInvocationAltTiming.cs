namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for an alternate timing specifically for Invocation-like effects.
    /// This is typically used by "Split cards" where one of the alternate usages involves activating a Spell Card.
    /// </summary>
    public interface IInvocationAltTiming : IAltTiming { }
}