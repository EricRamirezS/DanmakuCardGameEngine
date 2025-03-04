using DanmakuCardGameEngine.Exceptions;

namespace DanmakuCardGameEngine {
    public class GameCore : IGameCore {
        private GameCore() { }

        private static GameCore _instance;

        public IGameCore Instance {
            get {
                if (_instance == null) {
                    throw new GameNotSetException();
                }

                return _instance;
            }
        }

        public static IGameCore NewInstance() {
            _instance = new GameCore();
            return _instance;
        }
    }

    public interface IGameCore { }
}