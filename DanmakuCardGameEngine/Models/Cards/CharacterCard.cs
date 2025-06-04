using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Provides an abstract base implementation for a Character Card in the Danmaku Card Game Engine.
    /// This class handles common properties and behaviors for character cards, including
    /// their association with a player and the management of their ability and spell card availability.
    /// </summary>
    public abstract class CharacterCard : Card, ICharacterCard {

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterCard"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the character card.</param>
        /// <param name="name">The display name of the character card.</param>
        /// <param name="season">The season associated with the character card.</param>
        /// <param name="expansion">The expansion set to which the character card belongs.</param>
        protected CharacterCard(int id, string name, ISeason season, IExpansion expansion) : base(
            CardTypes.CharacterCard, id, name, season, expansion) { }

        /// <inheritdoc />
        public abstract ISpellCardTiming SpellCardTiming { get; }

        /// <summary>
        /// Gets the player who currently controls this character card.
        /// This property is protected to allow access within derived classes while
        /// preventing direct external modification.
        /// </summary>
        protected IPlayer Owner { get; private set; }

        /// <inheritdoc />
        public virtual bool AbilityAvailable { get; private set; }

        /// <inheritdoc />
        public virtual bool SpellCardAvailable { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Assigns this character card to a player, making it active.
        /// Both the character's ability and spell card are set to be available by default.
        /// The character also subscribes to relevant game events.
        /// </summary>
        public virtual void ChooseCharacter(IPlayer owner) {
            Owner = owner;
            AbilityAvailable = true;
            SpellCardAvailable = true;
            Subscribe(GameCore.Instance.EventManager);
        }

        /// <inheritdoc />
        /// <summary>
        /// Assigns this character card to a player with specified availability for its ability and spell card.
        /// This overload allows for more granular control over the character's initial state when chosen.
        /// The character also subscribes to relevant game events.
        /// </summary>
        public virtual void ChooseCharacter(IPlayer owner, bool abilityAvailable, bool spellCardAvailable) {
            Owner = owner;
            AbilityAvailable = abilityAvailable;
            SpellCardAvailable = spellCardAvailable;
            Subscribe(GameCore.Instance.EventManager);
        }
        /// <inheritdoc />
        /// <summary>
        /// Dismisses this character card, removing it from a player's control.
        /// This method clears the owner, sets both ability and spell card availability to false,
        /// and unsubscribes the character from game events.
        /// </summary>
        public virtual void Dismiss() {
            Owner = null;
            AbilityAvailable = false;
            SpellCardAvailable = false;
            Unsubscribe(GameCore.Instance.EventManager);
        }

    }
}