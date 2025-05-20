using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IItemField : IList<IItemCard>, IReadOnlyList<IItemCard> {
        IReadOnlyPlayer Owner { get; }
    }

}