namespace DanmakuCardGameEngine.Core {
    public sealed class DefaultData : IDefaultData {
        public int DanmakuLimit => 1;
        public int MaxLife => 4;
        public int MaxHandSize => 4;
        public int Range => 1;
        public int Distance => 1;
        public int CardDraw => 2;

        internal DefaultData() { }
    }

    public interface IDefaultData {
        int DanmakuLimit { get; }
        int MaxLife { get; }
        int MaxHandSize { get; }
        int Range { get; }
        int Distance { get; }
        int CardDraw { get; }
    }
}