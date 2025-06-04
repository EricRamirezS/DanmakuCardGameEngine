using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation {
    public class SingleModeBaseMainCard : SingleModeMainCard{
        private IMainTiming _mainTiming;

        public SingleModeBaseMainCard(int id, string name, ISeason season, int pointValue,
            IMainTiming mainTiming) : base(id, name, season, ExpansionData.BaseExpansion, pointValue) {
            _mainTiming = mainTiming;
        }


        public override bool CanPlayMainMode() => _mainTiming.CanPlayMainMode();

        public override IReadOnlyList<ICardSubtypes> MainCardTypes => _mainTiming.MainCardTypes;

        public override void PlayMainMode() => _mainTiming.PlayMainMode();
    }
}