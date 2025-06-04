namespace DanmakuCardGameEngine.Core {
    /// <summary>
    /// Provides a sealed concrete implementation of <see cref="IDefaultData"/>,
    /// holding the default statistical values for various game properties.
    /// This class is immutable and ensures consistent base values for game entities.
    /// </summary>
    public sealed class DefaultData : IDefaultData {
        /// <inheritdoc />
        public byte DanmakuLimit => 1;

        /// <inheritdoc />
        public byte MaxLife => 4;

        /// <inheritdoc />
        public byte MaxHandSize => 4;

        /// <inheritdoc />
        public byte Range => 1;

        /// <inheritdoc />
        public byte Distance => 1;

        /// <inheritdoc />
        public byte CardDraw => 2;

        internal DefaultData() { }
    }

    /// <summary>
    /// Defines an interface for providing default statistical data for various game properties.
    /// This interface ensures that core game values are consistently accessible.
    /// </summary>
    public interface IDefaultData {
        /// <summary>
        /// Gets the default maximum limit for danmaku Cards a player can play.
        /// </summary>
        byte DanmakuLimit { get; }
        /// <summary>
        /// Gets the default maximum life points for a player.
        /// </summary>
        byte MaxLife { get; }
        /// <summary>
        /// Gets the default maximum number of cards a player can hold in their hand.
        /// </summary>
        byte MaxHandSize { get; }
        /// <summary>
        /// Gets the default attack range for a player.
        /// </summary>
        byte Range { get; }
        /// <summary>
        /// Gets the default distance value for game mechanics.
        /// </summary>
        byte Distance { get; }
        /// <summary>
        /// Gets the default number of cards a player draws.
        /// </summary>
        byte CardDraw { get; }
    }
}