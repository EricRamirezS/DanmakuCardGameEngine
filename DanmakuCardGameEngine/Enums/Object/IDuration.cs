namespace DanmakuCardGameEngine.Enums.Object {
    
    /// <summary>
    /// Represents an interface for a game duration.
    /// Durations define how long certain game effects, states, or limits last within the game.
    /// This interface extends <see cref="INamedObject"/> to ensure that each duration type has a unique name.
    /// </summary>
    public interface IDuration : INamedObject { }
}