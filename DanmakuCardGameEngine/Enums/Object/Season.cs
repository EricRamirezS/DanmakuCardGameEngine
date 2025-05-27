namespace DanmakuCardGameEngine.Enums.Object { 
    /// <summary>
    /// Represents a specific game season, inheriting from <see cref="NamedObject"/> and implementing <see cref="ISeason"/>.
    /// Instances of this class will define the named seasons (e.g., "Summer", "Winter") used within the game.
    /// </summary>
    public class Season : NamedObject, ISeason {
        /// <summary>
        /// Initializes a new instance of the <see cref="Season"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the season (e.g., "Summer", "Winter", "Spring", "Autumn").</param>
        public Season(string name) : base(name) { }
    }
}