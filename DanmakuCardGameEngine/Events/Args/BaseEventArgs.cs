using System;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Game;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable once MemberCanBeMadeStatic.Global

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DanmakuCardGameEngine.Events.Args {
    public abstract class BaseEventArgs : EventArgs {
        public IReadOnlyGameState GameState => GameCore.Instance.GameState;
    }

    public sealed class AbilityActivatedEventArgs : BaseEventArgs { }

    public sealed class AttackEventArgs : BaseEventArgs { }

    public sealed class CancelEventArgs : BaseEventArgs { }

    public sealed class CardEntersDiscardPileEventArgs : BaseEventArgs { }

    public sealed class CardPlayedEventArgs : BaseEventArgs { }

    public sealed class CardResolvedEventArgs : BaseEventArgs { }

    public sealed class CardsCollectedEventArgs : BaseEventArgs { }

    public sealed class DanmakuPlayedEventArgs : BaseEventArgs { }

    public sealed class DeckShuffledEventArgs : BaseEventArgs { }

    public sealed class DecreasedHealthEventArgs : BaseEventArgs { }

    public sealed class DefeatEventArgs : BaseEventArgs { }

    public sealed class DiscardEventArgs : BaseEventArgs { }

    public sealed class DiscardStepEventArgs : BaseEventArgs { }

    public sealed class DodgeEventArgs : BaseEventArgs { }

    public sealed class DrawEventArgs : BaseEventArgs { }

    public sealed class DrawStepEventArgs : BaseEventArgs { }

    public sealed class EmptyHandEventArgs : BaseEventArgs { }

    public sealed class EncounterStepEventArgs : BaseEventArgs { }

    public sealed class EndOfTurnEventArgs : BaseEventArgs { }

    public sealed class FlipEventArgs : BaseEventArgs { }

    public sealed class GameStateEventArgs : BaseEventArgs {
        public GameStateEventArgs(IState previousState, IState newState) {
            PreviousState = previousState;
            NewState = newState;
        }
        public IState PreviousState { get; }
        public IState NewState { get; }
    }

    public sealed class HandRevealedEventArgs : BaseEventArgs { }

    public sealed class HandSwappedEventArgs : BaseEventArgs { }

    public sealed class IncidentResolvedEventArgs : BaseEventArgs { }

    public sealed class IncidentStepEventArgs : BaseEventArgs { }

    public sealed class IncreasedHealthEventArgs : BaseEventArgs { }

    public sealed class ItemDiscardedEventArgs : BaseEventArgs { }

    public sealed class ItemPlayedEventArgs : BaseEventArgs { }

    public sealed class MainStepEventArgs : BaseEventArgs { }

    public sealed class MobAttackStepEventArgs : BaseEventArgs { }

    public sealed class NewIncidentEventArgs : BaseEventArgs { }

    public sealed class RoleRevealedEventArgs : BaseEventArgs { }

    public sealed class RoleSwappedEventArgs : BaseEventArgs { }

    public sealed class RoundChangeEventArgs : BaseEventArgs {
        public RoundChangeEventArgs(int previousRound, int newRound) {
            PreviousRound = previousRound;
            NewRound = newRound;
        }
        public int PreviousRound { get; }
        public int NewRound { get; }
    }

    public sealed class SpellCardActivatedEventArgs : BaseEventArgs { }

    public sealed class SpellCardCancelledEventArgs : BaseEventArgs { }

    public sealed class StackResolvedEventArgs : BaseEventArgs { }

    public sealed class StandbyEventArgs : BaseEventArgs { }

    public sealed class StartOfTurnEventArgs : BaseEventArgs { }

    public sealed class TurnChangeEventArgs : BaseEventArgs {
        public TurnChangeEventArgs(int previousTurn, int newTurn) {
            PreviousTurn = previousTurn;
            NewTurn = newTurn;
        }
        public int PreviousTurn { get; }
        public int NewTurn { get; }
    }

    public sealed class TurnSkippedEventArgs : BaseEventArgs { }

    public sealed class TurnZeroEventArgs : BaseEventArgs { }

}