using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IRoleRevealedBefore: IBaseEvent<RoleRevealedBeforeEventArgs> { void OnRoleRevealedBefore(object? sender, RoleRevealedBeforeEventArgs args); void IBaseEvent<RoleRevealedBeforeEventArgs>.HandleEvent(object? sender, RoleRevealedBeforeEventArgs args) { OnRoleRevealedBefore(sender, args); } }