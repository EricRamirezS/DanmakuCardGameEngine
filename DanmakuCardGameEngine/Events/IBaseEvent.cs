using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IBaseEvent<in T>: IEvent where T: BaseEventArgs {
    void HandleEvent(object? sender, T args);
}