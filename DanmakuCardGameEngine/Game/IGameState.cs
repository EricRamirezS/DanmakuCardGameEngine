using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Game {
    /// <summary>
    /// Defines the mutable interface for the overall state of the game.
    /// This interface provides read/write access to critical game components and progression data,
    /// allowing the game engine to manage turns, rounds, players, and decks.
    /// It also supports conversion to a read-only state.
    /// </summary>
    public interface IGameState : IReadOnlyConverter<IReadOnlyGameState> {
        /// <summary>
        /// Gets or sets the player whose turn it currently is.
        /// </summary>
        IPlayer PlayerInTurn { get; set; }

        /// <summary>
        /// Gets or sets the list of all players currently in the game.
        /// </summary>
        IList<IPlayer> Players { get; set; }

        /// <summary>
        /// Gets or sets the manager responsible for all decks in the game.
        /// </summary>
        DecksManager DeckManager { get; set; }

        /// <summary>
        /// Gets or sets the current state of the game (e.g., Setup, Playing, End).
        /// Setting this property can trigger game state change events.
        /// </summary>
        IState State { get; set; }

        /// <summary>
        /// Gets or sets the current round number of the game.
        /// Setting this property can trigger round change events.
        /// </summary>
        int CurrentRoundNumber { get; set; }

        /// <summary>
        /// Gets or sets the current turn number within the current round.
        /// Setting this property can trigger turn change events.
        /// </summary>
        int CurrentTurnNumber { get; set; }

        /// <summary>
        /// Gets or sets an offset for the turn number, potentially used for specific game mechanics
        /// or to adjust turn order dynamically.
        /// </summary>
        int TurnOffSet { get; set; }
    }

    /// <summary>
    /// Defines a read-only interface for the overall state of the game.
    /// This interface provides immutable access to critical game components and progression data,
    /// suitable for displaying game information or for game logic that only needs to read the state.
    /// </summary>
    public interface IReadOnlyGameState {
        /// <summary>
        /// Gets the read-only representation of the player whose turn it currently is.
        /// </summary>
        IReadOnlyPlayer PlayerInTurn { get; }

        /// <summary>
        /// Gets a read-only collection of all players currently in the game.
        /// </summary>
        IReadOnlyCollection<IReadOnlyPlayer> Players { get; }

        /// <summary>
        /// Gets the read-only manager responsible for all decks in the game.
        /// </summary>
        IReadOnlyDeckManager DeckManager { get; }

        /// <summary>
        /// Gets the current state of the game (e.g., Setup, Playing, End).
        /// </summary>
        IState State { get; }

        /// <summary>
        /// Gets the current round number of the game.
        /// </summary>
        int CurrentRoundNumber { get; }

        /// <summary>
        /// Gets the current turn number within the current round.
        /// </summary>
        int CurrentTurnNumber { get; }
    }

    /// <summary>
    /// Provides a concrete read-only implementation of the game state, encapsulating
    /// a snapshot of the game's current components and progression data.
    /// This class is designed to offer an immutable view of the game state at a given moment.
    /// </summary>
    public class ReadOnlyGameState : IReadOnlyGameState {
        /// <inheritdoc />
        public IReadOnlyPlayer PlayerInTurn { get; }

        /// <inheritdoc />
        public IReadOnlyCollection<IReadOnlyPlayer> Players { get; }

        /// <inheritdoc />
        public IReadOnlyDeckManager DeckManager { get; }

        /// <inheritdoc />
        public IState State { get; }

        /// <inheritdoc />
        public int CurrentRoundNumber { get; }

        /// <inheritdoc />
        public int CurrentTurnNumber { get; }

        /// <summary>
        /// Protected constructor to prevent direct instantiation without an <see cref="IGameState"/> source.
        /// </summary>
        protected ReadOnlyGameState() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyGameState"/> class
        /// by copying the current state from a mutable <see cref="IGameState"/> instance.
        /// All properties are set to reflect the game's state at the time of creation.
        /// </summary>
        /// <param name="gameState">The mutable <see cref="IGameState"/> instance from which to create the read-only view.</param>
        internal ReadOnlyGameState(IGameState gameState) {
            PlayerInTurn = gameState.PlayerInTurn?.ToReadOnly(); // Convert to read-only player
            Players = gameState.Players?.Select(p =>
                p.ToReadOnly()
            ).ToList().AsReadOnly(); // Convert all players to read-only
            DeckManager = gameState.DeckManager; // DeckManager is already IReadOnlyDeckManager
            State = gameState.State;
            CurrentRoundNumber = gameState.CurrentRoundNumber;
            CurrentTurnNumber = gameState.CurrentTurnNumber;
        }

        /// <inheritdoc />
        /// <summary>
        /// Generates a formatted string representation of the current game state,
        /// including details about players, turn, round, and deck status.
        /// The layout adjusts based on the number of players for better readability.
        /// </summary>
        /// <returns>A string representing the current game state.</returns>
        public override string ToString() {
            {
                StringBuilder sb = new StringBuilder();
                int totalPlayers = Players?.Count ?? -1;
                int columnsPerRow;
                if (totalPlayers <= 4)
                    columnsPerRow = 2;
                else if (totalPlayers <= 6)
                    columnsPerRow = 3;
                else
                    columnsPerRow = 4;

                int rows = (int)Math.Ceiling(totalPlayers / (double)columnsPerRow);
                const int width = 33;
                int fullWidth = (width + 1) * columnsPerRow;
                sb.AppendLine("╔" + $" Game State: {State} ".PadCenter(fullWidth - 1, '═') + "╗");
                sb.AppendLine($"║ Players: {totalPlayers}".PadRight(fullWidth) + "║");
                sb.AppendLine($"║ Player in Turn: {PlayerInTurn?.Name ?? "???"}".PadRight(fullWidth) + "║");
                sb.AppendLine($"║ Round: {CurrentRoundNumber}".PadRight(fullWidth) + "║");
                sb.AppendLine($"║ Turn: {CurrentTurnNumber}".PadRight(fullWidth) + "║");

                for (int row = 0; row < rows; row++) {
                    int start = row * columnsPerRow;
                    int count = Math.Min(columnsPerRow, totalPlayers - start);
                    List<IReadOnlyPlayer> chunk = Players.Skip(start).Take(count).ToList();

                    // Header for player columns
                    sb.AppendLine("╠" + string.Join("╦", chunk.Select(p => " Player ".PadCenter(width, '═'))) + "╣");

                    // Player Name
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Name: {p.Name}".PadRight(width))) + "║");

                    // Player Role
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Role: {p.RoleCard?.ToString() ?? "???"}".PadRight(width))) +
                                  "║");

                    // Player Character
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Character: {p.MainCharacterCard?.Name ?? "???"}".PadRight(width))) + "║");

                    // Player Life
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" HP: {p.Life} / {p.MaxLife}".PadRight(width))) + "║");

                    // Player Range
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Range: {p.Range}".PadRight(width))) + "║");

                    // Player Distance Bonus
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Distance Bonus: {p.DistanceBonus}".PadRight(width))) + "║");

                    // Player Hand Size
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Hand: {p.Hand.Count}/{p.MaxHandSize} cards".PadRight(width))) + "║");

                    // Number of Items in play
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p =>
                    {
                        int itemCount = p.ItemField.Count();
                        return $" Items: {itemCount} in play".PadRight(width);
                    })) + "║");

                    // List of Items
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p =>
                    {
                        List<string> items = p.ItemField.Select(i => i.Name).ToList();
                        string itemsStr = items.Any() ? string.Join(", ", items) : "None";
                        return $" [{itemsStr}]".PadRight(width);
                    })) + "║");

                    sb.AppendLine("╠" + string.Join("╩", Enumerable.Repeat(new string('═', width), count)) + "╣");
                }

                sb.AppendLine("╠".PadRight(fullWidth, '═') + "╣");
                sb.AppendLine($"║ Active Incident: {"None"}".PadRight(fullWidth) + "║"); // Placeholder for active incident
                int discard = DeckManager?.GetReadOnlyDeck<IMainCard>()?.Discard?.Count ?? 0;
                sb.AppendLine($"║ Discard Pile: {discard} cards".PadRight(fullWidth) + "║");
                sb.AppendLine("╚".PadRight(fullWidth, '═') + "╝");

                return sb.ToString();
            }

        }
    }

    /// <summary>
    /// Represents the mutable state of the game, holding all dynamic information
    /// about the current game session, including players, decks, and progression.
    /// This class interacts with the <see cref="GameCore"/> to trigger events
    /// upon changes to key state properties.
    /// </summary>
    public class GameState : IGameState {
        /// <inheritdoc />
        public IPlayer PlayerInTurn { get; set; }

        /// <inheritdoc />
        public IList<IPlayer> Players { get; set; }

        /// <inheritdoc />
        public DecksManager DeckManager { get; set; }

        private IState _state = States.None;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the current state of the game.
        /// Setting this property invokes the <see cref="EventManager.OnGameState"/> event,
        /// allowing listeners to react to game state transitions.
        /// </summary>
        public IState State
        {
            get => _state;
            set
            {
                _core.EventManager.OnGameState.Invoke(
                    new GameStateEventArgs(
                        _state, // Old state
                        value // New state
                    ),
                    (args) => _state = args.NewState); // Update the internal field after event handlers
            }
        }

        private int _currentRoundNumber;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the current round number of the game.
        /// Setting this property invokes the <see cref="EventManager.OnRoundChange"/> event,
        /// allowing listeners to react to round progression.
        /// </summary>
        public int CurrentRoundNumber
        {
            get => _currentRoundNumber;
            set
            {
                _core.EventManager.OnRoundChange.Invoke(
                    new RoundChangeEventArgs(
                        _currentRoundNumber, // Old round number
                        value // New round number
                    ),
                    (args) => _currentRoundNumber = args.NewRound); // Update the internal field after event handlers
            }
        }

        private int _currentTurnNumber;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the current turn number within the current round.
        /// Setting this property invokes the <see cref="EventManager.OnTurnChange"/> event,
        /// allowing listeners to react to turn progression.
        /// </summary>
        public int CurrentTurnNumber
        {
            get => _currentTurnNumber;
            set
            {
                _core.EventManager.OnTurnChange.Invoke(
                    new TurnChangeEventArgs(
                        _currentTurnNumber, // Old turn number
                        value // New turn number
                    ),
                    args => _currentTurnNumber = args.NewTurn); // Update the internal field after event handlers
            }
        }

        /// <inheritdoc />
        public int TurnOffSet { get; set; }

        private readonly GameCore _core;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="core">The <see cref="GameCore"/> instance associated with this game state,
        /// used for accessing the event manager.</param>
        public GameState(GameCore core) {
            _core = core;
        }

        /// <inheritdoc />
        /// <summary>
        /// Converts the current mutable game state into its read-only representation.
        /// </summary>
        /// <returns>A new <see cref="ReadOnlyGameState"/> instance that provides an immutable view of this game state.</returns>
        public IReadOnlyGameState ToReadOnly() => new ReadOnlyGameState(this);
    }
}