using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IRoleSwappedAfter: IBaseEvent<RoleSwappedAfterEventArgs> { void OnRoleSwappedAfter(object? sender, RoleSwappedAfterEventArgs args); void IBaseEvent<RoleSwappedAfterEventArgs>.HandleEvent(object? sender, RoleSwappedAfterEventArgs args) { OnRoleSwappedAfter(sender, args); } }