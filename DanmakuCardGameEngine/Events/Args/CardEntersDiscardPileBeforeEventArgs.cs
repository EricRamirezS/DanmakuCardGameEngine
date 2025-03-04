namespace DanmakuCardGameEngine.Events.Args {
    public class CardEntersDiscardPileBeforeEventArgs : CardEntersDiscardPileAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}