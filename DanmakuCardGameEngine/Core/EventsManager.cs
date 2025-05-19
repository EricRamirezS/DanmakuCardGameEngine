using DanmakuCardGameEngine.Events;

namespace DanmakuCardGameEngine.Core {
    public interface IEventManager {
        AbilityActivatedEvent OnAbilityActivated { get; }
        AttackEvent OnAttack { get; }
        CancelEvent OnCancel { get; }
        CardEntersDiscardPileEvent OnCardEntersDiscardPile { get; }
        CardPlayedEvent OnCardPlayed { get; }
        CardResolvedEvent OnCardResolved { get; }
        CardsCollectedEvent OnCardsCollected { get; }
        DanmakuPlayedEvent OnDanmakuPlayed { get; }
        DeckShuffledEvent OnDeckShuffled { get; }
        DecreasedHealthEvent OnDecreasedHealth { get; }
        DefeatEvent OnDefeat { get; }
        DiscardEvent OnDiscard { get; }
        DiscardStepEvent OnDiscardStep { get; }
        DodgeEvent OnDodge { get; }
        DrawEvent OnDraw { get; }
        DrawStepEvent OnDrawStep { get; }
        EmptyHandEvent OnEmptyHand { get; }
        EncounterStepEvent OnEncounterStep { get; }
        EndOfTurnEvent OnEndOfTurn { get; }
        FlipEvent OnFlip { get; }
        GameStateEvent OnGameState { get; }
        HandRevealedEvent OnHandRevealed { get; }
        HandSwappedEvent OnHandSwapped { get; }
        IncidentResolvedEvent OnIncidentResolved { get; }
        IncidentStepEvent OnIncidentStep { get; }
        IncreasedHealthEvent OnIncreasedHealth { get; }
        ItemDiscardedEvent OnItemDiscarded { get; }
        ItemPlayedEvent OnItemPlayed { get; }
        MainStepEvent OnMainStep { get; }
        MobAttackStepEvent OnMobAttackStep { get; }
        NewIncidentEvent OnNewIncident { get; }
        RoleRevealedEvent OnRoleRevealed { get; }
        RoleSwappedEvent OnRoleSwapped { get; }
        SpellCardActivatedEvent OnSpellCardActivated { get; }
        SpellCardCancelledEvent OnSpellCardCancelled { get; }
        StackResolvedEvent OnStackResolved { get; }
        StandbyEvent OnStandby { get; }
        StartOfTurnEvent OnStartOfTurn { get; }
        TurnSkippedEvent OnTurnSkipped { get; }
        TurnZeroEvent OnTurnZero { get; }
    }

    public class EventManager : IEventManager {

        internal EventManager() { }


        public AbilityActivatedEvent OnAbilityActivated { get; } = new AbilityActivatedEvent();
        public AttackEvent OnAttack { get; } = new AttackEvent();
        public CancelEvent OnCancel { get; } = new CancelEvent();
        public CardEntersDiscardPileEvent OnCardEntersDiscardPile { get; } = new CardEntersDiscardPileEvent();
        public CardPlayedEvent OnCardPlayed { get; } = new CardPlayedEvent();
        public CardResolvedEvent OnCardResolved { get; } = new CardResolvedEvent();
        public CardsCollectedEvent OnCardsCollected { get; } = new CardsCollectedEvent();
        public DanmakuPlayedEvent OnDanmakuPlayed { get; } = new DanmakuPlayedEvent();
        public DeckShuffledEvent OnDeckShuffled { get; } = new DeckShuffledEvent();
        public DecreasedHealthEvent OnDecreasedHealth { get; } = new DecreasedHealthEvent();
        public DefeatEvent OnDefeat { get; } = new DefeatEvent();
        public DiscardEvent OnDiscard { get; } = new DiscardEvent();
        public DiscardStepEvent OnDiscardStep { get; } = new DiscardStepEvent();
        public DodgeEvent OnDodge { get; } = new DodgeEvent();
        public DrawEvent OnDraw { get; } = new DrawEvent();
        public DrawStepEvent OnDrawStep { get; } = new DrawStepEvent();
        public EmptyHandEvent OnEmptyHand { get; } = new EmptyHandEvent();
        public EncounterStepEvent OnEncounterStep { get; } = new EncounterStepEvent();
        public EndOfTurnEvent OnEndOfTurn { get; } = new EndOfTurnEvent();
        public FlipEvent OnFlip { get; } = new FlipEvent();
        public GameStateEvent OnGameState { get; } = new GameStateEvent();
        public HandRevealedEvent OnHandRevealed { get; } = new HandRevealedEvent();
        public HandSwappedEvent OnHandSwapped { get; } = new HandSwappedEvent();
        public IncidentResolvedEvent OnIncidentResolved { get; } = new IncidentResolvedEvent();
        public IncidentStepEvent OnIncidentStep { get; } = new IncidentStepEvent();
        public IncreasedHealthEvent OnIncreasedHealth { get; } = new IncreasedHealthEvent();
        public ItemDiscardedEvent OnItemDiscarded { get; } = new ItemDiscardedEvent();
        public ItemPlayedEvent OnItemPlayed { get; } = new ItemPlayedEvent();
        public MainStepEvent OnMainStep { get; } = new MainStepEvent();
        public MobAttackStepEvent OnMobAttackStep { get; } = new MobAttackStepEvent();
        public NewIncidentEvent OnNewIncident { get; } = new NewIncidentEvent();
        public RoleRevealedEvent OnRoleRevealed { get; } = new RoleRevealedEvent();
        public RoleSwappedEvent OnRoleSwapped { get; } = new RoleSwappedEvent();
        public SpellCardActivatedEvent OnSpellCardActivated { get; } = new SpellCardActivatedEvent();
        public SpellCardCancelledEvent OnSpellCardCancelled { get; } = new SpellCardCancelledEvent();
        public StackResolvedEvent OnStackResolved { get; } = new StackResolvedEvent();
        public StandbyEvent OnStandby { get; } = new StandbyEvent();
        public StartOfTurnEvent OnStartOfTurn { get; } = new StartOfTurnEvent();
        public TurnSkippedEvent OnTurnSkipped { get; } = new TurnSkippedEvent();
        public TurnZeroEvent OnTurnZero { get; } = new TurnZeroEvent();
    }
}