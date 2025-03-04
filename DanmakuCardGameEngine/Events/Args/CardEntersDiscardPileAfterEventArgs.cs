using DanmakuCG_Data.Models.Cards;

namespace DanmakuCG_Data.Models.Events.Args;

public class CardEntersDiscardPileAfterEventArgs : BaseEventArgs {
    public List<Card> NewCards;
}