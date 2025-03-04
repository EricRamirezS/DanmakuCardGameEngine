using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events {
    public interface IBaseEvent<in T> where T: BaseEventArgs {
        void HandleEvent(object sender, T args);
    }
}