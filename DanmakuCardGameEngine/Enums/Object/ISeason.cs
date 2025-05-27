namespace DanmakuCardGameEngine.Enums.Object {
    /// <summary>
    /// Represents an interface for a game season.
    /// Seasons are primarily informational data associated with cards, such as "Summer," "Winter," "Spring," or "Autumn."
    /// Game effects can make decisions or trigger based on a card's associated season.
    /// This interface extends <see cref="INamedObject"/> to ensure that each season has a unique name.
    /// </summary>
    public interface ISeason : INamedObject { }
}