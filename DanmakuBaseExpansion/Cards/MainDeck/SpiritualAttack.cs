using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SpiritualAttack : SingleModeMainCard, IInvocationMainMode {
        public SpiritualAttack(int id, ISeason season) : base(id,
            "SpiritualAttack",
            season,
            3,
            new InvocationSpiritualAttack()) { }
    }
}