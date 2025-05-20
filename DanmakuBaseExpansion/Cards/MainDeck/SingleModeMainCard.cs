using System.Collections.Generic;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class SingleModeMainCard : BaseMainCard {
        private IMainMode _mainMode;

        public SingleModeMainCard(int id, string name, ISeason season, int pointValue,
            IMainMode mainMode) : base(id, name, season, pointValue) {
            _mainMode = mainMode;
        }


        public override CardMode CardMode => CardMode.Single;
        public override bool CanPlayMainMode() => _mainMode.CanPlayMainMode();
        public override bool CanPlayAltMode() => false;

        public override IReadOnlyList<ICardSubtypes> MainCardTypes => _mainMode.MainCardTypes;
        public override IReadOnlyList<ICardSubtypes> AltCardTypes => new List<ICardSubtypes>();

        public override void PlayMainMode() => _mainMode.PlayMainMode();
        public override void PlayAltMode() { }
    }
}