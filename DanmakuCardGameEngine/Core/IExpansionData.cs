using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    /// <summary>
    /// Defines an interface for data related to a game expansion.
    /// An expansion provides specific decks (Role, Main, Character, Incident) and
    /// an associated <see cref="Expansion"/> object, along with methods for initialization
    /// and deck registration.
    /// </summary>
    public interface IExpansionData : INamedObject {
        /// <summary>
        /// Gets the Role Deck associated with this expansion.
        /// </summary>
        IRoleDeck RoleDeck { get; }
        /// <summary>
        /// Gets the Main Deck associated with this expansion.
        /// </summary>
        IMainDeck MainDeck { get; }
        /// <summary>
        /// Gets the Character Deck associated with this expansion.
        /// </summary>
        ICharacterDeck CharacterDeck { get; }
        /// <summary>
        /// Gets the Incident Deck associated with this expansion.
        /// </summary>
        IIncidentDeck IncidentDeck { get; }

        /// <summary>
        /// Gets the core <see cref="Expansion"/> object that this data represents.
        /// </summary>
        Expansion Expansion { get; }

        /// <summary>
        /// Registers any additional decks provided by this expansion with the game's central deck manager.
        /// This allows the game engine to access and manage all decks from the expansion.
        /// </summary>
        /// <param name="decksManager">The central <see cref="IDecksManager"/> of the game.</param>
        void RegisterOtherDecks(IDecksManager decksManager);
        /// <summary>
        /// Initializes the expansion data, performing any necessary setup or loading operations.
        /// </summary>
        void Init();
    }
}