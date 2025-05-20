using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public class ItemField : List<IItemCard>, IItemField {
        public ItemField(IPlayer owner) {
            _owner = owner;
        }

        private readonly IPlayer _owner;
        public IReadOnlyPlayer Owner => _owner.ToReadOnly();
    }
}