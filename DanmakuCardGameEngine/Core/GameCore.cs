using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Core {
    /// <summary>
    /// Represents the central core of the Danmaku Card Game Engine, managing the game state,
    /// players, decks, and orchestrating game progression through various phases and events.
    /// This class follows a Singleton pattern to ensure a single instance of the game core.
    /// </summary>
    public partial class GameCore {
        // Singleton instance of the GameCore.
        private static GameCore _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="IGameCore"/>.
        /// Throws a <see cref="GameNotSetException"/> if the game has not been initialized via <see cref="NewInstance"/>.
        /// </summary>
        /// <exception cref="GameNotSetException">Thrown if the game core instance has not been set up.</exception>
        public static IGameCore Instance
        {
            get
            {
                if (_instance == null) {
                    throw new GameNotSetException();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Creates a new singleton instance of the <see cref="IGameCore"/> and initializes it.
        /// This method should be called once at the start of the application to set up the game.
        /// </summary>
        /// <param name="players">A list of <see cref="IPlayer"/> objects participating in the game.</param>
        /// <param name="expansions">An array of <see cref="IExpansionData"/> objects representing the game expansions to be used.</param>
        /// <param name="defaultData">Optional default data for player statistics. If null, a new <see cref="DefaultData"/> instance is used.</param>
        /// <returns>The newly created and initialized <see cref="IGameCore"/> instance.</returns>
        public static IGameCore NewInstance(IList<IPlayer> players, IExpansionData[] expansions,
            IDefaultData defaultData = null) {

            _instance = new GameCore(players, expansions, defaultData ?? new DefaultData());
            return _instance;
        }
    }

    /// <summary>
    /// Defines the core interface for the Danmaku Card Game Engine, providing access to
    /// the game's state, players, and fundamental game operations.
    /// </summary>
    public interface IGameCore {
        /// <summary>
        /// Gets the read-only current state of the game.
        /// </summary>
        IReadOnlyGameState GameState { get; }
        /// <summary>
        /// Gets a list of all players participating in the game.
        /// </summary>
        IList<IEquatablePlayer> Players { get; }
        /// <summary>
        /// Gets the player whose turn it currently is.
        /// </summary>
        IEquatablePlayer PlayerInTurn { get; }
        /// <summary>
        /// Gets or sets the current phase of the game (e.g., Draw Step, Main Step).
        /// </summary>
        IState CurrentPhase { get; set; }
        /// <summary>
        /// Gets the central event manager for the game, allowing components to subscribe to and trigger events.
        /// </summary>
        IEventManager EventManager { get; }

        /// <summary>
        /// Asynchronously initializes the game, setting up players, decks, and initial game state.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous initialization operation.</returns>
        Task Init();
        /// <summary>
        /// Asynchronously starts the game, beginning the main game loop and turn progression.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous game start operation.</returns>
        Task StartGame();
        /// <summary>
        /// Asynchronously draws a specified quantity of cards of a particular type for a given player.
        /// </summary>
        /// <typeparam name="TCard">The type of <see cref="IHandCard"/> to draw.</typeparam>
        /// <param name="player">The player who will draw the cards.</param>
        /// <param name="quantity">The number of cards to draw.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous drawing operation.</returns>
        Task DrawCards<TCard>(IPlayer player, int quantity) where TCard : IHandCard;
    }
}