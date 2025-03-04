using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDanmakuPlayedAfter: IBaseEvent<DanmakuPlayedAfterEventArgs> { void OnDanmakuPlayedAfter(object? sender, DanmakuPlayedAfterEventArgs args); void IBaseEvent<DanmakuPlayedAfterEventArgs>.HandleEvent(object? sender, DanmakuPlayedAfterEventArgs args) { OnDanmakuPlayedAfter(sender, args); } }