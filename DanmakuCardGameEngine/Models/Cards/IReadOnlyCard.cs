using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface IReadOnlyCard: IEquatable<ICard> {
        ICardType CardType { get; }
    }
}