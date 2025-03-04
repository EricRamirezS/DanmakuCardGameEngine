using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Models.Player;
using DanmakuRunSample.Players;
using DanmakuExpansion = DanmakuBaseExpansion.ExpansionData;

namespace DanmakuRunSample {
    internal static class Program {
        public static void Main(string[] args) {
            IGameCore gameCore = GameCore.NewInstance(
                new List<IPlayer>() {
                    new ConsolePlayer("Player"),
                    new RandomBotPlayer("CPU 1"),
                    new RandomBotPlayer("CPU 2"),
                    new RandomBotPlayer("CPU 3")
                },
                new IExpansionData[] { new DanmakuExpansion() }
            );

            foreach (IReadOnlyPlayer player in gameCore.GameState.Players) {
                Console.WriteLine($"{player}");
            }
        }
    }
}