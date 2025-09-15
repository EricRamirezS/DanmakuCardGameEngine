using System.Collections.Generic;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Provides an abstract base implementation for a "Main Card" in the Danmaku Card Game Engine.
    /// This class extends <see cref="HandCard"/> and implements <see cref="IMainCard"/>,
    /// serving as a foundation for cards that have both a primary (Main) and potentially
    /// an alternate (Alt) mode of play, along with associated card subtypes.
    /// </summary>
    public abstract class MainCard : HandCard, IMainCard {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainCard"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the card.</param>
        /// <param name="name">The display name of the card.</param>
        /// <param name="season">The season associated with the card.</param>
        /// <param name="expansion">The expansion set to which the card belongs.</param>
        /// <param name="pointValue">The point value of the hand card.</param>
        protected MainCard(int id, string name, ISeason season, IExpansion expansion, int pointValue) : base(
            CardTypes.MainCard, id, name, season, expansion, pointValue) { }

        /// <inheritdoc />
        public abstract void PlayMainMode();
        /// <inheritdoc />
        public abstract void PlayAltMode();

        /// <inheritdoc />
        public abstract IReadOnlyList<ICardSubtype> MainCardTypes { get; }

        /// <inheritdoc />
        public abstract IReadOnlyList<ICardSubtype> AltCardTypes { get; }
    }

    /// <summary>
    /// Provides an abstract base implementation for a "Main Card" that operates only in a single mode.
    /// This class extends <see cref="MainCard"/> and enforces <see cref="CardMode.Single"/>,
    /// preventing alternate play modes.
    /// </summary>
    public abstract class SingleModeMainCard : MainCard {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleModeMainCard"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the card.</param>
        /// <param name="name">The display name of the card.</param>
        /// <param name="season">The season associated with the card.</param>
        /// <param name="expansion">The expansion set to which the card belongs.</param>
        /// <param name="pointValue">The point value of the hand card.</param>
        protected SingleModeMainCard(int id, string name, ISeason season, IExpansion expansion, int pointValue) : base(id, name, season, expansion,
            pointValue) { }

        /// <inheritdoc />
        /// <summary>
        /// Gets the card mode, which is always <see cref="CardMode.Single"/> for this type of card.
        /// </summary>
        public override sealed CardMode CardMode => CardMode.Single;

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the card can be played in Alternate Mode.
        /// This method always returns <c>false</c> as single-mode cards do not have an alternate play mode.
        /// </summary>
        public override sealed bool CanPlayAltMode() => false;

        /// <inheritdoc />
        /// <summary>
        /// Gets a read-only empty list of card subtypes for the Alternate Mode.
        /// This is because single-mode cards do not have an alternate play mode.
        /// </summary>
        public override sealed IReadOnlyList<ICardSubtype> AltCardTypes => new List<ICardSubtype>();

        /// <inheritdoc />
        /// <summary>
        /// Initiates the action of playing the card in its Alternate Mode.
        /// This method has no implementation as single-mode cards do not have an alternate play mode.
        /// </summary>
        public override sealed void PlayAltMode() { }
    }

    /// <summary>
    /// Provides an abstract base implementation for a "Main Card" that supports both primary and alternate play modes.
    /// This class extends <see cref="MainCard"/> and enforces <see cref="CardMode.Double"/>.
    /// </summary>
    public abstract class DoubleModeMainCard : MainCard {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleModeMainCard"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the card.</param>
        /// <param name="name">The display name of the card.</param>
        /// <param name="season">The season associated with the card.</param>
        /// <param name="expansion">The expansion set to which the card belongs.</param>
        /// <param name="pointValue">The point value of the hand card.</param>
        protected DoubleModeMainCard(int id, string name, ISeason season, IExpansion expansion, int pointValue) : base(id, name, season, expansion,
            pointValue) { }

        /// <inheritdoc />
        /// <summary>
        /// Gets the card mode, which is always <see cref="CardMode.Double"/> for this type of card.
        /// </summary>
        public override sealed CardMode CardMode => CardMode.Double;
    }
}