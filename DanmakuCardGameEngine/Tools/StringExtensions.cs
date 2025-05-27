namespace DanmakuCardGameEngine.Tools {
    /// <summary>
    /// Provides extension methods for string manipulation.
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// Pads the current string with spaces on both sides to center it within a specified total length.
        /// If the string's length is greater than or equal to the specified total length, no padding is applied.
        /// </summary>
        /// <param name="str">The string to center.</param>
        /// <param name="length">The total length of the padded string.</param>
        /// <returns>A new string that is padded with spaces to achieve the desired centering.</returns>
        public static string PadCenter(this string str, int length) {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }

        /// <summary>
        /// Pads the current string with a specified padding character on both sides to center it within a specified total length.
        /// If the string's length is greater than or equal to the specified total length, no padding is applied.
        /// </summary>
        /// <param name="str">The string to center.</param>
        /// <param name="length">The total length of the padded string.</param>
        /// <param name="paddingChar">The character to use for padding.</param>
        /// <returns>A new string that is padded with the specified character to achieve the desired centering.</returns>
        public static string PadCenter(this string str, int length, char paddingChar) {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft, paddingChar).PadRight(length, paddingChar);
        }
    }
}