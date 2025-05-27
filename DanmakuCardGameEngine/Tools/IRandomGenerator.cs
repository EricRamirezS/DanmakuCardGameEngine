using System;

namespace DanmakuCardGameEngine.Tools {
    /// <summary>
    /// Defines an interface for a random number generator, providing a contract for generating random integers.
    /// This abstraction allows for different implementations of random number generation to be used interchangeably.
    /// </summary>
    public interface IRandomGenerator {
        /// <summary>
        /// Generates a non-negative random integer that is less than the specified maximum value.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated.
        /// <paramref name="maxValue"/> must be greater than or equal to 0.</param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>.</returns>
        int Next(int maxValue);
    }

    /// <summary>
    /// Provides a concrete implementation of a random number generator using the <see cref="System.Random"/> class.
    /// This class implements the <see cref="IRandomGenerator"/> interface, allowing it to be used
    /// where a random number generator is required.
    /// </summary>
    public class RandomGenerator : IRandomGenerator {
        private readonly Random _rng;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class using a default, time-dependent seed.
        /// </summary>
        public RandomGenerator() : this(new Random()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class with a specified <see cref="System.Random"/> instance.
        /// This constructor is internal, promoting controlled instantiation of random generators within the assembly.
        /// </summary>
        /// <param name="rng">The <see cref="System.Random"/> instance to use for generating random numbers.</param>
        internal RandomGenerator(Random rng) {
            _rng = rng;
        }

        /// <summary>
        /// Generates a non-negative random integer that is less than the specified maximum value.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated.
        /// <paramref name="maxValue"/> must be greater than or equal to 0.</param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>.</returns>
        public int Next(int maxValue) {
            return _rng.Next(maxValue);
        }
    }
}