using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;
using DanmakuCardGameEngine.Models.Player.Components;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable once MemberCanBeMadeStatic.Global

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Abstract base class for all event arguments in the game engine.
    /// Provides access to the current game state and a property to indicate if the event is uncancellable.
    /// </summary>
    public abstract class BaseEventArgs : EventArgs {
        /// <summary>
        /// Gets the current read-only game state.
        /// </summary>
        public IReadOnlyGameState GameState => GameCore.Instance.GameState;
        /// <summary>
        /// Gets or sets a value indicating whether the event is uncancellable.
        /// If <c>true</c>, the event cannot be prevented or overridden by other actions.
        /// </summary>
        public bool Uncancellable { get; internal set; }
    }

    /// <summary>
    /// Provides data for an event that occurs when an ability is activated.
    /// </summary>
    public sealed class AbilityActivatedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who is the owner of the activated ability.
        /// </summary>
        public IReadOnlyPlayer EffectOwner { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when an attack is initiated.
    /// </summary>
    public sealed class AttackEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who initiated the attack.
        /// </summary>
        public IReadOnlyPlayer Attacker { get; }
        /// <summary>
        /// Gets a value indicating whether the attack is unavoidable.
        /// If <c>true</c>, targets cannot dodge this attack.
        /// </summary>
        public bool Unavoidable { get; }
        /// <summary>
        /// Gets a list of read-only players who are the targets of the attack.
        /// </summary>
        public IList<IReadOnlyPlayer> Targets { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when an action or card is cancelled.
    /// </summary>
    public sealed class CancelEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the card that was cancelled.
        /// </summary>
        public ICard cancelledCard { get; }
        /// <summary>
        /// Gets the card that caused the cancellation.
        /// </summary>
        public ICard cancellingCard { get; }
        /// <summary>
        /// Gets the read-only player who performed the cancelling action.
        /// </summary>
        public IReadOnlyPlayer cancelingPlayer { get; }
        /// <summary>
        /// Gets the read-only player whose card or effect was cancelled.
        /// </summary>
        public IReadOnlyPlayer canceledPlayer { get; }
        }

    /// <summary>
    /// Provides data for an event that occurs when cards enter the discard pile.
    /// </summary>
    public sealed class CardsEnterDiscardPileEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the discard pile component to which the cards were added.
        /// </summary>
        public IDiscard Discard { get; }
        /// <summary>
        /// Gets a list of hand cards that were discarded.
        /// </summary>
        public IList<IHandCard> DiscardedCards { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a card is played.
    /// </summary>
    public sealed class CardPlayedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who played the card.
        /// </summary>
        public IReadOnlyPlayer PlayedBy { get; }
        /// <summary>
        /// Gets the card that was played.
        /// </summary>
        public ICard PlayedCard { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a card has been resolved (its effects have been applied).
    /// </summary>
    public sealed class CardResolvedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the card that was resolved.
        /// </summary>
        public ICard ResolvedCard { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a card is revealed to players.
    /// </summary>
    public sealed class CardRevealedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only card that was revealed.
        /// </summary>
        public IReadOnlyCard RevealedCard { get; }
        /// <summary>
        /// Gets the read-only player who revealed the card.
        /// </summary>
        public IReadOnlyPlayer RevealingPlayer { get; }
        /// <summary>
        /// Gets or sets a list of read-only players who can view the revealed card.
        /// </summary>
        public IList<IReadOnlyPlayer> ViewingPlayers { get; set; }
    }

    /// <summary>
    /// Provides data for an event that occurs when cards are collected (typically after an incident).
    /// </summary>
    public sealed class CardsCollectedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the incident card associated with the collected cards.
        /// </summary>
        public IncidentCard IncidentCard { get; }
        /// <summary>
        /// Gets a list of hand cards that were collected.
        /// </summary>
        public IList<IHandCard> CollectedCards { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a Danmaku card is played.
    /// </summary>
    public sealed class DanmakuPlayedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the Danmaku card that was played.
        /// </summary>
        public ICard PlayedCard { get; }
        /// <summary>
        /// Gets the read-only player who played the Danmaku card.
        /// </summary>
        public IReadOnlyPlayer PlayedBy { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a deck is shuffled.
    /// </summary>
    public sealed class DeckShuffledEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the deck that was shuffled.
        /// </summary>
        public IDeck ShuffledDeck { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a player's health decreases.
    /// </summary>
    public sealed class DecreasedHealthEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the previous health value of the affected player.
        /// </summary>
        public byte PreviousHealth { get; }
        /// <summary>
        /// Gets or sets the new health value of the affected player.
        /// </summary>
        public byte NewHealth { get; set; }
        /// <summary>
        /// Gets the read-only player whose health decreased.
        /// </summary>
        public IReadOnlyPlayer AffectedPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a player is defeated.
    /// </summary>
    public sealed class DefeatEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who was defeated.
        /// </summary>
        public IReadOnlyPlayer DefeatPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when cards are discarded from a player's hand.
    /// </summary>
    public sealed class DiscardEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the player's discard component.
        /// </summary>
        public IDiscard Discard { get; }
        /// <summary>
        /// Gets the read-only player who is discarding cards.
        /// </summary>
        public IReadOnlyPlayer DiscardingPlayer { get; }
        /// <summary>
        /// Gets a list of hand cards that were discarded in this event.
        /// </summary>
        public IList<IHandCard> DiscardedCards { get; }
    }

    /// <summary>
    /// Provides data for an event that marks the beginning or progression of the discard step in a turn.
    /// </summary>
    public sealed class DiscardStepEventArgs : BaseEventArgs { }

    /// <summary>
    /// Provides data for an event that occurs when a player dodges an attack.
    /// </summary>
    public sealed class DodgeEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who dodged the attack.
        /// </summary>
        public IReadOnlyPlayer Attacker { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when cards are drawn.
    /// </summary>
    public sealed class DrawEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the number of cards that were attempted to be drawn.
        /// </summary>
        public int cardsToDraw { get; }
        /// <summary>
        /// Gets a list of read-only cards that were drawn.
        /// </summary>
        public List<IReadOnlyCard> DrawnCards { get; }
        /// <summary>
        /// Gets the read-only player who drew the cards.
        /// </summary>
        public IReadOnlyPlayer DrawingPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that marks the beginning or progression of the draw step in a turn.
    /// </summary>
    public sealed class DrawStepEventArgs : BaseEventArgs { }

    /// <summary>
    /// Provides data for an event that occurs when a player's hand is empty.
    /// </summary>
    public sealed class EmptyHandEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player whose hand is empty.
        /// </summary>
        public IReadOnlyPlayer EmptyHandedPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that marks the end of a turn.
    /// </summary>
    public sealed class EndOfTurnEventArgs : BaseEventArgs {
    }

    /// <summary>
    /// Provides data for an event that occurs when a card is flipped from a deck.
    /// </summary>
    public sealed class FlipEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only deck from which the card was flipped.
        /// </summary>
        public IReadOnlyDeck Deck { get; }
        /// <summary>
        /// Gets the card that was flipped.
        /// </summary>
        public ICard flippedCard { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when the game state changes.
    /// </summary>
    public sealed class GameStateEventArgs : BaseEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateEventArgs"/> class.
        /// </summary>
        /// <param name="previousState">The previous game state.</param>
        /// <param name="newState">The new game state.</param>
        public GameStateEventArgs(IState previousState, IState newState) {
            PreviousState = previousState;
            NewState = newState;
        }
        /// <summary>
        /// Gets the previous game state.
        /// </summary>
        public IState PreviousState { get; }
        /// <summary>
        /// Gets or sets the new game state.
        /// </summary>
        public IState NewState { get; set; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a player's hand is revealed.
    /// </summary>
    public sealed class HandRevealedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only hand that was revealed.
        /// </summary>
        public IReadOnlyHand Hand { get; }
        /// <summary>
        /// Gets the read-only player who revealed the hand.
        /// </summary>
        public IReadOnlyPlayer RevealingPlayer { get; }
        /// <summary>
        /// Gets or sets a list of read-only players who can view the revealed hand.
        /// </summary>
        public IList<IReadOnlyPlayer> ViewingPlayers { get; set; }
    }

    /// <summary>
    /// Provides data for an event that occurs when two players' hands are swapped.
    /// </summary>
    public sealed class HandSwappedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the original read-only hand of Player 1 before the swap.
        /// </summary>
        public IReadOnlyHand Player1Hand { get; }
        /// <summary>
        /// Gets the original read-only hand of Player 2 before the swap.
        /// </summary>
        public IReadOnlyHand Player2Hand { get; }
        /// <summary>
        /// Gets the read-only Player 1 involved in the swap.
        /// </summary>
        public IReadOnlyPlayer Player1 { get; }
        /// <summary>
        /// Gets the read-only Player 2 involved in the swap.
        /// </summary>
        public IReadOnlyPlayer Player2 { get; }
        /// <summary>
        /// Gets or sets the new read-only hand of Player 1 after the swap.
        /// </summary>
        public IReadOnlyHand Player1NewHand { get; set; }
        /// <summary>
        /// Gets or sets the new read-only hand of Player 2 after the swap.
        /// </summary>
        public IReadOnlyHand Player2NewHand { get; set; }
    }

    /// <summary>
    /// Provides data for an event that occurs when an incident has been resolved.
    /// </summary>
    public sealed class IncidentResolvedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only incident card that was resolved.
        /// </summary>
        public IIncidentCard ResolvedIncident { get; }
    }

    /// <summary>
    /// Provides data for an event that marks the beginning or progression of the incident step in a turn.
    /// </summary>
    public sealed class IncidentStepEventArgs : BaseEventArgs { }

    /// <summary>
    /// Provides data for an event that occurs when a player's health increases.
    /// </summary>
    public sealed class IncreasedHealthEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the previous health value of the affected player.
        /// </summary>
        public byte PreviousHealth { get; }
        /// <summary>
        /// Gets or sets the new health value of the affected player.
        /// </summary>
        public byte NewHealth { get; set; }
        /// <summary>
        /// Gets the read-only player whose health increased.
        /// </summary>
        public IReadOnlyPlayer AffectedPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when an Item card is discarded.
    /// </summary>
    public sealed class ItemDiscardedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only Item card that was discarded.
        /// </summary>
        public IItemCard DiscardedCard { get; }
        /// <summary>
        /// Gets the read-only player who discarded the Item card.
        /// </summary>
        public IReadOnlyPlayer DiscardingPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when an Item card is played.
    /// </summary>
    public sealed class ItemPlayedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only Item card that was played.
        /// </summary>
        public IItemCard PlayerItem { get; }
        /// <summary>
        /// Gets the read-only player who played the Item card.
        /// </summary>
        public IReadOnlyPlayer Player { get; }
    }

    /// <summary>
    /// Provides data for an event that marks the beginning or progression of the main step in a turn.
    /// </summary>
    public sealed class MainStepEventArgs : BaseEventArgs { }

    /// <summary>
    /// Provides data for an event that occurs when a new Incident card is revealed.
    /// </summary>
    public sealed class NewIncidentEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the new Incident card that entered play.
        /// </summary>
        public IIncidentCard IncidentCard { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a player's Role card is revealed.
    /// </summary>
    public sealed class RoleRevealedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player whose Role card was revealed.
        /// </summary>
        public IReadOnlyPlayer RevealingPlayer { get; }
        /// <summary>
        /// Gets the read-only Role card that was revealed.
        /// </summary>
        public IRoleCard Revealedole { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when two players' Role cards are swapped.
    /// </summary>
    public sealed class RoleSwappedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the original read-only Role card of Player 1 before the swap.
        /// </summary>
        public IReadOnlyCard Player1Role { get; }
        /// <summary>
        /// Gets the original read-only Role card of Player 2 before the swap.
        /// </summary>
        public IReadOnlyCard Player2Role { get; }
        /// <summary>
        /// Gets the read-only Player 1 involved in the role swap.
        /// </summary>
        public IReadOnlyPlayer Player1 { get; }
        /// <summary>
        /// Gets the read-only Player 2 involved in the role swap.
        /// </summary>
        public IReadOnlyPlayer Player2 { get; }
        /// <summary>
        /// Gets or sets the new read-only Role card of Player 1 after the swap.
        /// </summary>
        public IReadOnlyCard Player1NewRole { get; set; }
        /// <summary>
        /// Gets or sets the new read-only Role card of Player 2 after the swap.
        /// </summary>
        public IReadOnlyCard Player2NewRole { get; set; }
    }

    /// <summary>
    /// Provides data for an event that occurs when the round number changes.
    /// </summary>
    public sealed class RoundChangeEventArgs : BaseEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundChangeEventArgs"/> class.
        /// </summary>
        /// <param name="previousRound">The previous round number.</param>
        /// <param name="newRound">The new round number.</param>
        public RoundChangeEventArgs(int previousRound, int newRound) {
            PreviousRound = previousRound;
            NewRound = newRound;
        }
        /// <summary>
        /// Gets the previous round number.
        /// </summary>
        public int PreviousRound { get; }
        /// <summary>
        /// Gets the new round number.
        /// </summary>
        public int NewRound { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a Spell Card is activated.
    /// </summary>
    public sealed class SpellCardActivatedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the Character Card associated with the activated Spell Card.
        /// </summary>
        public ICharacterCard Card { get; }
        /// <summary>
        /// Gets the read-only player who activated the Spell Card.
        /// </summary>
        public IReadOnlyPlayer ActivatingPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a Spell Card is cancelled.
    /// </summary>
    public sealed class SpellCardCancelledEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the Character Card whose Spell Card was cancelled.
        /// </summary>
        public ICharacterCard Card { get; }
        /// <summary>
        /// Gets the read-only player who was activating the Spell Card.
        /// </summary>
        public IReadOnlyPlayer ActivatingPlayer { get; }
        /// <summary>
        /// Gets the read-only player who cancelled the Spell Card.
        /// </summary>
        public IReadOnlyPlayer CancellingPlayer { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when the game's effect stack has been resolved.
    /// </summary>
    public sealed class StackResolvedEventArgs : BaseEventArgs { }
    
    /// <summary>
    /// Provides data for an event that marks the start of a turn.
    /// </summary>
    public sealed class StartOfTurnEventArgs : BaseEventArgs { }

    /// <summary>
    /// Provides data for an event that occurs when the turn number changes.
    /// </summary>
    public sealed class TurnChangeEventArgs : BaseEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="TurnChangeEventArgs"/> class.
        /// </summary>
        /// <param name="previousTurn">The previous turn number.</param>
        /// <param name="newTurn">The new turn number.</param>
        public TurnChangeEventArgs(int previousTurn, int newTurn) {
            PreviousTurn = previousTurn;
            NewTurn = newTurn;
        }
        /// <summary>
        /// Gets the previous turn number.
        /// </summary>
        public int PreviousTurn { get; }
        /// <summary>
        /// Gets the new turn number.
        /// </summary>
        public int NewTurn { get; }
    }

    /// <summary>
    /// Provides data for an event that occurs when a player's turn is skipped.
    /// </summary>
    public sealed class TurnSkippedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player whose turn was skipped.
        /// </summary>
        public IReadOnlyPlayer SkippingPlayer;
    }

    /// <summary>
    /// Provides data for an event that marks the start of the special "turn zero" of the game.
    /// "Turn zero" occurs before the Heroine's first turn and allows for initial actions.
    /// </summary>
    public sealed class TurnZeroEventArgs : BaseEventArgs { }

}
