using System.Linq;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class HongMeiling : BaseCharacterCard {
        public HongMeiling() : base(6, "Hong Meiling", Seasons.Summer) { }
        public override ISpellCardTiming SpellCardTiming => SpellCardTimings.Reaction;

        public override IModifiers Modifiers => new Modifiers {
            new MeilingModifierData(this),
        };
    }

    internal class MeilingModifierData : ModifierData {
        public MeilingModifierData(HongMeiling source) : base(ModifierNames.MaxHand, source, 3, Durations.Active) { }

        public override bool IsValid() {
            IGameCore core = GameCore.Instance;

            if (core.CurrentPhase == States.TurnZero || core.CurrentPhase == States.DealInitialHand) return false;
            IEquatablePlayer owner = core.Players.FirstOrDefault(e =>
                e.HasCharacter((HongMeiling)Source));
            return owner != null && !owner.Equals(core.PlayerInTurn);
        }
    }
}