using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Player;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Events.Args {
    public class ItemPlayedBeforeEventArgs : ItemPlayedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
        public IItemCard itemCard;
        public IReadOnlyPlayer Player;
        public IHand HandSource;
        public IItemField ItemFieldSource;
    }
}