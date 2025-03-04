using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IRoleSwappedBefore: IBaseEvent<RoleSwappedBeforeEventArgs> { void OnRoleSwappedBefore(object? sender, RoleSwappedBeforeEventArgs args); void IBaseEvent<RoleSwappedBeforeEventArgs>.HandleEvent(object? sender, RoleSwappedBeforeEventArgs args) { OnRoleSwappedBefore(sender, args); } }