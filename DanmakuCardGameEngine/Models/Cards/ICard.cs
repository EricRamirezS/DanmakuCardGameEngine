using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface ICard : IEquatable<ICard>, IReadOnlyConverter<IReadOnlyCard> {
        int Id { get; }
        string Name { get; }
        ISeason Season { get; }
        IExpansion Expansion { get; }
        ICardType CardType { get; }
        IModifiers Modifiers { get; }
    }
}