using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDanmakuPlayedBefore: IBaseEvent<DanmakuPlayedBeforeEventArgs> { void OnDanmakuPlayedBefore(object? sender, DanmakuPlayedBeforeEventArgs args); void IBaseEvent<DanmakuPlayedBeforeEventArgs>.HandleEvent(object? sender, DanmakuPlayedBeforeEventArgs args) { OnDanmakuPlayedBefore(sender, args); } }