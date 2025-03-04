using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDefeatAfter: IBaseEvent<DefeatAfterEventArgs> { void OnDefeatAfter(object? sender, DefeatAfterEventArgs args); void IBaseEvent<DefeatAfterEventArgs>.HandleEvent(object? sender, DefeatAfterEventArgs args) { OnDefeatAfter(sender, args); } }