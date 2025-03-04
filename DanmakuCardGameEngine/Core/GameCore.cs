using System.Collections.Generic;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Core {
    public partial class GameCore : IGameCore {
        private static GameCore _instance;

        public static IGameCore Instance {
            get {
                if (_instance == null) {
                    throw new GameNotSetException();
                }

                return _instance;
            }
        }

        public static IGameCore NewInstance(IList<IPlayer> players, IExpansionData[] expansions,
            IDefaultData defaultData = null) {
            _instance = new GameCore(players, expansions, defaultData?? new DefaultData());
            _instance.Init();
            return _instance;
        }
    }

    public interface IGameCore {
        IReadOnlyGameState GameState { get; }
    }
}