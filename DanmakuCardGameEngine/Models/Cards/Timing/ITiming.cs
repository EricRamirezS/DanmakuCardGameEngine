namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for the timing at which a card can be played or an effect can occur.
    /// Different card types have specific timing windows for their activation.
    /// </summary>
    /// <remarks>
    /// This interface is used to categorize and enforce when various card types can be utilized:
    /// <list type="bullet">
    /// <item><term>Action Cards</term><description>Typically played during the current player's main turn.</description></item>
    /// <item><term>Reaction Cards</term><description>Played in response to other effects or actions, requiring a specific condition to be met.</description></item>
    /// <item><term>Item Cards</term><description>Generally played during the current player's main turn.</description></item>
    /// <item><term>Invocation Cards</term><description>Used to activate a player's Character Card's Spell Card. Their specific timing depends on the timing requirements of the associated Character Card's Spell Card.</description></item>
    /// </list>
    /// </remarks>
    public interface ITiming { }
}