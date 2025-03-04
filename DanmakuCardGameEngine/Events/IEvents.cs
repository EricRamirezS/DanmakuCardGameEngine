namespace DanmakuCG_Data.Models.Events;

public interface IEvents : IAbilityActivatedAfter, IAbilityActivatedBefore, IAttackAfter, IAttackBefore, ICancelAfter,
    ICancelBefore, ICardEntersDiscardPileAfter, ICardEntersDiscardPileBefore, ICardPlayedAfter, ICardPlayedBefore,
    ICardResolvedAfter, ICardResolvedBefore, ICardsCollectedAfter, ICardsCollectedBefore, IDanmakuPlayedAfter,
    IDanmakuPlayedBefore, IDeckShuffledAfter, IDeckShuffledBefore, IDecreasedHealthAfter, IDecreasedHealthBefore,
    IDefeatAfter, IDefeatBefore, IDiscardAfter, IDiscardBefore, IDiscardStepAfter, IDiscardStepBefore, IDodgeAfter,
    IDodgeBefore, IDrawAfter, IDrawBefore, IDrawStepAfter, IDrawStepBefore, IEmptyHandAfter, IEmptyHandBefore,
    IEncounterStepAfter, IEncounterStepBefore, IEndOfTurnAfter, IEndOfTurnBefore, IFlipAfter, IFlipBefore,
    IHandRevealedAfter, IHandRevealedBefore, IHandSwappedAfter, IHandSwappedBefore, IIncidentResolvedAfter,
    IIncidentResolvedBefore, IIncidentStepAfter, IIncidentStepBefore, IIncreasedHealthAfter, IIncreasedHealthBefore,
    IItemDiscardedAfter, IItemDiscardedBefore, IItemPlayedAfter, IItemPlayedBefore, IMainStepAfter, IMainStepBefore,
    IMobAttackStepAfter, IMobAttackStepBefore, INewIncidentAfter, INewIncidentBefore, IRoleRevealedAfter,
    IRoleRevealedBefore, IRoleSwappedAfter, IRoleSwappedBefore, ISpellCardActivatedAfter, ISpellCardActivatedBefore,
    ISpellCardCancelledAfter, ISpellCardCancelledBefore, IStackResolvedAfter, IStackResolvedBefore, IStandbyAfter,
    IStandbyBefore, IStartOfTurnAfter, IStartOfTurnBefore, ITurnSkippedAfter, ITurnSkippedBefore, ITurnZeroAfter,
    ITurnZeroBefore { }