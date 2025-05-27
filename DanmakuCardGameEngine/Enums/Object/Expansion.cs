namespace DanmakuCardGameEngine.Enums.Object {
    /// <summary>
    /// Represents a game expansion, inheriting from <see cref="NamedObject"/> and implementing <see cref="IExpansion"/>.
    /// Expansions are used to group specific sets of cards, rules, or game elements.
    /// </summary>
    public class Expansion : NamedObject, IExpansion {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expansion"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the expansion.</param>
        public Expansion(string name) : base(name) { }
    }
}