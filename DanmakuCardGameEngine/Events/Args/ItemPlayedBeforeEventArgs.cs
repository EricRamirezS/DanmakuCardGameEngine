using DanmakuCG_Data.Game;
using DanmakuCG_Data.Game.ReadOnlyModels;
using DanmakuCG_Data.Models.Cards;
using DanmakuCG_Data.Models.PlayerController.PlayerComponents;

namespace DanmakuCG_Data.Models.Events.Args;

public class ItemPlayedBeforeEventArgs : ItemPlayedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
    public HandCard ItemCard;
    public ReadOnlyPlayer Player;
    public Hand? HandSource;
    public CardList? ListSource;
    public ItemField? ItemFieldSource;
}