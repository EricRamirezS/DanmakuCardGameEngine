namespace DanmakuCardGameEngine.Enums.Object {
    /// <summary>
    /// Represents a concrete implementation of a game duration, inheriting from <see cref="NamedObject"/> and implementing <see cref="IDuration"/>.
    /// This class is used to define specific duration types such as "Turn", "Round", or "Active".
    /// </summary>
    public class Duration : NamedObject, IDuration {
        /// <summary>
        /// Initializes a new instance of the <see cref="Duration"/> class with the specified name.
        /// The unique group for all durations is set to "Duration".
        /// </summary>
        /// <param name="name">The name of the duration (e.g., "Turn", "Round", "Active").</param>
        public Duration(string name) : base(name, "Duration") { }
    }
}