namespace DanmakuCardGameEngine.Game {
    public sealed class DefaultData : IDefaultData {
        public int DanmakuLimit { get; } = 1;
        public int MaxLife { get; } = 4;
        public int MaxHandSize { get; } = 4;
        public int Range { get; } = 1;
        public int Distance { get; } = 1;
        public int CardDraw { get; } = 2;

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