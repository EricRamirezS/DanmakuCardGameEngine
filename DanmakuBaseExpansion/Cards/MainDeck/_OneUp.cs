using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class OneUp : BaseMainCard, IActionMainMode, IReactionAltMode {
        private IActionMainMode _actionMainModeImplementation = new ActionOneUp();
        private IReactionAltMode _reactionAltModeImplementation = new ReactionOneUp();

        public OneUp(int id, ISeason season) : base(
            id,
            "1UP",
            season,
            2) { }

        public override CardMode CardMode => CardMode.Double;

        public override bool CanPlayMainMode() {
            return _actionMainModeImplementation.CanPlayMainMode();
        }

        public override bool CanPlayAltMode() {
            return _reactionAltModeImplementation.CanPlayAltMode();
        }

        public IList<ICardSubtypes> MainCardTypes => _actionMainModeImplementation.MainCardTypes;

        public void PlayMainMode() {
            _actionMainModeImplementation.PlayMainMode();
        }

        public IList<ICardSubtypes> AltCardTypes => _reactionAltModeImplementation.AltCardTypes;

        public void PlayAltMode() {
            _reactionAltModeImplementation.PlayAltMode();
        }
    }
}