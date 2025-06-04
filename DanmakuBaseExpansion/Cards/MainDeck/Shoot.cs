using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Shoot : DoubleModeBaseMainCard {
        public Shoot(int id, ISeason season) : base(id,
            "Shoot",
            season,
            1,
            new ActionShootInRange(),
            new ActionShootOutOfRange()) { }
    }
}