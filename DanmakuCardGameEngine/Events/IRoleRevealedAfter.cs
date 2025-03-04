using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IRoleRevealedAfter: IBaseEvent<RoleRevealedAfterEventArgs> { void OnRoleRevealedAfter(object? sender, RoleRevealedAfterEventArgs args); void IBaseEvent<RoleRevealedAfterEventArgs>.HandleEvent(object? sender, RoleRevealedAfterEventArgs args) { OnRoleRevealedAfter(sender, args); } }