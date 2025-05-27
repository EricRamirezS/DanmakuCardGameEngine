using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    /// <summary>
    /// Provides static readonly instances of the game's predefined seasons.
    /// These instances should be used to reference specific seasons throughout the game logic,
    /// ensuring consistency and type safety.
    /// </summary>
    public static class Seasons {
        /// <summary>
        /// Represents the Winter season.
        /// This season is used as a tag for conditional game logic, allowing card effects or other game rules
        /// to make decisions based on a card's associated season.
        /// </summary>
        public static readonly ISeason Winter = new Season("Winter");

        /// <summary>
        /// Represents the Summer season.
        /// This season is used as a tag for conditional game logic, allowing card effects or other game rules
        /// to make decisions based on a card's associated season.
        /// </summary>
        public static readonly ISeason Summer = new Season("Summer");

        /// <summary>
        /// Represents the Autumn season.
        /// This season is used as a tag for conditional game logic, allowing card effects or other game rules
        /// to make decisions based on a card's associated season.
        /// </summary>
        public static readonly ISeason Autumn = new Season("Autumn");

        /// <summary>
        /// Represents the Spring season.
        /// This season is used as a tag for conditional game logic, allowing card effects or other game rules
        /// to make decisions based on a card's associated season.
        /// </summary>
        public static readonly ISeason Spring = new Season("Spring");
    }
}