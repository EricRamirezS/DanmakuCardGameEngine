using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Events;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Player;
using DanmakuRunSample.Players;
using DanmakuExpansion = DanmakuBaseExpansion.ExpansionData;

namespace DanmakuRunSample {
    internal static class Program {
        public static async Task Main() {
            IGameCore gameCore = GameCore.NewInstance(
                new List<IPlayer> {
                    new ConsolePlayer("Player"),
                    new RandomBotPlayer("CPU 1"),
                    new RandomBotPlayer("CPU 2"),
                    new RandomBotPlayer("CPU 3"),
                },
                new IExpansionData[] { new DanmakuExpansion() }
            );
            Test test = new Test();

            gameCore.EventManager.OnGameState.After += test.OnGameStateAfter;
            await gameCore.Init();
            await gameCore.StartGame();

            Console.WriteLine(gameCore.GameState);
        }
    }

    internal class Test : IGameStateEventAfter {
        public void OnGameStateAfter(GameStateEventArgs args) {
            Console.WriteLine(args.GameState);
        }
    }

}