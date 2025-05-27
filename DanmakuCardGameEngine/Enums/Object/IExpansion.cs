namespace DanmakuCardGameEngine.Enums.Object {
    /// <summary>
    /// Represents an interface for a game expansion.
    /// Expansions typically define a set of new cards, rules, or game elements that can be added to the base game.
    /// This interface extends <see cref="INamedObject"/> to ensure that each expansion has a unique name.
    /// </summary>
    public interface IExpansion : INamedObject { }
}