using System;
using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Events;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Core {
    public partial class GameCore {
        public async Task StartGame() {
            if (!_initialized) {
                throw new Exception("Game not initialized. Call Init() first.");
            }

            _gameState.CurrentRoundNumber = 1;
            _gameState.CurrentTurnNumber = 1;
            while (!GameHasEnded()) {
                for (int i = 0; i < _players.Count; i++) {
                    IPlayer current = _players[(i + _gameState.TurnOffSet) % _players.Count];
                    _gameState.PlayerInTurn = current;
                    if (current.IsDefeated) {
                        continue;
                    }
                    await ExecuteTurn();
                    _gameState.CurrentTurnNumber++;
                }
                _gameState.CurrentRoundNumber++;
            }

            await ResolveGameEnd();
        }

        private async Task ResolveGameEnd() {
            throw new NotImplementedException();
        }

        private async Task ExecuteTurn() {
            _gameState.State = States.StartOfTurn;
            while (true) {
                switch (CurrentPhase) {
                    case var s when s == States.StartOfTurn:
                        await InvokePhase(
                            EventManager.OnStartOfTurn,
                            new StartOfTurnEventArgs(),
                            HandleStartOfTurnStep);
                        break;
                    case var s when s == States.Incident:
                        await InvokePhase(
                            EventManager.OnIncidentStep,
                            new IncidentStepEventArgs(),
                            HandleIncidentStep);
                        break;
                    case var s when s == States.Draw:
                        await InvokePhase(
                            EventManager.OnDrawStep,
                            new DrawStepEventArgs(),
                            HandleDrawStep);
                        break;
                    case var s when s == States.Main:
                        await InvokePhase(
                            EventManager.OnMainStep,
                            new MainStepEventArgs(),
                            HandleMainStep);
                        break;
                    case var s when s == States.Discard:
                        await InvokePhase(
                            EventManager.OnDiscardStep,
                            new DiscardStepEventArgs(),
                            HandleDiscardStep);
                        break;
                    case var s when s == States.EndOfTurn:
                        break;
                    case var s when s == States.SkipTurn:
                        break;
                }
                if (_gameState.State == States.EndOfTurn || _gameState.State == States.SkipTurn) {
                    break;
                }
            }
        }
        private async void HandleStartOfTurnStep(StartOfTurnEventArgs startOfTurnEventArgs) {
            IPlayer player = _gameState.PlayerInTurn;
            player.DanmakuEffectiveCount = 0;
            player.DanmakuCount = 0;
            player.IsSpellCardUsed = false;
        }
        private async void HandleIncidentStep(IncidentStepEventArgs incidentStepEventArgs) {
            // throw new NotImplementedException();
        }
        private async void HandleDrawStep(DrawStepEventArgs drawStepEventArgs) {
            // throw new NotImplementedException();
        }
        private async void HandleMainStep(MainStepEventArgs mainStepEventArgs) {
            // throw new NotImplementedException();
        }
        
        private async void HandleDiscardStep(DiscardStepEventArgs discardStepEventArgs) {
            try {
                do {
                    for (int i = 0; i < _players.Count; i++) {
                        IPlayer current = _players[(i + _gameState.TurnOffSet) % _players.Count];
                        if (current.IsDefeated) continue;
                    
                        while (current.Hand.Count > current.MaxHandSize) {
                            IHand cards = current.Hand;
                            IHandCard toDiscard = await current.ChooseAsync(cards.ToList().AsReadOnly(), GameState);
                            await DiscardCard(current, toDiscard);
                        }
                    }
                } while (_players.Any(p => p.Hand.Count > p.MaxHandSize));
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        private static async Task<bool> InvokePhase<TArgs>(BubblingEvent<TArgs> phaseEvent, TArgs args, Action<TArgs> mainAction)
            where TArgs : BaseEventArgs {
            return await phaseEvent.Invoke(args, mainAction);
        }

        private bool GameHasEnded() {
            return !_players.Any(e => e.RoleCard.RoleType == RoleTypes.Heroine && !e.IsDefeated);
        }
    }
}