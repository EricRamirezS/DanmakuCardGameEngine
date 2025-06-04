using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Provides an abstract base implementation for a Role Card in the Danmaku Card Game Engine.
    /// This class handles common properties for role cards and serves as a foundation
    /// for concrete role card implementations.
    /// </summary>
    public abstract class RoleCard : Card, IRoleCard {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleCard"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the role card.</param>
        /// <param name="name">The display name of the role card.</param>
        /// <param name="season">The season associated with the role card.</param>
        /// <param name="expansion">The expansion set to which the role card belongs.</param>
        protected RoleCard(int id, string name, ISeason season, IExpansion expansion) : base(CardTypes.RoleCard, id,
            name, season, expansion) { }

        /// <inheritdoc />
        public abstract IRoleType RoleType { get; }
        /// <inheritdoc />
        /// <summary>
        /// Gets an optional alternate role type for this card.
        /// By default, returns null, indicating no alternate role type.
        /// Concrete implementations for "Split Role" cards will override this.
        /// </summary>
        public virtual IRoleType AltRoleType => null;
        /// <inheritdoc />
        /// <summary>
        /// Gets the number of players required for this role card to be included in the game setup.
        /// By default, returns null, indicating no specific player requirement.
        /// Concrete implementations will override this if a requirement exists.
        /// </summary>
        public virtual int? RequiredPlayers => null;
        /// <inheritdoc />
        /// <summary>
        /// Gets the revealed form of this role card.
        /// By default, returns null, indicating no separate revealed form.
        /// Concrete implementations for roles with a revealed state will override this.
        /// </summary>
        public virtual IRoleCard RevealedForm => null;
    }
}