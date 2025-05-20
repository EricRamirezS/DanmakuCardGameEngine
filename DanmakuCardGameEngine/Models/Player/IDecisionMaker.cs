using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Game;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IDecisionMaker {
        Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);
    }
}