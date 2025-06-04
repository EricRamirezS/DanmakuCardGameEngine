using System;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Provides an abstract base implementation for a hand card in the Danmaku Card Game Engine.
    /// This class extends <see cref="Card"/> and implements <see cref="IHandCard"/>,
    /// adding properties for point value and card mode, as well as methods to determine playability.
    /// </summary>
    public abstract class HandCard : Card, IHandCard {
        /// <summary>
        /// Initializes a new instance of the <see cref="HandCard"/> class.
        /// </summary>
        /// <param name="cardType">The type of the card.</param>
        /// <param name="id">The unique identifier for the card.</param>
        /// <param name="name">The display name of the card.</param>
        /// <param name="season">The season associated with the card.</param>
        /// <param name="expansion">The expansion set to which the card belongs.</param>
        /// <param name="pointValue">The point value of the hand card.</param>
        protected HandCard(ICardType cardType, int id, string name, ISeason season, IExpansion expansion,
            int pointValue) : base(
            cardType, id, name, season, expansion) {
            PointValue = pointValue;
        }

        /// <inheritdoc />
        public int PointValue { get; }
        /// <inheritdoc />
        public abstract CardMode CardMode { get; }

        /// <inheritdoc />
        /// <remarks>
        /// This implementation determines if the card can be played based on its <see cref="CardMode"/>:
        /// <list type="bullet">
        /// <item><term><see cref="CardMode.Single"/></term><description>Can be played if <see cref="CanPlayMainMode"/> is true.</description></item>
        /// <item><term><see cref="CardMode.Double"/></term><description>Can be played if either <see cref="CanPlayMainMode"/> or <see cref="CanPlayAltMode"/> is true.</description></item>
        /// </list>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if an unhandled <see cref="CardMode"/> is encountered.
        /// </remarks>
        public bool CanBePlayed() {
            switch (CardMode) {
                case CardMode.Single:
                    return CanPlayMainMode();
                case CardMode.Double:
                    bool a = CanPlayMainMode();
                    bool b = CanPlayAltMode();
                    return a || b;
                default:
                    throw new ArgumentOutOfRangeException(nameof(CardMode), CardMode, "Unhandled CardMode encountered.");
            }
        }

        /// <inheritdoc />
        public abstract bool CanPlayMainMode();

        /// <inheritdoc />
        public abstract bool CanPlayAltMode();
    }
}