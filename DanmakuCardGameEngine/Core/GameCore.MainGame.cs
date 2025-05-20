using System;
using System.Threading.Tasks;

namespace DanmakuCardGameEngine.Core {
    public partial class GameCore {
        public async Task StartGame() {
            if (!_initialized) {
                throw new Exception("Game not initialized. Call Init() first.");
            }

            while (!GameHasEnded()) {
                await ExecuteTurn();
            }

            await ResolveGameEnd();
        }
        
        private async Task ResolveGameEnd() {
            throw new NotImplementedException();
        }
        
        private async Task ExecuteTurn() {
            throw new NotImplementedException();
        }
        
        private bool GameHasEnded() {
            throw new NotImplementedException();
        }
    }
}