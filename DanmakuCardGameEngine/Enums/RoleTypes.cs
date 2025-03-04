using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class RoleTypes {
        public static readonly IRoleType Heroine = new RoleType("Heroine");
        public static readonly IRoleType StageBoss = new RoleType("Stage Boss");
        public static readonly IRoleType Partner = new RoleType("Partner");
        public static readonly IRoleType ExtraBoss = new RoleType("Extra Boss");
    }
}