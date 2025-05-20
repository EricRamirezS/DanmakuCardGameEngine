using System;

namespace DanmakuCardGameEngine.Tools {
    public interface IRandomGenerator {
        int Next(int maxValue);
    }

    public class RandomGenerator : IRandomGenerator {
        private readonly Random _rng;

        public RandomGenerator() : this(new Random()) { }

        private RandomGenerator(Random rng) {
            _rng = rng;
        }

        public int Next(int maxValue) {
            return _rng.Next(maxValue);
        }
    }
}