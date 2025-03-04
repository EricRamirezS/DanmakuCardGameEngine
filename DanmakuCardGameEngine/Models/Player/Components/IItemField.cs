using System.Collections;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IItemField : IList<IHandCard>, IList, IReadOnlyList<IHandCard> {
        IReadOnlyPlayer Owner { get; }
    }
}