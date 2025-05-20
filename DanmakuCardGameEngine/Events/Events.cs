using System;
using System.Collections.Generic;
using System.Reflection;
using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events {
    public delegate void BubblingEventHandler<in TArgs>(TArgs args, out bool bubbleEvent);

    public delegate void SimpleEventHandler<in TArgs>(TArgs args);

    public class BubblingEvent<TArgs> {

        private event BubblingEventHandler<TArgs> BeforeHandlers;
        private event SimpleEventHandler<TArgs> AfterHandlers;

        private readonly Dictionary<object, (Delegate before, Delegate after)> _listenerDelegates =
            new Dictionary<object, (Delegate before, Delegate after)>();

        public void Invoke(TArgs args, Action execution) {
            bool continueBubbling = true;

            if (BeforeHandlers != null) {
                foreach (Delegate handler in BeforeHandlers.GetInvocationList()) {
                    ((BubblingEventHandler<TArgs>)handler).Invoke(args, out bool bubble);

                    if (bubble) continue;
                    continueBubbling = false;
                    break;
                }
            }

            if (!continueBubbling || AfterHandlers == null) return;

            execution?.Invoke();

            foreach (Delegate handler in AfterHandlers.GetInvocationList()) {
                ((SimpleEventHandler<TArgs>)handler).Invoke(args);
            }

        }

        // Subscribir a eventos BEFORE usando +=
        public event BubblingEventHandler<TArgs> Before
        {
            add => BeforeHandlers += value;
            remove => BeforeHandlers -= value;
        }

        // Subscribir a eventos AFTER usando +=
        public event SimpleEventHandler<TArgs> After
        {
            add => AfterHandlers += value;
            remove => AfterHandlers -= value;
        }

        public static BubblingEvent<TArgs> operator +(BubblingEvent<TArgs> ev, object listener) {
            ev.SubscribeByConvention(listener);
            return ev;
        }

        public static BubblingEvent<TArgs> operator -(BubblingEvent<TArgs> ev, object listener) {
            ev.UnsubscribeByConvention(listener);
            return ev;
        }

        private void SubscribeByConvention(object listener) {
            string eventName = typeof(TArgs).Name.Replace("EventArgs", ""); // eg. Attack
            string beforeInterface = $"I{eventName}EventBefore";
            string afterInterface = $"I{eventName}EventAfter";
            string beforeMethod = $"On{eventName}Before";
            string afterMethod = $"On{eventName}After";

            Delegate beforeDelegate = null;
            Delegate afterDelegate = null;

            foreach (Type iface in listener.GetType().GetInterfaces()) {
                if (iface.Name == beforeInterface) {
                    MethodInfo method = iface.GetMethod(beforeMethod);
                    if (method != null) {
                        BubblingEventHandler<TArgs> del = (TArgs args, out bool bubble) =>
                        {
                            object[] parameters = { args, true };
                            method.Invoke(listener, parameters);
                            bubble = (bool)parameters[1];
                        };
                        BeforeHandlers += del;
                        beforeDelegate = del;
                    }
                }

                if (iface.Name != afterInterface) continue;
                {
                    MethodInfo method = iface.GetMethod(afterMethod);
                    if (method == null) continue;
                    SimpleEventHandler<TArgs> del = args => { method.Invoke(listener, new object[] { args }); };
                    AfterHandlers += del;
                    afterDelegate = del;
                }
            }

            if (beforeDelegate != null || afterDelegate != null) {
                _listenerDelegates[listener] = (beforeDelegate, afterDelegate);
            }
        }

        private void UnsubscribeByConvention(object listener) {
            if (!_listenerDelegates.TryGetValue(listener, out (Delegate before, Delegate after) delegates))
                return;

            if (delegates.before != null)
                BeforeHandlers -= (BubblingEventHandler<TArgs>)delegates.before;

            if (delegates.after != null)
                AfterHandlers -= (SimpleEventHandler<TArgs>)delegates.after;

            _listenerDelegates.Remove(listener);
        }
    }

    public class AbilityActivatedEvent : BubblingEvent<AbilityActivatedEventArgs> { }

    public class AttackEvent : BubblingEvent<AttackEventArgs> { }

    public class CancelEvent : BubblingEvent<CancelEventArgs> { }

    public class CardEntersDiscardPileEvent : BubblingEvent<CardEntersDiscardPileEventArgs> { }

    public class CardPlayedEvent : BubblingEvent<CardPlayedEventArgs> { }

    public class CardResolvedEvent : BubblingEvent<CardResolvedEventArgs> { }

    public class CardsCollectedEvent : BubblingEvent<CardsCollectedEventArgs> { }

    public class DanmakuPlayedEvent : BubblingEvent<DanmakuPlayedEventArgs> { }

    public class DeckShuffledEvent : BubblingEvent<DeckShuffledEventArgs> { }

    public class DecreasedHealthEvent : BubblingEvent<DecreasedHealthEventArgs> { }

    public class DefeatEvent : BubblingEvent<DefeatEventArgs> { }

    public class DiscardEvent : BubblingEvent<DiscardEventArgs> { }

    public class DiscardStepEvent : BubblingEvent<DiscardStepEventArgs> { }

    public class DodgeEvent : BubblingEvent<DodgeEventArgs> { }

    public class DrawEvent : BubblingEvent<DrawEventArgs> { }

    public class DrawStepEvent : BubblingEvent<DrawStepEventArgs> { }

    public class EmptyHandEvent : BubblingEvent<EmptyHandEventArgs> { }

    public class EncounterStepEvent : BubblingEvent<EncounterStepEventArgs> { }

    public class EndOfTurnEvent : BubblingEvent<EndOfTurnEventArgs> { }

    public class FlipEvent : BubblingEvent<FlipEventArgs> { }

    public class GameStateEvent : BubblingEvent<GameStateEventArgs> { }

    public class HandRevealedEvent : BubblingEvent<HandRevealedEventArgs> { }

    public class HandSwappedEvent : BubblingEvent<HandSwappedEventArgs> { }

    public class IncidentResolvedEvent : BubblingEvent<IncidentResolvedEventArgs> { }

    public class IncidentStepEvent : BubblingEvent<IncidentStepEventArgs> { }

    public class IncreasedHealthEvent : BubblingEvent<IncreasedHealthEventArgs> { }

    public class ItemDiscardedEvent : BubblingEvent<ItemDiscardedEventArgs> { }

    public class ItemPlayedEvent : BubblingEvent<ItemPlayedEventArgs> { }

    public class MainStepEvent : BubblingEvent<MainStepEventArgs> { }

    public class MobAttackStepEvent : BubblingEvent<MobAttackStepEventArgs> { }

    public class NewIncidentEvent : BubblingEvent<NewIncidentEventArgs> { }

    public class RoleRevealedEvent : BubblingEvent<RoleRevealedEventArgs> { }

    public class RoleSwappedEvent : BubblingEvent<RoleSwappedEventArgs> { }
    
    public class RoundChangeEvent : BubblingEvent<RoundChangeEventArgs> { }

    public class SpellCardActivatedEvent : BubblingEvent<SpellCardActivatedEventArgs> { }

    public class SpellCardCancelledEvent : BubblingEvent<SpellCardCancelledEventArgs> { }

    public class StackResolvedEvent : BubblingEvent<StackResolvedEventArgs> { }

    public class StandbyEvent : BubblingEvent<StandbyEventArgs> { }

    public class StartOfTurnEvent : BubblingEvent<StartOfTurnEventArgs> { }
    
    public class TurnChangeEvent : BubblingEvent<TurnChangeEventArgs> { }

    public class TurnSkippedEvent : BubblingEvent<TurnSkippedEventArgs> { }

    public class TurnZeroEvent : BubblingEvent<TurnZeroEventArgs> { }


    public interface IAbilityActivatedEventBefore {
        void OnAbilityActivatedBefore(AbilityActivatedEventArgs args, out bool bubbleevent);
    }

    public interface IAbilityActivatedEventAfter {
        void OnAbilityActivatedAfter(AbilityActivatedEventArgs args);
    }

    public interface IAbilityActivatedEvent : IAbilityActivatedEventBefore, IAbilityActivatedEventAfter { }

    public interface IAttackEventBefore {
        void OnAttackBefore(AttackEventArgs args, out bool bubbleevent);
    }

    public interface IAttackEventAfter {
        void OnAttackAfter(AttackEventArgs args);
    }

    public interface IAttackEvent : IAttackEventBefore, IAttackEventAfter { }

    public interface ICancelEventBefore {
        void OnCancelBefore(CancelEventArgs args, out bool bubbleevent);
    }

    public interface ICancelEventAfter {
        void OnCancelAfter(CancelEventArgs args);
    }

    public interface ICancelEvent : ICancelEventBefore, ICancelEventAfter { }

    public interface ICardEntersDiscardPileEventBefore {
        void OnCardEntersDiscardPileBefore(CardEntersDiscardPileEventArgs args, out bool bubbleevent);
    }

    public interface ICardEntersDiscardPileEventAfter {
        void OnCardEntersDiscardPileAfter(CardEntersDiscardPileEventArgs args);
    }

    public interface ICardEntersDiscardPileEvent : ICardEntersDiscardPileEventBefore, ICardEntersDiscardPileEventAfter { }

    public interface ICardPlayedEventBefore {
        void OnCardPlayedBefore(CardPlayedEventArgs args, out bool bubbleevent);
    }

    public interface ICardPlayedEventAfter {
        void OnCardPlayedAfter(CardPlayedEventArgs args);
    }

    public interface ICardPlayedEvent : ICardPlayedEventBefore, ICardPlayedEventAfter { }

    public interface ICardResolvedEventBefore {
        void OnCardResolvedBefore(CardResolvedEventArgs args, out bool bubbleevent);
    }

    public interface ICardResolvedEventAfter {
        void OnCardResolvedAfter(CardResolvedEventArgs args);
    }

    public interface ICardResolvedEvent : ICardResolvedEventBefore, ICardResolvedEventAfter { }

    public interface ICardsCollectedEventBefore {
        void OnCardsCollectedBefore(CardsCollectedEventArgs args, out bool bubbleevent);
    }

    public interface ICardsCollectedEventAfter {
        void OnCardsCollectedAfter(CardsCollectedEventArgs args);
    }

    public interface ICardsCollectedEvent : ICardsCollectedEventBefore, ICardsCollectedEventAfter { }

    public interface IDanmakuPlayedEventBefore {
        void OnDanmakuPlayedBefore(DanmakuPlayedEventArgs args, out bool bubbleevent);
    }

    public interface IDanmakuPlayedEventAfter {
        void OnDanmakuPlayedAfter(DanmakuPlayedEventArgs args);
    }

    public interface IDanmakuPlayedEvent : IDanmakuPlayedEventBefore, IDanmakuPlayedEventAfter { }

    public interface IDeckShuffledEventBefore {
        void OnDeckShuffledBefore(DeckShuffledEventArgs args, out bool bubbleevent);
    }

    public interface IDeckShuffledEventAfter {
        void OnDeckShuffledAfter(DeckShuffledEventArgs args);
    }

    public interface IDeckShuffledEvent : IDeckShuffledEventBefore, IDeckShuffledEventAfter { }

    public interface IDecreasedHealthEventBefore {
        void OnDecreasedHealthBefore(DecreasedHealthEventArgs args, out bool bubbleevent);
    }

    public interface IDecreasedHealthEventAfter {
        void OnDecreasedHealthAfter(DecreasedHealthEventArgs args);
    }

    public interface IDecreasedHealthEvent : IDecreasedHealthEventBefore, IDecreasedHealthEventAfter { }

    public interface IDefeatEventBefore {
        void OnDefeatBefore(DefeatEventArgs args, out bool bubbleevent);
    }

    public interface IDefeatEventAfter {
        void OnDefeatAfter(DefeatEventArgs args);
    }

    public interface IDefeatEvent : IDefeatEventBefore, IDefeatEventAfter { }

    public interface IDiscardEventBefore {
        void OnDiscardBefore(DiscardEventArgs args, out bool bubbleevent);
    }

    public interface IDiscardEventAfter {
        void OnDiscardAfter(DiscardEventArgs args);
    }

    public interface IDiscardEvent : IDiscardEventBefore, IDiscardEventAfter { }

    public interface IDiscardStepEventBefore {
        void OnDiscardStepBefore(DiscardStepEventArgs args, out bool bubbleevent);
    }

    public interface IDiscardStepEventAfter {
        void OnDiscardStepAfter(DiscardStepEventArgs args);
    }

    public interface IDiscardStepEvent : IDiscardStepEventBefore, IDiscardStepEventAfter { }

    public interface IDodgeEventBefore {
        void OnDodgeBefore(DodgeEventArgs args, out bool bubbleevent);
    }

    public interface IDodgeEventAfter {
        void OnDodgeAfter(DodgeEventArgs args);
    }

    public interface IDodgeEvent : IDodgeEventBefore, IDodgeEventAfter { }

    public interface IDrawEventBefore {
        void OnDrawBefore(DrawEventArgs args, out bool bubbleevent);
    }

    public interface IDrawEventAfter {
        void OnDrawAfter(DrawEventArgs args);
    }

    public interface IDrawEvent : IDrawEventBefore, IDrawEventAfter { }

    public interface IDrawStepEventBefore {
        void OnDrawStepBefore(DrawStepEventArgs args, out bool bubbleevent);
    }

    public interface IDrawStepEventAfter {
        void OnDrawStepAfter(DrawStepEventArgs args);
    }

    public interface IDrawStepEvent : IDrawStepEventBefore, IDrawStepEventAfter { }

    public interface IEmptyHandEventBefore {
        void OnEmptyHandBefore(EmptyHandEventArgs args, out bool bubbleevent);
    }

    public interface IEmptyHandEventAfter {
        void OnEmptyHandAfter(EmptyHandEventArgs args);
    }

    public interface IEmptyHandEvent : IEmptyHandEventBefore, IEmptyHandEventAfter { }

    public interface IEncounterStepEventBefore {
        void OnEncounterStepBefore(EncounterStepEventArgs args, out bool bubbleevent);
    }

    public interface IEncounterStepEventAfter {
        void OnEncounterStepAfter(EncounterStepEventArgs args);
    }

    public interface IEncounterStepEvent : IEncounterStepEventBefore, IEncounterStepEventAfter { }

    public interface IEndOfTurnEventBefore {
        void OnEndOfTurnBefore(EndOfTurnEventArgs args, out bool bubbleevent);
    }

    public interface IEndOfTurnEventAfter {
        void OnEndOfTurnAfter(EndOfTurnEventArgs args);
    }

    public interface IEndOfTurnEvent : IEndOfTurnEventBefore, IEndOfTurnEventAfter { }

    public interface IFlipEventBefore {
        void OnFlipBefore(FlipEventArgs args, out bool bubbleevent);
    }

    public interface IFlipEventAfter {
        void OnFlipAfter(FlipEventArgs args);
    }

    public interface IFlipEvent : IFlipEventBefore, IFlipEventAfter { }

    public interface IGameStateEventBefore {
        void OnGameStateBefore(GameStateEventArgs args, out bool bubbleevent);
    }

    public interface IGameStateEventAfter {
        void OnGameStateAfter(GameStateEventArgs args);
    }

    public interface IGameStateEvent : IGameStateEventBefore, IGameStateEventAfter { }

    public interface IHandRevealedEventBefore {
        void OnHandRevealedBefore(HandRevealedEventArgs args, out bool bubbleevent);
    }

    public interface IHandRevealedEventAfter {
        void OnHandRevealedAfter(HandRevealedEventArgs args);
    }

    public interface IHandRevealedEvent : IHandRevealedEventBefore, IHandRevealedEventAfter { }

    public interface IHandSwappedEventBefore {
        void OnHandSwappedBefore(HandSwappedEventArgs args, out bool bubbleevent);
    }

    public interface IHandSwappedEventAfter {
        void OnHandSwappedAfter(HandSwappedEventArgs args);
    }

    public interface IHandSwappedEvent : IHandSwappedEventBefore, IHandSwappedEventAfter { }

    public interface IIncidentResolvedEventBefore {
        void OnIncidentResolvedBefore(IncidentResolvedEventArgs args, out bool bubbleevent);
    }

    public interface IIncidentResolvedEventAfter {
        void OnIncidentResolvedAfter(IncidentResolvedEventArgs args);
    }

    public interface IIncidentResolvedEvent : IIncidentResolvedEventBefore, IIncidentResolvedEventAfter { }

    public interface IIncidentStepEventBefore {
        void OnIncidentStepBefore(IncidentStepEventArgs args, out bool bubbleevent);
    }

    public interface IIncidentStepEventAfter {
        void OnIncidentStepAfter(IncidentStepEventArgs args);
    }

    public interface IIncidentStepEvent : IIncidentStepEventBefore, IIncidentStepEventAfter { }

    public interface IIncreasedHealthEventBefore {
        void OnIncreasedHealthBefore(IncreasedHealthEventArgs args, out bool bubbleevent);
    }

    public interface IIncreasedHealthEventAfter {
        void OnIncreasedHealthAfter(IncreasedHealthEventArgs args);
    }

    public interface IIncreasedHealthEvent : IIncreasedHealthEventBefore, IIncreasedHealthEventAfter { }

    public interface IItemDiscardedEventBefore {
        void OnItemDiscardedBefore(ItemDiscardedEventArgs args, out bool bubbleevent);
    }

    public interface IItemDiscardedEventAfter {
        void OnItemDiscardedAfter(ItemDiscardedEventArgs args);
    }

    public interface IItemDiscardedEvent : IItemDiscardedEventBefore, IItemDiscardedEventAfter { }

    public interface IItemPlayedEventBefore {
        void OnItemPlayedBefore(ItemPlayedEventArgs args, out bool bubbleevent);
    }

    public interface IItemPlayedEventAfter {
        void OnItemPlayedAfter(ItemPlayedEventArgs args);
    }

    public interface IItemPlayedEvent : IItemPlayedEventBefore, IItemPlayedEventAfter { }

    public interface IMainStepEventBefore {
        void OnMainStepBefore(MainStepEventArgs args, out bool bubbleevent);
    }

    public interface IMainStepEventAfter {
        void OnMainStepAfter(MainStepEventArgs args);
    }

    public interface IMainStepEvent : IMainStepEventBefore, IMainStepEventAfter { }

    public interface IMobAttackStepEventBefore {
        void OnMobAttackStepBefore(MobAttackStepEventArgs args, out bool bubbleevent);
    }

    public interface IMobAttackStepEventAfter {
        void OnMobAttackStepAfter(MobAttackStepEventArgs args);
    }

    public interface IMobAttackStepEvent : IMobAttackStepEventBefore, IMobAttackStepEventAfter { }

    public interface INewIncidentEventBefore {
        void OnNewIncidentBefore(NewIncidentEventArgs args, out bool bubbleevent);
    }

    public interface INewIncidentEventAfter {
        void OnNewIncidentAfter(NewIncidentEventArgs args);
    }

    public interface INewIncidentEvent : INewIncidentEventBefore, INewIncidentEventAfter { }

    public interface IRoleRevealedEventBefore {
        void OnRoleRevealedBefore(RoleRevealedEventArgs args, out bool bubbleevent);
    }

    public interface IRoleRevealedEventAfter {
        void OnRoleRevealedAfter(RoleRevealedEventArgs args);
    }

    public interface IRoleRevealedEvent : IRoleRevealedEventBefore, IRoleRevealedEventAfter { }

    public interface IRoleSwappedEventBefore {
        void OnRoleSwappedBefore(RoleSwappedEventArgs args, out bool bubbleevent);
    }

    public interface IRoleSwappedEventAfter {
        void OnRoleSwappedAfter(RoleSwappedEventArgs args);
    }

    public interface IRoleSwappedEvent : IRoleSwappedEventBefore, IRoleSwappedEventAfter { }

    public interface ISpellCardActivatedEventBefore {
        void OnSpellCardActivatedBefore(SpellCardActivatedEventArgs args, out bool bubbleevent);
    }

    public interface ISpellCardActivatedEventAfter {
        void OnSpellCardActivatedAfter(SpellCardActivatedEventArgs args);
    }

    public interface ISpellCardActivatedEvent : ISpellCardActivatedEventBefore, ISpellCardActivatedEventAfter { }

    public interface ISpellCardCancelledEventBefore {
        void OnSpellCardCancelledBefore(SpellCardCancelledEventArgs args, out bool bubbleevent);
    }

    public interface ISpellCardCancelledEventAfter {
        void OnSpellCardCancelledAfter(SpellCardCancelledEventArgs args);
    }

    public interface ISpellCardCancelledEvent : ISpellCardCancelledEventBefore, ISpellCardCancelledEventAfter { }

    public interface IStackResolvedEventBefore {
        void OnStackResolvedBefore(StackResolvedEventArgs args, out bool bubbleevent);
    }

    public interface IStackResolvedEventAfter {
        void OnStackResolvedAfter(StackResolvedEventArgs args);
    }

    public interface IStackResolvedEvent : IStackResolvedEventBefore, IStackResolvedEventAfter { }

    public interface IStandbyEventBefore {
        void OnStandbyBefore(StandbyEventArgs args, out bool bubbleevent);
    }

    public interface IStandbyEventAfter {
        void OnStandbyAfter(StandbyEventArgs args);
    }

    public interface IStandbyEvent : IStandbyEventBefore, IStandbyEventAfter { }

    public interface IStartOfTurnEventBefore {
        void OnStartOfTurnBefore(StartOfTurnEventArgs args, out bool bubbleevent);
    }

    public interface IStartOfTurnEventAfter {
        void OnStartOfTurnAfter(StartOfTurnEventArgs args);
    }

    public interface IStartOfTurnEvent : IStartOfTurnEventBefore, IStartOfTurnEventAfter { }

    public interface ITurnSkippedEventBefore {
        void OnTurnSkippedBefore(TurnSkippedEventArgs args, out bool bubbleevent);
    }

    public interface ITurnSkippedEventAfter {
        void OnTurnSkippedAfter(TurnSkippedEventArgs args);
    }

    public interface ITurnSkippedEvent : ITurnSkippedEventBefore, ITurnSkippedEventAfter { }

    public interface ITurnZeroEventBefore {
        void OnTurnZeroBefore(TurnZeroEventArgs args, out bool bubbleevent);
    }

    public interface ITurnZeroEventAfter {
        void OnTurnZeroAfter(TurnZeroEventArgs args);
    }

    public interface ITurnZeroEvent : ITurnZeroEventBefore, ITurnZeroEventAfter { }

}