using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDeckShuffledAfter: IBaseEvent<DeckShuffledAfterEventArgs> { void OnDeckShuffledAfter(object? sender, DeckShuffledAfterEventArgs args); void IBaseEvent<DeckShuffledAfterEventArgs>.HandleEvent(object? sender, DeckShuffledAfterEventArgs args) { OnDeckShuffledAfter(sender, args); } }