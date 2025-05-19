using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Game {
    public interface IGameState : IReadOnlyGameState {
        new IPlayer PlayerInTurn { get; set; }
        new IList<IPlayer> Players { get; set; }
        new DecksManager DeckManager { get; set; }
        new IState State { get; set; }

        new int CurrentRoundNumber { get; set; }
        new int CurrentTurnNumber { get; set; }
        int TurnOffSet { get; set; }

        IReadOnlyGameState AsReadOnly();
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
            PlayerInTurn = gameState.PlayerInTurn;
            Players = gameState.Players?.Select(p =>
                p.ToReadOnlyPlayer()
            ).ToList().AsReadOnly();
            DeckManager = gameState.DeckManager;
            State = gameState.State;
            CurrentRoundNumber = gameState.CurrentRoundNumber;
            CurrentTurnNumber = gameState.CurrentTurnNumber;
        }
    }

    public class GameState : ReadOnlyGameState, IGameState {
        public new IPlayer PlayerInTurn { get; set; }
        public new IList<IPlayer> Players { get; set; }
        public new DecksManager DeckManager { get; set; }

        public new IState State
        {
            get => _state;
            set
            {
                _core.EventManager.OnGameState.Invoke(
                    new GameStateEventArgs(),
                    () => _state = value);
            }
        }

        public new int CurrentRoundNumber { get; set; }
        public new int CurrentTurnNumber { get; set; }
        public int TurnOffSet { get; set; }
        private GameCore _core;
        private IState _state = States.None;
        public GameState(GameCore core) {
            _core = core;
        }

        public IReadOnlyGameState AsReadOnly() => new ReadOnlyGameState(this);
    }
}