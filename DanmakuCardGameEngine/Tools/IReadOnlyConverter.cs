namespace DanmakuCardGameEngine.Tools {
    public interface IReadOnlyConverter<out T> {
        T ToReadOnly();
    }
}