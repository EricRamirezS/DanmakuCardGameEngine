using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDefeatBefore: IBaseEvent<DefeatBeforeEventArgs> { void OnDefeatBefore(object? sender, DefeatBeforeEventArgs args); void IBaseEvent<DefeatBeforeEventArgs>.HandleEvent(object? sender, DefeatBeforeEventArgs args) { OnDefeatBefore(sender, args); } }