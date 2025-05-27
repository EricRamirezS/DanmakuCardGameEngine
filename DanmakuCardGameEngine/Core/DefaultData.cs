namespace DanmakuCardGameEngine.Core {
    public sealed class DefaultData : IDefaultData {
        public byte DanmakuLimit => 1;
        public byte MaxLife => 4;
        public byte MaxHandSize => 4;
        public byte Range => 1;
        public byte Distance => 1;
        public byte CardDraw => 2;

        internal DefaultData() { }
    }

    public interface IDefaultData {
        byte DanmakuLimit { get; }
        byte MaxLife { get; }
        byte MaxHandSize { get; }
        byte Range { get; }
        byte Distance { get; }
        byte CardDraw { get; }
    }
}