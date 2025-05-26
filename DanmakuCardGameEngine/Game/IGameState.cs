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
    public interface IGameState : IReadOnlyConverter<IReadOnlyGameState> {
        IPlayer PlayerInTurn { get; set; }
        IList<IPlayer> Players { get; set; }
        DecksManager DeckManager { get; set; }
        IState State { get; set; }

        int CurrentRoundNumber { get; set; }
        int CurrentTurnNumber { get; set; }
        int TurnOffSet { get; set; }
    }

    public interface IReadOnlyGameState {
        IReadOnlyPlayer PlayerInTurn { get; }
        IReadOnlyCollection<IReadOnlyPlayer> Players { get; }
        IReadOnlyDeckManager DeckManager { get; }
        IState State { get; }

        int CurrentRoundNumber { get; }
        int CurrentTurnNumber { get; }
    }

    public class ReadOnlyGameState : IReadOnlyGameState {
        public IReadOnlyPlayer PlayerInTurn { get; }
        public IReadOnlyCollection<IReadOnlyPlayer> Players { get; }
        public IReadOnlyDeckManager DeckManager { get; }
        public IState State { get; }
        public int CurrentRoundNumber { get; }
        public int CurrentTurnNumber { get; }

        protected ReadOnlyGameState() { }

        internal ReadOnlyGameState(IGameState gameState) {
            PlayerInTurn = gameState.PlayerInTurn?.ToReadOnly();
            Players = gameState.Players?.Select(p =>
                p.ToReadOnly()
            ).ToList().AsReadOnly();
            DeckManager = gameState.DeckManager;
            State = gameState.State;
            CurrentRoundNumber = gameState.CurrentRoundNumber;
            CurrentTurnNumber = gameState.CurrentTurnNumber;
        }

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

                    // Encabezado
                    sb.AppendLine("╠" + string.Join("╦", chunk.Select(p => " Player ".PadCenter(width, '═'))) + "╣");

                    // Nombre
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Name: {p.Name}".PadRight(width))) + "║");

                    // Rol
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Role: {p.RoleCard?.ToString() ?? "???"}".PadRight(width))) +
                                  "║");

                    // Character
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Character: {p.MainCharacterCard?.Name ?? "???"}".PadRight(width))) + "║");

                    // Vida
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" HP: {p.Life} / {p.MaxLife}".PadRight(width))) + "║");

                    // Range
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Range: {p.Range}".PadRight(width))) + "║");

                    // Distance Bonus
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Distance Bonus: {p.DistanceBonus}".PadRight(width))) + "║");

                    // Hand
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p => $" Hand: {p.Hand.Count}/{p.MaxHandSize} cards".PadRight(width))) + "║");

                    // Items in play
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p =>
                    {
                        int itemCount = p.ItemField.Count();
                        return $" Items: {itemCount} in play".PadRight(width);
                    })) + "║");

                    // Items
                    sb.AppendLine("║" + string.Join("║", chunk.Select(p =>
                    {
                        List<string> items = p.ItemField.Select(i => i.Name).ToList();
                        string itemsStr = items.Any() ? string.Join(", ", items) : "None";
                        return $" [{itemsStr}]".PadRight(width);
                    })) + "║");

                    sb.AppendLine("╠" + string.Join("╩", Enumerable.Repeat(new string('═', width), count)) + "╣");
                }

                sb.AppendLine("╠".PadRight(fullWidth, '═') + "╣");
                sb.AppendLine($"║ Active Incident: {"None"}".PadRight(fullWidth) + "║");
                int discard = DeckManager?.GetReadOnlyDeck<IMainCard>()?.Discard?.Count ?? 0;
                sb.AppendLine($"║ Discard Pile: {discard} cards".PadRight(fullWidth) + "║");
                sb.AppendLine("╚".PadRight(fullWidth, '═') + "╝");

                return sb.ToString();
            }

        }
    }

    public class GameState : IGameState {
        public IPlayer PlayerInTurn { get; set; }
        public IList<IPlayer> Players { get; set; }
        public DecksManager DeckManager { get; set; }

        public IState State
        {
            get => _state;
            set
            {
                _core.EventManager.OnGameState.Invoke(
                    new GameStateEventArgs(
                        _state,
                        value
                    ),
                    () => _state = value);
            }
        }

        public int CurrentRoundNumber
        {
            get => _currentRoundNumber;
            set
            {
                _core.EventManager.OnRoundChange.Invoke(
                    new RoundChangeEventArgs(
                        _currentRoundNumber,
                        value
                    ),
                    () => _currentRoundNumber = value);
            }
        }

        public int CurrentTurnNumber
        {
            get => _currentTurnNumber;
            set {
                _core.EventManager.OnTurnChange.Invoke(
                    new TurnChangeEventArgs(
                        _currentTurnNumber,
                        value
                    ),
                    () => _currentTurnNumber = value);
            }
        }

        public int TurnOffSet { get; set; }
        private readonly GameCore _core;
        private IState _state = States.None;
        private int _currentRoundNumber;
        private int _currentTurnNumber;
        public GameState(GameCore core) {
            _core = core;
        }

        public IReadOnlyGameState ToReadOnly() => new ReadOnlyGameState(this);
    }
}