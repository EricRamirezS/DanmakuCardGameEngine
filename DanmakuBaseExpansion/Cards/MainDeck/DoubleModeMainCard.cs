using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class DoubleModeMainCard : SingleModeMainCard {
        private IAltMode _altMode;

        public DoubleModeMainCard(int id, string name, ISeason season, int pointValue,
            IMainMode mainMode, IAltMode altMode) : base(id, name, season, pointValue, mainMode) {
            _altMode = altMode;
        }

        public override CardMode CardMode => CardMode.Double;
        public override bool CanPlayAltMode() => _altMode.CanPlayAltMode();
        public override IReadOnlyList<ICardSubtypes> AltCardTypes => _altMode.AltCardTypes;
        public override void PlayAltMode() => _altMode.PlayAltMode();
    }
}