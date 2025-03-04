using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IItemField : IList<IItemCard>, IReadOnlyList<IItemCard> {
        IReadOnlyPlayer Owner { get; }
    }

    public class ItemField : List<IItemCard>, IItemField {
        public ItemField(IReadOnlyPlayer owner) {
            Owner = owner;
        }

        public IReadOnlyPlayer Owner { get; }
    }
}