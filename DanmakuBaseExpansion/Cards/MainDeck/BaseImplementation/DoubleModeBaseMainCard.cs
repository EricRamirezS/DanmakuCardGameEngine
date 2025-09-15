using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation {
    public class DoubleModeBaseMainCard : DoubleModeMainCard {
        private IMainTiming _mainTiming;
        private IAltTiming _altTiming;

        public DoubleModeBaseMainCard(int id, string name, ISeason season, int pointValue,
            IMainTiming mainTiming, IAltTiming altTiming) : base(id, name, season, ExpansionData.BaseExpansion, pointValue) {
            _altTiming = altTiming;
        }

        public override bool CanPlayMainMode() => _mainTiming.CanPlayMainMode();
        public override IReadOnlyList<ICardSubtype> MainCardTypes => _mainTiming.MainCardTypes;
        public override void PlayMainMode() => _mainTiming.PlayMainMode();

        public override bool CanPlayAltMode() => _altTiming.CanPlayAltMode();
        public override IReadOnlyList<ICardSubtype> AltCardTypes => _altTiming.AltCardTypes;
        public override void PlayAltMode() => _altTiming.PlayAltMode();
    }
}