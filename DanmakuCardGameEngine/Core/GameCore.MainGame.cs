using System;
using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Events;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Player;

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
            foreach (IState phase in GamePhases) {
                _gameState.State = phase;
                if (_gameState.State == States.StartOfTurn) {
                    await InvokePhase(
                        EventManager.OnStartOfTurn,
                        new StartOfTurnEventArgs(),
                        HandleStartOfTurn);
                }
                else if (_gameState.State == States.Incident) {
                    await InvokePhase(
                        EventManager.OnIncidentStep,
                        new IncidentStepEventArgs(),
                        HandleIncident);
                }
                else if (_gameState.State == States.Draw) {
                    await InvokePhase(
                        EventManager.OnDrawStep,
                        new DrawStepEventArgs(),
                        HandleDraw);
                }
                else if (_gameState.State == States.Main) {
                    await InvokePhase(
                        EventManager.OnMainStep,
                        new MainStepEventArgs(),
                        HandleMain);
                }
                else if (_gameState.State == States.Discard) {
                    await InvokePhase(
                        EventManager.OnDiscardStep,
                        new DiscardStepEventArgs(),
                        HandleDiscard);
                }
                if (_gameState.State == States.EndOfTurn) {
                    break;
                }
            }
        }
        private void HandleStartOfTurn() {
            IPlayer player = _gameState.PlayerInTurn;
            player.DanmakuEffectiveCount = 0;
            player.DanmakuCount = 0;
            player.IsSpellCardUsed = false;

        }
        private void HandleIncident() {
            // throw new NotImplementedException();
        }
        private void HandleDraw() {
            // throw new NotImplementedException();
        }
        private void HandleMain() {
            // throw new NotImplementedException();
        }
        private void HandleDiscard() {
            // throw new NotImplementedException();
        }

        private static async Task InvokePhase<TArgs>(BubblingEvent<TArgs> phaseEvent, TArgs args, Action mainAction)
            where TArgs : BaseEventArgs {
            await phaseEvent.Invoke(args, mainAction);
        }

        private bool GameHasEnded() {
            return !_players.Any(e => e.RoleCard.RoleType == RoleTypes.Heroine && !e.IsDefeated);
        }
    }
}