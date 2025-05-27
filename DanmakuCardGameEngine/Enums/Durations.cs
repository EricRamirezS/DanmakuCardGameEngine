using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    /// <summary>
    /// Provides static readonly instances of the game's predefined durations.
    /// These instances should be used to reference specific duration types throughout the game logic,
    /// ensuring consistency and type safety for effects that last for a certain period.
    /// </summary>
    public static class Durations {
        /// <summary>
        /// Represents a duration that lasts until the end of the current player's turn.
        /// This aligns with the "Start of Turn" and "End of Turn" concepts in the rulebook.
        /// </summary>
        public static readonly IDuration Turn = new Object.Duration("Turn");

        /// <summary>
        /// Represents a duration that lasts until the end of the current round (after all players have taken their turns).
        /// This aligns with the "Round" concept, where certain limits reset per round.
        /// </summary>
        public static readonly IDuration Round = new Object.Duration("Round");

        /// <summary>
        /// Represents a duration that lasts as long as a specific condition or object is "active" or in play.
        /// This could apply to effects that persist while a card is in play, or a character's ability is active.
        /// </summary>
        public static readonly IDuration Active = new Object.Duration("Active");
    }
}