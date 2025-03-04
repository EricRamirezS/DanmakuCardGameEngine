using DanmakuCG_Data.Game;
using DanmakuCG_Data.Models.Cards;

namespace DanmakuCG_Data.Models.Events.Args;

public class RoleSwappedAfterEventArgs : BaseEventArgs {
    public ReadOnlyPlayer PlayerA;
    public ReadOnlyPlayer PlayerB;
    public RoleCard? OldRoleA;
    public RoleCard? OldRoleB;
    public RoleCard? NewRoleA;
    public RoleCard? NewRoleB;
}