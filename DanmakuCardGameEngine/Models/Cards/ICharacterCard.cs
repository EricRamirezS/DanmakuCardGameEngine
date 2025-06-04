using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Defines an interface for a Character Card in the Danmaku Card Game Engine.
    /// Character cards represent the main Touhou character controlled by players,
    /// possessing unique abilities and a Spell Card.
    /// </summary>
    public interface ICharacterCard : ICard {
        /// <summary>
        /// Gets the timing rules associated with this Character Card's Spell Card.
        /// </summary>
        ISpellCardTiming SpellCardTiming { get; }

        /// <summary>
        /// Gets a value indicating whether the character's unique ability is currently available for use.
        /// </summary>
        bool AbilityAvailable { get; }

        /// <summary>
        /// Gets a value indicating whether the character's Spell Card is currently available for use.
        /// </summary>
        bool SpellCardAvailable { get; }

        /// <summary>
        /// Assigns this character card to a player, making it active.
        /// This method typically sets the owner, makes abilities and spell cards available,
        /// and subscribes the character to relevant game events.
        /// </summary>
        /// <param name="owner">The player who will control this character card.</param>
        void ChooseCharacter(IPlayer owner);
        /// <summary>
        /// Assigns this character card to a player with specified availability for its ability and spell card.
        /// This overload allows for more granular control over the character's initial state when chosen.
        /// </summary>
        /// <param name="owner">The player who will control this character card.</param>
        /// <param name="abilityAvailable">A boolean indicating if the character's ability should be available.</param>
        /// <param name="spellCardAvailable">A boolean indicating if the character's spell card should be available.</param>
        void ChooseCharacter(IPlayer owner, bool abilityAvailable, bool spellCardAvailable);
        /// <summary>
        /// Dismisses this character card, removing it from a player's control.
        /// This typically clears the owner, makes abilities and spell cards unavailable,
        /// and unsubscribes the character from game events.
        /// </summary>
        void Dismiss();
    }


}