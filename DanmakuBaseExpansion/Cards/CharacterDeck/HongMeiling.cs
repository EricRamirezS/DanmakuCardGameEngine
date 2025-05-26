using System.Collections.Generic;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Events;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class HongMeiling : BaseCharacterCard, IStartOfTurnEventAfter {
        public HongMeiling() : base(6, "Hong Meiling", Seasons.Summer) { }
        public override ISpellCardTiming SpellCardTiming => SpellCardTimings.Reaction;

        public override IModifiers Modifiers => new Modifiers {
            new MeilingModifierData(this),
        };

        private bool TurnSkipped { get; set; }

        public async void OnStartOfTurnAfter(StartOfTurnEventArgs args) {
            if (!AbilityAvailable) return;
            if (!EquatablePlayer.AreEquals(Owner, args.GameState.PlayerInTurn)) return;

            if (TurnSkipped == false) {
                string skipText = "Skip this turn";
                bool skip = await Owner.ChooseAsync(new List<string> {
                    skipText,
                    "Don't Skip",
                }, args.GameState) == skipText;
                if (!skip) return;
                
                TurnSkipped = true;
                await Owner.DrawCards<IMainCard>(4);
                GameCore.Instance.CurrentPhase = States.EndOfTurn;
            }
            else {
                TurnSkipped = false;
            }
        }

        public override void Subscribe(IEventManager eventManager) {
            eventManager.OnStartOfTurn.After += OnStartOfTurnAfter;
        }
        public override void Unsubscribe(IEventManager eventManager) {
            eventManager.OnStartOfTurn.After -= OnStartOfTurnAfter;
        }
    }

    internal class MeilingModifierData : ModifierData {
        private new HongMeiling Source => (HongMeiling)base.Source;

        public MeilingModifierData(HongMeiling source) : base(ModifierNames.MaxHand, source, 3, Durations.Active) { }

        public override bool IsValid() {
            IGameCore core = GameCore.Instance;

            if (core.CurrentPhase == States.TurnZero || core.CurrentPhase == States.DealInitialHand) return false;
            return Source.Owner != null && !Source.Owner.Equals(core.PlayerInTurn);
        }
    }
}