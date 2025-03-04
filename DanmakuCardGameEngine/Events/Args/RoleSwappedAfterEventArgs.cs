using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    public class RoleSwappedAfterEventArgs : BaseEventArgs {
        public IReadOnlyPlayer PlayerA;
        public IReadOnlyPlayer PlayerB;
        public IRoleCard OldRoleA;
        public IRoleCard OldRoleB;
        public IRoleCard NewRoleA;
        public IRoleCard NewRoleB;
    }
}