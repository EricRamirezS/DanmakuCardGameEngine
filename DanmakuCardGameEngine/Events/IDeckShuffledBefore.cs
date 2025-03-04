using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDeckShuffledBefore: IBaseEvent<DeckShuffledBeforeEventArgs> { void OnDeckShuffledBefore(object? sender, DeckShuffledBeforeEventArgs args); void IBaseEvent<DeckShuffledBeforeEventArgs>.HandleEvent(object? sender, DeckShuffledBeforeEventArgs args) { OnDeckShuffledBefore(sender, args); } }