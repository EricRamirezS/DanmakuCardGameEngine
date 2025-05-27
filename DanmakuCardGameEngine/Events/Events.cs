using System;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Represents a delegate for event handlers that can intercept event execution
    /// and control whether the event should "bubble" (continue its propagation) or stop.
    /// </summary>
    /// <typeparam name="TArgs">The type of event arguments, which must inherit from <see cref="BaseEventArgs"/>.</typeparam>
    /// <param name="args">The event arguments containing relevant information about the occurrence.</param>
    /// <param name="bubbleEvent">An output boolean value that indicates whether the event should continue bubbling.
    /// Setting it to <c>false</c> will stop the execution of remaining <c>Before</c> handlers
    /// and the main event action.</param>
    public delegate void BubblingEventHandler<TArgs>(ref TArgs args, out bool bubbleEvent) where TArgs : BaseEventArgs;

    /// <summary>
    /// Represents a delegate for simple event handlers that react to an occurrence
    /// without the ability to intercept or modify the "bubbling" flow of the event.
    /// </summary>
    /// <typeparam name="TArgs">The type of event arguments, which must inherit from <see cref="BaseEventArgs"/>.</typeparam>
    /// <param name="args">The event arguments containing relevant information about the occurrence.</param>
    public delegate void SimpleEventHandler<in TArgs>(TArgs args) where TArgs : BaseEventArgs;

    /// <summary>
    /// Provides a generic implementation for an event system with "Before" and "After" phases,
    /// and a "bubbling" capability that allows "Before" handlers to stop event propagation
    /// and the execution of the main action.
    /// </summary>
    /// <typeparam name="TArgs">The type of event arguments, which must inherit from <see cref="BaseEventArgs"/>.</typeparam>
    public class BubblingEvent<TArgs> where TArgs : BaseEventArgs {

        /// <summary>
        /// Delegates for event handlers that execute *before* the main event action.
        /// These handlers can set <c>bubbleEvent</c> to <c>false</c> to stop propagation.
        /// </summary>
        private event BubblingEventHandler<TArgs> BeforeHandlers;

        /// <summary>
        /// Delegates for event handlers that execute *after* the main event action.
        /// These handlers cannot stop event propagation.
        /// </summary>
        private event SimpleEventHandler<TArgs> AfterHandlers;

        /// <summary>
        /// Invokes event handlers in sequence: first the <c>Before</c> handlers,
        /// then the main action (<paramref name="execution"/>), and finally the <c>After</c> handlers.
        /// </summary>
        /// <param name="args">The event arguments to be passed to all handlers.</param>
        /// <param name="execution">A function representing the main logic of the event,
        /// which will only execute if no <c>Before</c> handler stops bubbling.</param>
        /// <param name="uncancellable">True if the event cannot be cancelled, false otherwise.</param>
        /// <returns>A <see cref="Task{TResult}"/> that completes with <c>true</c> if the event executed completely
        /// (including the main action), or <c>false</c> if a <c>Before</c> handler stopped bubbling.
        /// If an exception occurs, the Task completes with the exception.</returns>
        public Task<bool> Invoke(TArgs args, Action<TArgs> execution, bool uncancellable = false) {
            try {
                bool continueBubbling = true;
                args.Uncancellable = uncancellable;

                // Invoke Before handlers
                if (BeforeHandlers != null) {
                    foreach (Delegate handler in BeforeHandlers.GetInvocationList()) {
                        // Invoke the handler and get the 'bubble' value
                        ((BubblingEventHandler<TArgs>)handler).Invoke(ref args, out bool bubble);

                        // If 'bubble' is false, stop bubbling and execution
                        if (bubble || uncancellable) continue;
                        continueBubbling = false;
                        break; // Exit the Before handlers loop
                    }
                }

                // If bubbling was stopped by a Before handler, neither the main action nor AfterHandlers are executed
                if (!continueBubbling || uncancellable) return Task.FromResult(false);

                // Execute the main event action
                execution?.Invoke(args);

                // Invoke After handlers
                if (AfterHandlers == null) return Task.FromResult(true);

                foreach (Delegate handler in AfterHandlers.GetInvocationList()) {
                    ((SimpleEventHandler<TArgs>)handler).Invoke(args);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex) {
                // Catch any exception during invocation and propagate it through the Task
                return Task.FromException<bool>(ex);
            }
        }

        /// <summary>
        /// Allows subscription to event handlers that execute *before* the main event action.
        /// Subscribers can intercept the event and potentially stop its propagation.
        /// </summary>
        public event BubblingEventHandler<TArgs> Before
        {
            add => BeforeHandlers += value;
            remove => BeforeHandlers -= value;
        }

        /// <summary>
        /// Allows subscription to event handlers that execute *after* the main event action.
        /// These handlers are for reaction only and cannot stop the event flow.
        /// </summary>
        public event SimpleEventHandler<TArgs> After
        {
            add => AfterHandlers += value;
            remove => AfterHandlers -= value;
        }
    }

    /// <summary>
    /// Raised when an ability is activated.
    /// Allows event listeners to intercept or respond to the activation of abilities.
    /// </summary>
    public class AbilityActivatedEvent : BubblingEvent<AbilityActivatedEventArgs> { }

    /// <summary>
    /// Raised when an attack is initiated.
    /// Can be used to modify, prevent, or respond to attacks.
    /// </summary>
    public class AttackEvent : BubblingEvent<AttackEventArgs> { }

    /// <summary>
    /// Raised when an action is cancelled.
    /// Allows game components to react to or prevent the cancellation.
    /// </summary>
    public class CancelEvent : BubblingEvent<CancelEventArgs> { }

    /// <summary>
    /// Raised when a card is placed into a discard pile.
    /// Useful for effects triggered by discards.
    /// </summary>
    public class CardsEnterDiscardPileEvent : BubblingEvent<CardsEnterDiscardPileEventArgs> { }

    /// <summary>
    /// Raised when a card is played from a player's hand.
    /// Allows interception before the card is resolved.
    /// </summary>
    public class CardPlayedEvent : BubblingEvent<CardPlayedEventArgs> { }

    /// <summary>
    /// Raised after a card’s effect has fully resolved.
    /// Enables responses to resolved card effects.
    /// </summary>
    public class CardResolvedEvent : BubblingEvent<CardResolvedEventArgs> { }

    /// <summary>
    /// Raised when a group of cards is collected (e.g., drawn or taken).
    /// Allows listeners to monitor card acquisitions.
    /// </summary>
    public class CardsCollectedEvent : BubblingEvent<CardsCollectedEventArgs> { }

    /// <summary>
    /// Raised when a Danmaku card is played.
    /// Can be used to block or respond to bullet patterns.
    /// </summary>
    public class DanmakuPlayedEvent : BubblingEvent<DanmakuPlayedEventArgs> { }

    /// <summary>
    /// Raised when a player's deck is shuffled.
    /// Useful for tracking or modifying shuffle behavior.
    /// </summary>
    public class DeckShuffledEvent : BubblingEvent<DeckShuffledEventArgs> { }

    /// <summary>
    /// Raised when a player's health decreases.
    /// Allows for reactions such as damage mitigation or triggers.
    /// </summary>
    public class DecreasedHealthEvent : BubblingEvent<DecreasedHealthEventArgs> { }

    /// <summary>
    /// Raised when a player is defeated.
    /// Enables reactions before and after defeat resolution.
    /// </summary>
    public class DefeatEvent : BubblingEvent<DefeatEventArgs> { }

    /// <summary>
    /// Raised when a player discards cards.
    /// Can be used to respond to or modify discards.
    /// </summary>
    public class DiscardEvent : BubblingEvent<DiscardEventArgs> { }

    /// <summary>
    /// Raised at the discard phase of a turn.
    /// Suitable for global effects tied to discard timing.
    /// </summary>
    public class DiscardStepEvent : BubblingEvent<DiscardStepEventArgs> { }

    /// <summary>
    /// Raised when a player attempts to dodge an attack.
    /// Enables dodge prevention or bonuses.
    /// </summary>
    public class DodgeEvent : BubblingEvent<DodgeEventArgs> { }

    /// <summary>
    /// Raised when cards are drawn from a deck.
    /// Allows reactions like draw prevention or bonuses.
    /// </summary>
    public class DrawEvent : BubblingEvent<DrawEventArgs> { }

    /// <summary>
    /// Raised during the draw phase of a turn.
    /// Suitable for handling automatic or mandatory draws.
    /// </summary>
    public class DrawStepEvent : BubblingEvent<DrawStepEventArgs> { }

    /// <summary>
    /// Raised when a player ends their turn with an empty hand.
    /// Can be used for effects that reward or penalize this condition.
    /// </summary>
    public class EmptyHandEvent : BubblingEvent<EmptyHandEventArgs> { }

    /// <summary>
    /// Raised at the end of a player's turn.
    /// Triggers clean-up effects or end-of-turn conditions.
    /// </summary>
    public class EndOfTurnEvent : BubblingEvent<EndOfTurnEventArgs> { }

    /// <summary>
    /// Raised when a face-down card is flipped face-up.
    /// Useful for triggering effects on reveal.
    /// </summary>
    public class FlipEvent : BubblingEvent<FlipEventArgs> { }

    /// <summary>
    /// Raised when the overall game state changes.
    /// Useful for syncing game state transitions or saving state.
    /// </summary>
    public class GameStateEvent : BubblingEvent<GameStateEventArgs> { }

    /// <summary>
    /// Raised when a player’s hand is revealed to others.
    /// Useful for triggering inspection-based abilities.
    /// </summary>
    public class HandRevealedEvent : BubblingEvent<HandRevealedEventArgs> { }

    /// <summary>
    /// Raised when two players exchange their hands.
    /// Allows interception or modification of swaps.
    /// </summary>
    public class HandSwappedEvent : BubblingEvent<HandSwappedEventArgs> { }

    /// <summary>
    /// Raised when an incident card has been resolved.
    /// Useful for progressing the game or applying global effects.
    /// </summary>
    public class IncidentResolvedEvent : BubblingEvent<IncidentResolvedEventArgs> { }

    /// <summary>
    /// Raised during the incident step of a turn.
    /// Triggers or manages the global incident effects.
    /// </summary>
    public class IncidentStepEvent : BubblingEvent<IncidentStepEventArgs> { }

    /// <summary>
    /// Raised when a player's health increases.
    /// Can trigger healing bonuses or conditions.
    /// </summary>
    public class IncreasedHealthEvent : BubblingEvent<IncreasedHealthEventArgs> { }

    /// <summary>
    /// Raised when an item is discarded from play or hand.
    /// Triggers item-based graveyard effects or penalties.
    /// </summary>
    public class ItemDiscardedEvent : BubblingEvent<ItemDiscardedEventArgs> { }

    /// <summary>
    /// Raised when an item card is played.
    /// Allows interception or enhancements to item usage.
    /// </summary>
    public class ItemPlayedEvent : BubblingEvent<ItemPlayedEventArgs> { }

    /// <summary>
    /// Raised during the main phase of a player's turn.
    /// Enables player actions and interactions.
    /// </summary>
    public class MainStepEvent : BubblingEvent<MainStepEventArgs> { }

    /// <summary>
    /// Raised when a new incident is revealed.
    /// Useful for modifying or reacting to the revealed card.
    /// </summary>
    public class NewIncidentEvent : BubblingEvent<NewIncidentEventArgs> { }

    /// <summary>
    /// Raised when a player's role is revealed.
    /// Enables role-specific triggers and reactions.
    /// </summary>
    public class RoleRevealedEvent : BubblingEvent<RoleRevealedEventArgs> { }

    /// <summary>
    /// Raised when roles are swapped between players.
    /// Can trigger effects based on role changes.
    /// </summary>
    public class RoleSwappedEvent : BubblingEvent<RoleSwappedEventArgs> { }

    /// <summary>
    /// Raised when the round changes (after all players have taken turns).
    /// Useful for global reset or upkeep effects.
    /// </summary>
    public class RoundChangeEvent : BubblingEvent<RoundChangeEventArgs> { }

    /// <summary>
    /// Raised when a Spell Card is activated.
    /// Enables spell reactions, counters, or bonuses.
    /// </summary>
    public class SpellCardActivatedEvent : BubblingEvent<SpellCardActivatedEventArgs> { }

    /// <summary>
    /// Raised when a Spell Card is cancelled or interrupted.
    /// Enables follow-up reactions or penalty effects.
    /// </summary>
    public class SpellCardCancelledEvent : BubblingEvent<SpellCardCancelledEventArgs> { }

    /// <summary>
    /// Raised when the stack resolves and all pending actions are executed.
    /// Allows cleanup or end-of-stack reactions.
    /// </summary>
    public class StackResolvedEvent : BubblingEvent<StackResolvedEventArgs> { }

    /// <summary>
    /// Raised at the start of a player's turn.
    /// Triggers turn-start effects or initial actions.
    /// </summary>
    public class StartOfTurnEvent : BubblingEvent<StartOfTurnEventArgs> { }

    /// <summary>
    /// Raised when the turn shifts from one player to another.
    /// Can be used to track active player changes or buffs/debuffs.
    /// </summary>
    public class TurnChangeEvent : BubblingEvent<TurnChangeEventArgs> { }

    /// <summary>
    /// Raised when a player skips their turn.
    /// Enables penalty, catch-up, or special turn-skip behavior.
    /// </summary>
    public class TurnSkippedEvent : BubblingEvent<TurnSkippedEventArgs> { }

    /// <summary>
    /// Raised at the beginning of the game (Turn Zero).
    /// Used to initialize game state or apply opening effects.
    /// </summary>
    public class TurnZeroEvent : BubblingEvent<TurnZeroEventArgs> { }


    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AbilityActivatedEvent"/> *before* its main action.
    /// Implementers can influence whether the ability action executes or is stopped.
    /// </summary>
    public interface IAbilityActivatedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="AbilityActivatedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="AbilityActivatedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main ability action.</param>
        void OnAbilityActivatedBefore(AbilityActivatedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AbilityActivatedEvent"/> *after* its main action.
    /// Implementers react to the ability activation once it has occurred.
    /// </summary>
    public interface IAbilityActivatedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="AbilityActivatedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="AbilityActivatedEventArgs"/> for the event.</param>
        void OnAbilityActivatedAfter(AbilityActivatedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IAbilityActivatedEventBefore"/> and <see cref="IAbilityActivatedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="AbilityActivatedEvent"/>.
    /// </summary>
    public interface IAbilityActivatedEvent : IAbilityActivatedEventBefore, IAbilityActivatedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AttackEvent"/> *before* its main action.
    /// Implementers can influence whether the attack executes or is stopped.
    /// </summary>
    public interface IAttackEventBefore {
        /// <summary>
        /// Handler method for the <see cref="AttackEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="AttackEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main attack action.</param>
        void OnAttackBefore(AttackEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AttackEvent"/> *after* its main action.
    /// Implementers react to the attack once it has occurred.
    /// </summary>
    public interface IAttackEventAfter {
        /// <summary>
        /// Handler method for the <see cref="AttackEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="AttackEventArgs"/> for the event.</param>
        void OnAttackAfter(AttackEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IAttackEventBefore"/> and <see cref="IAttackEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="AttackEvent"/>.
    /// </summary>
    public interface IAttackEvent : IAttackEventBefore, IAttackEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CancelEvent"/> *before* its main action.
    /// Implementers can influence whether the cancellation executes or is stopped.
    /// </summary>
    public interface ICancelEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CancelEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CancelEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main cancellation action.</param>
        void OnCancelBefore(CancelEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CancelEvent"/> *after* its main action.
    /// Implementers react to the cancellation once it has occurred.
    /// </summary>
    public interface ICancelEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CancelEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CancelEventArgs"/> for the event.</param>
        void OnCancelAfter(CancelEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ICancelEventBefore"/> and <see cref="ICancelEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CancelEvent"/>.
    /// </summary>
    public interface ICancelEvent : ICancelEventBefore, ICancelEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsEnterDiscardPileEvent"/> *before* its main action.
    /// Implementers can influence whether the card enters the discard pile or is stopped.
    /// </summary>
    public interface ICardEntersDiscardPileEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardsEnterDiscardPileEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsEnterDiscardPileEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main action of the card entering the discard pile.</param>
        void OnCardEntersDiscardPileBefore(CardsEnterDiscardPileEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsEnterDiscardPileEvent"/> *after* its main action.
    /// Implementers react to the card entering the discard pile once it has occurred.
    /// </summary>
    public interface ICardEntersDiscardPileEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardsEnterDiscardPileEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsEnterDiscardPileEventArgs"/> for the event.</param>
        void OnCardEntersDiscardPileAfter(CardsEnterDiscardPileEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ICardEntersDiscardPileEventBefore"/> and <see cref="ICardEntersDiscardPileEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardsEnterDiscardPileEvent"/>.
    /// </summary>
    public interface ICardEntersDiscardPileEvent : ICardEntersDiscardPileEventBefore, ICardEntersDiscardPileEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardPlayedEvent"/> *before* its main action.
    /// Implementers can influence whether the card is played or is stopped.
    /// </summary>
    public interface ICardPlayedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardPlayedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardPlayedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card played action.</param>
        void OnCardPlayedBefore(CardPlayedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardPlayedEvent"/> *after* its main action.
    /// Implementers react to the card played once it has occurred.
    /// </summary>
    public interface ICardPlayedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardPlayedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardPlayedEventArgs"/> for the event.</param>
        void OnCardPlayedAfter(CardPlayedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ICardPlayedEventBefore"/> and <see cref="ICardPlayedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardPlayedEvent"/>.
    /// </summary>
    public interface ICardPlayedEvent : ICardPlayedEventBefore, ICardPlayedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardResolvedEvent"/> *before* its main action.
    /// Implementers can influence whether the card resolution executes or is stopped.
    /// </summary>
    public interface ICardResolvedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardResolvedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardResolvedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card resolution action.</param>
        void OnCardResolvedBefore(CardResolvedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardResolvedEvent"/> *after* its main action.
    /// Implementers react to the card resolution once it has occurred.
    /// </summary>
    public interface ICardResolvedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardResolvedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardResolvedEventArgs"/> for the event.</param>
        void OnCardResolvedAfter(CardResolvedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ICardResolvedEventBefore"/> and <see cref="ICardResolvedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardResolvedEvent"/>.
    /// </summary>
    public interface ICardResolvedEvent : ICardResolvedEventBefore, ICardResolvedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsCollectedEvent"/> *before* its main action.
    /// Implementers can influence whether the card collection executes or is stopped.
    /// </summary>
    public interface ICardsCollectedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardsCollectedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsCollectedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card collection action.</param>
        void OnCardsCollectedBefore(CardsCollectedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsCollectedEvent"/> *after* its main action.
    /// Implementers react to the card collection once it has occurred.
    /// </summary>
    public interface ICardsCollectedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardsCollectedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsCollectedEventArgs"/> for the event.</param>
        void OnCardsCollectedAfter(CardsCollectedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ICardsCollectedEventBefore"/> and <see cref="ICardsCollectedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardsCollectedEvent"/>.
    /// </summary>
    public interface ICardsCollectedEvent : ICardsCollectedEventBefore, ICardsCollectedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DanmakuPlayedEvent"/> *before* its main action.
    /// Implementers can influence whether the danmaku plays or is stopped.
    /// </summary>
    public interface IDanmakuPlayedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DanmakuPlayedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DanmakuPlayedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main danmaku played action.</param>
        void OnDanmakuPlayedBefore(DanmakuPlayedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DanmakuPlayedEvent"/> *after* its main action.
    /// Implementers react to the danmaku played once it has occurred.
    /// </summary>
    public interface IDanmakuPlayedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DanmakuPlayedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DanmakuPlayedEventArgs"/> for the event.</param>
        void OnDanmakuPlayedAfter(DanmakuPlayedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDanmakuPlayedEventBefore"/> and <see cref="IDanmakuPlayedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DanmakuPlayedEvent"/>.
    /// </summary>
    public interface IDanmakuPlayedEvent : IDanmakuPlayedEventBefore, IDanmakuPlayedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DeckShuffledEvent"/> *before* its main action.
    /// Implementers can influence whether the deck shuffles or is stopped.
    /// </summary>
    public interface IDeckShuffledEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DeckShuffledEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DeckShuffledEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main deck shuffle action.</param>
        void OnDeckShuffledBefore(DeckShuffledEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DeckShuffledEvent"/> *after* its main action.
    /// Implementers react to the deck shuffle once it has occurred.
    /// </summary>
    public interface IDeckShuffledEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DeckShuffledEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DeckShuffledEventArgs"/> for the event.</param>
        void OnDeckShuffledAfter(DeckShuffledEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDeckShuffledEventBefore"/> and <see cref="IDeckShuffledEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DeckShuffledEvent"/>.
    /// </summary>
    public interface IDeckShuffledEvent : IDeckShuffledEventBefore, IDeckShuffledEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DecreasedHealthEvent"/> *before* its main action.
    /// Implementers can influence whether the health decrease executes or is stopped.
    /// </summary>
    public interface IDecreasedHealthEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DecreasedHealthEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DecreasedHealthEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main health decrease action.</param>
        void OnDecreasedHealthBefore(DecreasedHealthEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DecreasedHealthEvent"/> *after* its main action.
    /// Implementers react to the health decrease once it has occurred.
    /// </summary>
    public interface IDecreasedHealthEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DecreasedHealthEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DecreasedHealthEventArgs"/> for the event.</param>
        void OnDecreasedHealthAfter(DecreasedHealthEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDecreasedHealthEventBefore"/> and <see cref="IDecreasedHealthEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DecreasedHealthEvent"/>.
    /// </summary>
    public interface IDecreasedHealthEvent : IDecreasedHealthEventBefore, IDecreasedHealthEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DefeatEvent"/> *before* its main action.
    /// Implementers can influence whether the defeat executes or is stopped.
    /// </summary>
    public interface IDefeatEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DefeatEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DefeatEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main defeat action.</param>
        void OnDefeatBefore(DefeatEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DefeatEvent"/> *after* its main action.
    /// Implementers react to the defeat once it has occurred.
    /// </summary>
    public interface IDefeatEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DefeatEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DefeatEventArgs"/> for the event.</param>
        void OnDefeatAfter(DefeatEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDefeatEventBefore"/> and <see cref="IDefeatEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DefeatEvent"/>.
    /// </summary>
    public interface IDefeatEvent : IDefeatEventBefore, IDefeatEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardEvent"/> *before* its main action.
    /// Implementers can influence whether the discard executes or is stopped.
    /// </summary>
    public interface IDiscardEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DiscardEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main discard action.</param>
        void OnDiscardBefore(DiscardEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardEvent"/> *after* its main action.
    /// Implementers react to the discard once it has occurred.
    /// </summary>
    public interface IDiscardEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DiscardEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardEventArgs"/> for the event.</param>
        void OnDiscardAfter(DiscardEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDiscardEventBefore"/> and <see cref="IDiscardEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DiscardEvent"/>.
    /// </summary>
    public interface IDiscardEvent : IDiscardEventBefore, IDiscardEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardStepEvent"/> *before* its main action.
    /// Implementers can influence whether the discard step executes or is stopped.
    /// </summary>
    public interface IDiscardStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DiscardStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main discard step action.</param>
        void OnDiscardStepBefore(DiscardStepEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardStepEvent"/> *after* its main action.
    /// Implementers react to the discard step once it has occurred.
    /// </summary>
    public interface IDiscardStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DiscardStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardStepEventArgs"/> for the event.</param>
        void OnDiscardStepAfter(DiscardStepEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDiscardStepEventBefore"/> and <see cref="IDiscardStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DiscardStepEvent"/>.
    /// </summary>
    public interface IDiscardStepEvent : IDiscardStepEventBefore, IDiscardStepEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DodgeEvent"/> *before* its main action.
    /// Implementers can influence whether the dodge executes or is stopped.
    /// </summary>
    public interface IDodgeEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DodgeEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DodgeEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main dodge action.</param>
        void OnDodgeBefore(DodgeEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DodgeEvent"/> *after* its main action.
    /// Implementers react to the dodge once it has occurred.
    /// </summary>
    public interface IDodgeEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DodgeEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DodgeEventArgs"/> for the event.</param>
        void OnDodgeAfter(DodgeEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDodgeEventBefore"/> and <see cref="IDodgeEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DodgeEvent"/>.
    /// </summary>
    public interface IDodgeEvent : IDodgeEventBefore, IDodgeEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawEvent"/> *before* its main action.
    /// Implementers can influence whether the card draw executes or is stopped.
    /// </summary>
    public interface IDrawEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DrawEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card draw action.</param>
        void OnDrawBefore(DrawEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawEvent"/> *after* its main action.
    /// Implementers react to the card draw once it has occurred.
    /// </summary>
    public interface IDrawEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DrawEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawEventArgs"/> for the event.</param>
        void OnDrawAfter(DrawEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDrawEventBefore"/> and <see cref="IDrawEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DrawEvent"/>.
    /// </summary>
    public interface IDrawEvent : IDrawEventBefore, IDrawEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawStepEvent"/> *before* its main action.
    /// Implementers can influence whether the draw step executes or is stopped.
    /// </summary>
    public interface IDrawStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DrawStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main draw step action.</param>
        void OnDrawStepBefore(DrawStepEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawStepEvent"/> *after* its main action.
    /// Implementers react to the draw step once it has occurred.
    /// </summary>
    public interface IDrawStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DrawStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawStepEventArgs"/> for the event.</param>
        void OnDrawStepAfter(DrawStepEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IDrawStepEventBefore"/> and <see cref="IDrawStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DrawStepEvent"/>.
    /// </summary>
    public interface IDrawStepEvent : IDrawStepEventBefore, IDrawStepEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EmptyHandEvent"/> *before* its main action.
    /// Implementers can influence whether the empty hand event executes or is stopped.
    /// </summary>
    public interface IEmptyHandEventBefore {
        /// <summary>
        /// Handler method for the <see cref="EmptyHandEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="EmptyHandEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main empty hand event action.</param>
        void OnEmptyHandBefore(EmptyHandEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EmptyHandEvent"/> *after* its main action.
    /// Implementers react to the empty hand event once it has occurred.
    /// </summary>
    public interface IEmptyHandEventAfter {
        /// <summary>
        /// Handler method for the <see cref="EmptyHandEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="EmptyHandEventArgs"/> for the event.</param>
        void OnEmptyHandAfter(EmptyHandEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IEmptyHandEventBefore"/> and <see cref="IEmptyHandEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="EmptyHandEvent"/>.
    /// </summary>
    public interface IEmptyHandEvent : IEmptyHandEventBefore, IEmptyHandEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EndOfTurnEvent"/> *before* its main action.
    /// Implementers can influence whether the end of turn executes or is stopped.
    /// </summary>
    public interface IEndOfTurnEventBefore {
        /// <summary>
        /// Handler method for the <see cref="EndOfTurnEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="EndOfTurnEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main end of turn action.</param>
        void OnEndOfTurnBefore(EndOfTurnEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EndOfTurnEvent"/> *after* its main action.
    /// Implementers react to the end of turn once it has occurred.
    /// </summary>
    public interface IEndOfTurnEventAfter {
        /// <summary>
        /// Handler method for the <see cref="EndOfTurnEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="EndOfTurnEventArgs"/> for the event.</param>
        void OnEndOfTurnAfter(EndOfTurnEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IEndOfTurnEventBefore"/> and <see cref="IEndOfTurnEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="EndOfTurnEvent"/>.
    /// </summary>
    public interface IEndOfTurnEvent : IEndOfTurnEventBefore, IEndOfTurnEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="FlipEvent"/> *before* its main action.
    /// Implementers can influence whether the card flip executes or is stopped.
    /// </summary>
    public interface IFlipEventBefore {
        /// <summary>
        /// Handler method for the <see cref="FlipEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="FlipEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card flip action.</param>
        void OnFlipBefore(FlipEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="FlipEvent"/> *after* its main action.
    /// Implementers react to the card flip once it has occurred.
    /// </summary>
    public interface IFlipEventAfter {
        /// <summary>
        /// Handler method for the <see cref="FlipEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="FlipEventArgs"/> for the event.</param>
        void OnFlipAfter(FlipEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IFlipEventBefore"/> and <see cref="IFlipEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="FlipEvent"/>.
    /// </summary>
    public interface IFlipEvent : IFlipEventBefore, IFlipEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="GameStateEvent"/> *before* its main action.
    /// Implementers can influence whether the game state change executes or is stopped.
    /// </summary>
    public interface IGameStateEventBefore {
        /// <summary>
        /// Handler method for the <see cref="GameStateEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="GameStateEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main game state change action.</param>
        void OnGameStateBefore(GameStateEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="GameStateEvent"/> *after* its main action.
    /// Implementers react to the game state change once it has occurred.
    /// </summary>
    public interface IGameStateEventAfter {
        /// <summary>
        /// Handler method for the <see cref="GameStateEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="GameStateEventArgs"/> for the event.</param>
        void OnGameStateAfter(GameStateEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IGameStateEventBefore"/> and <see cref="IGameStateEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="GameStateEvent"/>.
    /// </summary>
    public interface IGameStateEvent : IGameStateEventBefore, IGameStateEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandRevealedEvent"/> *before* its main action.
    /// Implementers can influence whether the hand revelation executes or is stopped.
    /// </summary>
    public interface IHandRevealedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="HandRevealedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandRevealedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main hand revelation action.</param>
        void OnHandRevealedBefore(HandRevealedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandRevealedEvent"/> *after* its main action.
    /// Implementers react to the hand revelation once it has occurred.
    /// </summary>
    public interface IHandRevealedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="HandRevealedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandRevealedEventArgs"/> for the event.</param>
        void OnHandRevealedAfter(HandRevealedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IHandRevealedEventBefore"/> and <see cref="IHandRevealedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="HandRevealedEvent"/>.
    /// </summary>
    public interface IHandRevealedEvent : IHandRevealedEventBefore, IHandRevealedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandSwappedEvent"/> *before* its main action.
    /// Implementers can influence whether the hand swap executes or is stopped.
    /// </summary>
    public interface IHandSwappedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="HandSwappedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandSwappedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main hand swap action.</param>
        void OnHandSwappedBefore(HandSwappedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandSwappedEvent"/> *after* its main action.
    /// Implementers react to the hand swap once it has occurred.
    /// </summary>
    public interface IHandSwappedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="HandSwappedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandSwappedEventArgs"/> for the event.</param>
        void OnHandSwappedAfter(HandSwappedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IHandSwappedEventBefore"/> and <see cref="IHandSwappedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="HandSwappedEvent"/>.
    /// </summary>
    public interface IHandSwappedEvent : IHandSwappedEventBefore, IHandSwappedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentResolvedEvent"/> *before* its main action.
    /// Implementers can influence whether the incident resolution executes or is stopped.
    /// </summary>
    public interface IIncidentResolvedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="IncidentResolvedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentResolvedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main incident resolution action.</param>
        void OnIncidentResolvedBefore(IncidentResolvedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentResolvedEvent"/> *after* its main action.
    /// Implementers react to the incident resolution once it has occurred.
    /// </summary>
    public interface IIncidentResolvedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="IncidentResolvedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentResolvedEventArgs"/> for the event.</param>
        void OnIncidentResolvedAfter(IncidentResolvedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IIncidentResolvedEventBefore"/> and <see cref="IIncidentResolvedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="IncidentResolvedEvent"/>.
    /// </summary>
    public interface IIncidentResolvedEvent : IIncidentResolvedEventBefore, IIncidentResolvedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentStepEvent"/> *before* its main action.
    /// Implementers can influence whether the incident step executes or is stopped.
    /// </summary>
    public interface IIncidentStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="IncidentStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main incident step action.</param>
        void OnIncidentStepBefore(IncidentStepEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentStepEvent"/> *after* its main action.
    /// Implementers react to the incident step once it has occurred.
    /// </summary>
    public interface IIncidentStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="IncidentStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentStepEventArgs"/> for the event.</param>
        void OnIncidentStepAfter(IncidentStepEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IIncidentStepEventBefore"/> and <see cref="IIncidentStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="IncidentStepEvent"/>.
    /// </summary>
    public interface IIncidentStepEvent : IIncidentStepEventBefore, IIncidentStepEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncreasedHealthEvent"/> *before* its main action.
    /// Implementers can influence whether the health increase executes or is stopped.
    /// </summary>
    public interface IIncreasedHealthEventBefore {
        /// <summary>
        /// Handler method for the <see cref="IncreasedHealthEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncreasedHealthEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main health increase action.</param>
        void OnIncreasedHealthBefore(IncreasedHealthEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncreasedHealthEvent"/> *after* its main action.
    /// Implementers react to the health increase once it has occurred.
    /// </summary>
    public interface IIncreasedHealthEventAfter {
        /// <summary>
        /// Handler method for the <see cref="IncreasedHealthEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncreasedHealthEventArgs"/> for the event.</param>
        void OnIncreasedHealthAfter(IncreasedHealthEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IIncreasedHealthEventBefore"/> and <see cref="IIncreasedHealthEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="IncreasedHealthEvent"/>.
    /// </summary>
    public interface IIncreasedHealthEvent : IIncreasedHealthEventBefore, IIncreasedHealthEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemDiscardedEvent"/> *before* its main action.
    /// Implementers can influence whether the item discard executes or is stopped.
    /// </summary>
    public interface IItemDiscardedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="ItemDiscardedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemDiscardedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main item discard action.</param>
        void OnItemDiscardedBefore(ItemDiscardedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemDiscardedEvent"/> *after* its main action.
    /// Implementers react to the item discard once it has occurred.
    /// </summary>
    public interface IItemDiscardedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="ItemDiscardedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemDiscardedEventArgs"/> for the event.</param>
        void OnItemDiscardedAfter(ItemDiscardedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IItemDiscardedEventBefore"/> and <see cref="IItemDiscardedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="ItemDiscardedEvent"/>.
    /// </summary>
    public interface IItemDiscardedEvent : IItemDiscardedEventBefore, IItemDiscardedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemPlayedEvent"/> *before* its main action.
    /// Implementers can influence whether the item played executes or is stopped.
    /// </summary>
    public interface IItemPlayedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="ItemPlayedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemPlayedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main item played action.</param>
        void OnItemPlayedBefore(ItemPlayedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemPlayedEvent"/> *after* its main action.
    /// Implementers react to the item played once it has occurred.
    /// </summary>
    public interface IItemPlayedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="ItemPlayedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemPlayedEventArgs"/> for the event.</param>
        void OnItemPlayedAfter(ItemPlayedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IItemPlayedEventBefore"/> and <see cref="IItemPlayedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="ItemPlayedEvent"/>.
    /// </summary>
    public interface IItemPlayedEvent : IItemPlayedEventBefore, IItemPlayedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="MainStepEvent"/> *before* its main action.
    /// Implementers can influence whether the main step executes or is stopped.
    /// </summary>
    public interface IMainStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="MainStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="MainStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main main step action.</param>
        void OnMainStepBefore(MainStepEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="MainStepEvent"/> *after* its main action.
    /// Implementers react to the main step once it has occurred.
    /// </summary>
    public interface IMainStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="MainStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="MainStepEventArgs"/> for the event.</param>
        void OnMainStepAfter(MainStepEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IMainStepEventBefore"/> and <see cref="IMainStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="MainStepEvent"/>.
    /// </summary>
    public interface IMainStepEvent : IMainStepEventBefore, IMainStepEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="NewIncidentEvent"/> *before* its main action.
    /// Implementers can influence whether the new incident revelation executes or is stopped.
    /// </summary>
    public interface INewIncidentEventBefore {
        /// <summary>
        /// Handler method for the <see cref="NewIncidentEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="NewIncidentEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main new incident revelation action.</param>
        void OnNewIncidentBefore(NewIncidentEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="NewIncidentEvent"/> *after* its main action.
    /// Implementers react to the new incident revelation once it has occurred.
    /// </summary>
    public interface INewIncidentEventAfter {
        /// <summary>
        /// Handler method for the <see cref="NewIncidentEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="NewIncidentEventArgs"/> for the event.</param>
        void OnNewIncidentAfter(NewIncidentEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="INewIncidentEventBefore"/> and <see cref="INewIncidentEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="NewIncidentEvent"/>.
    /// </summary>
    public interface INewIncidentEvent : INewIncidentEventBefore, INewIncidentEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleRevealedEvent"/> *before* its main action.
    /// Implementers can influence whether the role revelation executes or is stopped.
    /// </summary>
    public interface IRoleRevealedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="RoleRevealedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleRevealedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main role revelation action.</param>
        void OnRoleRevealedBefore(RoleRevealedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleRevealedEvent"/> *after* its main action.
    /// Implementers react to the role revelation once it has occurred.
    /// </summary>
    public interface IRoleRevealedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="RoleRevealedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleRevealedEventArgs"/> for the event.</param>
        void OnRoleRevealedAfter(RoleRevealedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IRoleRevealedEventBefore"/> and <see cref="IRoleRevealedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="RoleRevealedEvent"/>.
    /// </summary>
    public interface IRoleRevealedEvent : IRoleRevealedEventBefore, IRoleRevealedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleSwappedEvent"/> *before* its main action.
    /// Implementers can influence whether the role swap executes or is stopped.
    /// </summary>
    public interface IRoleSwappedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="RoleSwappedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleSwappedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main role swap action.</param>
        void OnRoleSwappedBefore(RoleSwappedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleSwappedEvent"/> *after* its main action.
    /// Implementers react to the role swap once it has occurred.
    /// </summary>
    public interface IRoleSwappedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="RoleSwappedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleSwappedEventArgs"/> for the event.</param>
        void OnRoleSwappedAfter(RoleSwappedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IRoleSwappedEventBefore"/> and <see cref="IRoleSwappedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="RoleSwappedEvent"/>.
    /// </summary>
    public interface IRoleSwappedEvent : IRoleSwappedEventBefore, IRoleSwappedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardActivatedEvent"/> *before* its main action.
    /// Implementers can influence whether the spell card activation executes or is stopped.
    /// </summary>
    public interface ISpellCardActivatedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="SpellCardActivatedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardActivatedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main spell card activation action.</param>
        void OnSpellCardActivatedBefore(SpellCardActivatedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardActivatedEvent"/> *after* its main action.
    /// Implementers react to the spell card activation once it has occurred.
    /// </summary>
    public interface ISpellCardActivatedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="SpellCardActivatedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardActivatedEventArgs"/> for the event.</param>
        void OnSpellCardActivatedAfter(SpellCardActivatedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ISpellCardActivatedEventBefore"/> and <see cref="ISpellCardActivatedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="SpellCardActivatedEvent"/>.
    /// </summary>
    public interface ISpellCardActivatedEvent : ISpellCardActivatedEventBefore, ISpellCardActivatedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardCancelledEvent"/> *before* its main action.
    /// Implementers can influence whether the spell card cancellation executes or is stopped.
    /// </summary>
    public interface ISpellCardCancelledEventBefore {
        /// <summary>
        /// Handler method for the <see cref="SpellCardCancelledEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardCancelledEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main spell card cancellation action.</param>
        void OnSpellCardCancelledBefore(SpellCardCancelledEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardCancelledEvent"/> *after* its main action.
    /// Implementers react to the spell card cancellation once it has occurred.
    /// </summary>
    public interface ISpellCardCancelledEventAfter {
        /// <summary>
        /// Handler method for the <see cref="SpellCardCancelledEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardCancelledEventArgs"/> for the event.</param>
        void OnSpellCardCancelledAfter(SpellCardCancelledEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ISpellCardCancelledEventBefore"/> and <see cref="ISpellCardCancelledEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="SpellCardCancelledEvent"/>.
    /// </summary>
    public interface ISpellCardCancelledEvent : ISpellCardCancelledEventBefore, ISpellCardCancelledEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StackResolvedEvent"/> *before* its main action.
    /// Implementers can influence whether the stack resolution executes or is stopped.
    /// </summary>
    public interface IStackResolvedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="StackResolvedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="StackResolvedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main stack resolution action.</param>
        void OnStackResolvedBefore(StackResolvedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StackResolvedEvent"/> *after* its main action.
    /// Implementers react to the stack resolution once it has occurred.
    /// </summary>
    public interface IStackResolvedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="StackResolvedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="StackResolvedEventArgs"/> for the event.</param>
        void OnStackResolvedAfter(StackResolvedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IStackResolvedEventBefore"/> and <see cref="IStackResolvedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="StackResolvedEvent"/>.
    /// </summary>
    public interface IStackResolvedEvent : IStackResolvedEventBefore, IStackResolvedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StartOfTurnEvent"/> *before* its main action.
    /// Implementers can influence whether the turn start executes or is stopped.
    /// </summary>
    public interface IStartOfTurnEventBefore {
        /// <summary>
        /// Handler method for the <see cref="StartOfTurnEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="StartOfTurnEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main turn start action.</param>
        void OnStartOfTurnBefore(StartOfTurnEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StartOfTurnEvent"/> *after* its main action.
    /// Implementers react to the <see cref="StartOfTurnEvent"/> once it has occurred.
    /// </summary>
    public interface IStartOfTurnEventAfter {
        /// <summary>
        /// Handler method for the <see cref="StartOfTurnEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="StartOfTurnEventArgs"/> for the event.</param>
        void OnStartOfTurnAfter(StartOfTurnEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="IStartOfTurnEventBefore"/> and <see cref="IStartOfTurnEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="StartOfTurnEvent"/>.
    /// </summary>
    public interface IStartOfTurnEvent : IStartOfTurnEventBefore, IStartOfTurnEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnChangeEvent"/> *before* its main action.
    /// Implementers can influence whether the turn change executes or is stopped.
    /// </summary>
    public interface ITurnChangeEventBefore {
        /// <summary>
        /// Handler method for the <see cref="TurnChangeEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnChangeEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main turn change action.</param>
        void OnTurnChangeBefore(TurnChangeEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnChangeEvent"/> *after* its main action.
    /// Implementers react to the turn change once it has occurred.
    /// </summary>
    public interface ITurnChangeEventAfter {
        /// <summary>
        /// Handler method for the <see cref="TurnChangeEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnChangeEventArgs"/> for the event.</param>
        void OnTurnChangeAfter(TurnChangeEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ITurnChangeEventBefore"/> and <see cref="ITurnChangeEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="TurnChangeEvent"/>.
    /// </summary>
    public interface ITurnChangeEvent : ITurnChangeEventBefore, ITurnChangeEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnSkippedEvent"/> *before* its main action.
    /// Implementers can influence whether the turn skip executes or is stopped.
    /// </summary>
    public interface ITurnSkippedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="TurnSkippedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnSkippedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main turn skip action.</param>
        void OnTurnSkippedBefore(TurnSkippedEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnSkippedEvent"/> *after* its main action.
    /// Implementers react to the turn skip once it has occurred.
    /// </summary>
    public interface ITurnSkippedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="TurnSkippedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnSkippedEventArgs"/> for the event.</param>
        void OnTurnSkippedAfter(TurnSkippedEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ITurnSkippedEventBefore"/> and <see cref="ITurnSkippedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="TurnSkippedEvent"/>.
    /// </summary>
    public interface ITurnSkippedEvent : ITurnSkippedEventBefore, ITurnSkippedEventAfter { }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnZeroEvent"/> *before* its main action.
    /// Implementers can influence whether Turn Zero executes or is stopped.
    /// </summary>
    public interface ITurnZeroEventBefore {
        /// <summary>
        /// Handler method for the <see cref="TurnZeroEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnZeroEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main Turn Zero action.</param>
        void OnTurnZeroBefore(TurnZeroEventArgs args, out bool bubbleEvent);
    }

    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnZeroEvent"/> *after* its main action.
    /// Implementers react to Turn Zero once it has occurred.
    /// </summary>
    public interface ITurnZeroEventAfter {
        /// <summary>
        /// Handler method for the <see cref="TurnZeroEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnZeroEventArgs"/> for the event.</param>
        void OnTurnZeroAfter(TurnZeroEventArgs args);
    }

    /// <summary>
    /// Combines the <see cref="ITurnZeroEventBefore"/> and <see cref="ITurnZeroEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="TurnZeroEvent"/>.
    /// </summary>
    public interface ITurnZeroEvent : ITurnZeroEventBefore, ITurnZeroEventAfter { }

}