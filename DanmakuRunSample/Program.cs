using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Events;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Player;
using DanmakuRunSample.Players;
using DanmakuExpansion = DanmakuBaseExpansion.ExpansionData;

namespace DanmakuRunSample {
    internal static class Program {
        public static void Main() {
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

            gameCore.EventManager.OnGameState.Before += test.OnGameStateBefore;
            gameCore.EventManager.OnGameState.After += test.OnGameStateAfter;
            gameCore.Init();

            Console.WriteLine(gameCore.GameState);
        }
    }

    internal class Test : IGameStateEvent {

        public void OnGameStateBefore(GameStateEventArgs args, out bool bubbleevent) {
            Console.WriteLine(args.GameState.State?.Name);
            bubbleevent = true;
        }
        
        public void OnGameStateAfter(GameStateEventArgs args) {
            Console.WriteLine(args.GameState.State.Name + " end");
        }
    }

}