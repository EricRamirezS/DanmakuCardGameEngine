using DanmakuCardGameEngine.Events;

namespace DanmakuCardGameEngine.Core {
    /// <summary>
    /// Defines the interface for a central event manager that provides access to all game events.
    /// Components can subscribe to these events to react to various occurrences within the game engine.
    /// </summary>
    public interface IEventManager {
        /// <summary>
        /// Gets the event that is raised when an ability is activated.
        /// </summary>
        AbilityActivatedEvent OnAbilityActivated { get; }
        /// <summary>
        /// Gets the event that is raised when an attack occurs.
        /// </summary>
        AttackEvent OnAttack { get; }
        /// <summary>
        /// Gets the event that is raised when a game action or card play is cancelled.
        /// </summary>
        CancelEvent OnCancel { get; }
        /// <summary>
        /// Gets the event that is raised when cards enter the discard pile.
        /// </summary>
        CardsEnterDiscardPileEvent OnCardsEnterDiscardPile { get; }
        /// <summary>
        /// Gets the event that is raised when a card is played.
        /// </summary>
        CardPlayedEvent OnCardPlayed { get; }
        /// <summary>
        /// Gets the event that is raised when a card's effects are resolved.
        /// </summary>
        CardResolvedEvent OnCardResolved { get; }
        /// <summary>
        /// Gets the event that is raised when cards are collected (e.g., after an incident).
        /// </summary>
        CardsCollectedEvent OnCardsCollected { get; }
        /// <summary>
        /// Gets the event that is raised when a Danmaku card is played.
        /// </summary>
        DanmakuPlayedEvent OnDanmakuPlayed { get; }
        /// <summary>
        /// Gets the event that is raised when a deck is shuffled.
        /// </summary>
        DeckShuffledEvent OnDeckShuffled { get; }
        /// <summary>
        /// Gets the event that is raised when a player's health decreases.
        /// </summary>
        DecreasedHealthEvent OnDecreasedHealth { get; }
        /// <summary>
        /// Gets the event that is raised when a player is defeated.
        /// </summary>
        DefeatEvent OnDefeat { get; }
        /// <summary>
        /// Gets the event that is raised when cards are discarded.
        /// </summary>
        DiscardEvent OnDiscard { get; }
        /// <summary>
        /// Gets the event that is raised during the discard step of a turn.
        /// </summary>
        DiscardStepEvent OnDiscardStep { get; }
        /// <summary>
        /// Gets the event that is raised when a player dodges an attack.
        /// </summary>
        DodgeEvent OnDodge { get; }
        /// <summary>
        /// Gets the event that is raised when cards are drawn.
        /// </summary>
        DrawEvent OnDraw { get; }
        /// <summary>
        /// Gets the event that is raised during the draw step of a turn.
        /// </summary>
        DrawStepEvent OnDrawStep { get; }
        /// <summary>
        /// Gets the event that is raised when a player's hand becomes empty.
        /// </summary>
        EmptyHandEvent OnEmptyHand { get; }
        /// <summary>
        /// Gets the event that is raised at the end of a turn.
        /// </summary>
        EndOfTurnEvent OnEndOfTurn { get; }
        /// <summary>
        /// Gets the event that is raised when a card is flipped from a deck.
        /// </summary>
        FlipEvent OnFlip { get; }
        /// <summary>
        /// Gets the event that is raised when the game state changes.
        /// </summary>
        GameStateEvent OnGameState { get; }
        /// <summary>
        /// Gets the event that is raised when a player's hand is revealed.
        /// </summary>
        HandRevealedEvent OnHandRevealed { get; }
        /// <summary>
        /// Gets the event that is raised when two players' hands are swapped.
        /// </summary>
        HandSwappedEvent OnHandSwapped { get; }
        /// <summary>
        /// Gets the event that is raised when an incident is resolved.
        /// </summary>
        IncidentResolvedEvent OnIncidentResolved { get; }
        /// <summary>
        /// Gets the event that is raised during the incident step of a turn.
        /// </summary>
        IncidentStepEvent OnIncidentStep { get; }
        /// <summary>
        /// Gets the event that is raised when a player's health increases.
        /// </summary>
        IncreasedHealthEvent OnIncreasedHealth { get; }
        /// <summary>
        /// Gets the event that is raised when an Item card is discarded.
        /// </summary>
        ItemDiscardedEvent OnItemDiscarded { get; }
        /// <summary>
        /// Gets the event that is raised when an Item card is played.
        /// </summary>
        ItemPlayedEvent OnItemPlayed { get; }
        /// <summary>
        /// Gets the event that is raised during the main step of a turn.
        /// </summary>
        MainStepEvent OnMainStep { get; }
        /// <summary>
        /// Gets the event that is raised when a new Incident card is revealed.
        /// </summary>
        NewIncidentEvent OnNewIncident { get; }
        /// <summary>
        /// Gets the event that is raised when a player's Role card is revealed.
        /// </summary>
        RoleRevealedEvent OnRoleRevealed { get; }
        /// <summary>
        /// Gets the event that is raised when two players' Role cards are swapped.
        /// </summary>
        RoleSwappedEvent OnRoleSwapped { get; }
        /// <summary>
        /// Gets the event that is raised when the round number changes.
        /// </summary>
        RoundChangeEvent OnRoundChange { get; }
        /// <summary>
        /// Gets the event that is raised when a Spell Card is activated.
        /// </summary>
        SpellCardActivatedEvent OnSpellCardActivated { get; }
        /// <summary>
        /// Gets the event that is raised when a Spell Card is cancelled.
        /// </summary>
        SpellCardCancelledEvent OnSpellCardCancelled { get; }
        /// <summary>
        /// Gets the event that is raised when the game's effect stack has been resolved.
        /// </summary>
        StackResolvedEvent OnStackResolved { get; }
        /// <summary>
        /// Gets the event that is raised at the start of a turn.
        /// </summary>
        StartOfTurnEvent OnStartOfTurn { get; }
        /// <summary>
        /// Gets the event that is raised when the turn number changes.
        /// </summary>
        TurnChangeEvent OnTurnChange { get; }
        /// <summary>
        /// Gets the event that is raised when a player's turn is skipped.
        /// </summary>
        TurnSkippedEvent OnTurnSkipped { get; }
        /// <summary>
        /// Gets the event that is raised at the start of the special "turn zero" of the game.
        /// </summary>
        TurnZeroEvent OnTurnZero { get; }
    }

    /// <summary>
    /// Implements the <see cref="IEventManager"/> interface, providing concrete instances of all game events.
    /// This class acts as the central hub for event management within the Danmaku Card Game Engine.
    /// </summary>
    public class EventManager : IEventManager {

        /// <summary>
        /// Initializes a new instance of the <see cref="EventManager"/> class.
        /// This constructor is marked as internal, indicating that instances of EventManager
        /// should typically be managed and provided by the core engine (e.g., via a singleton pattern).
        /// </summary>
        internal EventManager() { }

        /// <summary>
        /// Gets the event that is raised when an ability is activated.
        /// </summary>
        public AbilityActivatedEvent OnAbilityActivated { get; } = new AbilityActivatedEvent();
        /// <summary>
        /// Gets the event that is raised when an attack occurs.
        /// </summary>
        public AttackEvent OnAttack { get; } = new AttackEvent();
        /// <summary>
        /// Gets the event that is raised when a game action or card play is cancelled.
        /// </summary>
        public CancelEvent OnCancel { get; } = new CancelEvent();
        /// <summary>
        /// Gets the event that is raised when cards enter the discard pile.
        /// </summary>
        public CardsEnterDiscardPileEvent OnCardsEnterDiscardPile { get; } = new CardsEnterDiscardPileEvent();
        /// <summary>
        /// Gets the event that is raised when a card is played.
        /// </summary>
        public CardPlayedEvent OnCardPlayed { get; } = new CardPlayedEvent();
        /// <summary>
        /// Gets the event that is raised when a card's effects are resolved.
        /// </summary>
        public CardResolvedEvent OnCardResolved { get; } = new CardResolvedEvent();
        /// <summary>
        /// Gets the event that is raised when cards are collected (e.g., after an incident).
        /// </summary>
        public CardsCollectedEvent OnCardsCollected { get; } = new CardsCollectedEvent();
        /// <summary>
        /// Gets the event that is raised when a Danmaku card is played.
        /// </summary>
        public DanmakuPlayedEvent OnDanmakuPlayed { get; } = new DanmakuPlayedEvent();
        /// <summary>
        /// Gets the event that is raised when a deck is shuffled.
        /// </summary>
        public DeckShuffledEvent OnDeckShuffled { get; } = new DeckShuffledEvent();
        /// <summary>
        /// Gets the event that is raised when a player's health decreases.
        /// </summary>
        public DecreasedHealthEvent OnDecreasedHealth { get; } = new DecreasedHealthEvent();
        /// <summary>
        /// Gets the event that is raised when a player is defeated.
        /// </summary>
        public DefeatEvent OnDefeat { get; } = new DefeatEvent();
        /// <summary>
        /// Gets the event that is raised when cards are discarded.
        /// </summary>
        public DiscardEvent OnDiscard { get; } = new DiscardEvent();
        /// <summary>
        /// Gets the event that is raised during the discard step of a turn.
        /// </summary>
        public DiscardStepEvent OnDiscardStep { get; } = new DiscardStepEvent();
        /// <summary>
        /// Gets the event that is raised when a player dodges an attack.
        /// </summary>
        public DodgeEvent OnDodge { get; } = new DodgeEvent();
        /// <summary>
        /// Gets the event that is raised when cards are drawn.
        /// </summary>
        public DrawEvent OnDraw { get; } = new DrawEvent();
        /// <summary>
        /// Gets the event that is raised during the draw step of a turn.
        /// </summary>
        public DrawStepEvent OnDrawStep { get; } = new DrawStepEvent();
        /// <summary>
        /// Gets the event that is raised when a player's hand becomes empty.
        /// </summary>
        public EmptyHandEvent OnEmptyHand { get; } = new EmptyHandEvent();
        /// <summary>
        /// Gets the event that is raised at the end of a turn.
        /// </summary>
        public EndOfTurnEvent OnEndOfTurn { get; } = new EndOfTurnEvent();
        /// <summary>
        /// Gets the event that is raised when a card is flipped from a deck.
        /// </summary>
        public FlipEvent OnFlip { get; } = new FlipEvent();
        /// <summary>
        /// Gets the event that is raised when the game state changes.
        /// </summary>
        public GameStateEvent OnGameState { get; } = new GameStateEvent();
        /// <summary>
        /// Gets the event that is raised when a player's hand is revealed.
        /// </summary>
        public HandRevealedEvent OnHandRevealed { get; } = new HandRevealedEvent();
        /// <summary>
        /// Gets the event that is raised when two players' hands are swapped.
        /// </summary>
        public HandSwappedEvent OnHandSwapped { get; } = new HandSwappedEvent();
        /// <summary>
        /// Gets the event that is raised when an incident is resolved.
        /// </summary>
        public IncidentResolvedEvent OnIncidentResolved { get; } = new IncidentResolvedEvent();
        /// <summary>
        /// Gets the event that is raised during the incident step of a turn.
        /// </summary>
        public IncidentStepEvent OnIncidentStep { get; } = new IncidentStepEvent();
        /// <summary>
        /// Gets the event that is raised when a player's health increases.
        /// </summary>
        public IncreasedHealthEvent OnIncreasedHealth { get; } = new IncreasedHealthEvent();
        /// <summary>
        /// Gets the event that is raised when an Item card is discarded.
        /// </summary>
        public ItemDiscardedEvent OnItemDiscarded { get; } = new ItemDiscardedEvent();
        /// <summary>
        /// Gets the event that is raised when an Item card is played.
        /// </summary>
        public ItemPlayedEvent OnItemPlayed { get; } = new ItemPlayedEvent();
        /// <summary>
        /// Gets the event that is raised during the main step of a turn.
        /// </summary>
        public MainStepEvent OnMainStep { get; } = new MainStepEvent();
        /// <summary>
        /// Gets the event that is raised when a new Incident card is revealed.
        /// </summary>
        public NewIncidentEvent OnNewIncident { get; } = new NewIncidentEvent();
        /// <summary>
        /// Gets the event that is raised when a player's Role card is revealed.
        /// </summary>
        public RoleRevealedEvent OnRoleRevealed { get; } = new RoleRevealedEvent();
        /// <summary>
        /// Gets the event that is raised when two players' Role cards are swapped.
        /// </summary>
        public RoleSwappedEvent OnRoleSwapped { get; } = new RoleSwappedEvent();
        /// <summary>
        /// Gets the event that is raised when the round number changes.
        /// </summary>
        public RoundChangeEvent OnRoundChange { get; } = new RoundChangeEvent();
        /// <summary>
        /// Gets the event that is raised when a Spell Card is activated.
        /// </summary>
        public SpellCardActivatedEvent OnSpellCardActivated { get; } = new SpellCardActivatedEvent();
        /// <summary>
        /// Gets the event that is raised when a Spell Card is cancelled.
        /// </summary>
        public SpellCardCancelledEvent OnSpellCardCancelled { get; } = new SpellCardCancelledEvent();
        /// <summary>
        /// Gets the event that is raised when the game's effect stack has been resolved.
        /// </summary>
        public StackResolvedEvent OnStackResolved { get; } = new StackResolvedEvent();
        /// <summary>
        /// Gets the event that is raised at the start of a turn.
        /// </summary>
        public StartOfTurnEvent OnStartOfTurn { get; } = new StartOfTurnEvent();
        /// <summary>
        /// Gets the event that is raised when the turn number changes.
        /// </summary>
        public TurnChangeEvent OnTurnChange { get; } = new TurnChangeEvent();
        /// <summary>
        /// Gets the event that is raised when a player's turn is skipped.
        /// </summary>
        public TurnSkippedEvent OnTurnSkipped { get; } = new TurnSkippedEvent();
        /// <summary>
        /// Gets the event that is raised at the start of the special "turn zero" of the game.
        /// </summary>
        public TurnZeroEvent OnTurnZero { get; } = new TurnZeroEvent();
    }
}
