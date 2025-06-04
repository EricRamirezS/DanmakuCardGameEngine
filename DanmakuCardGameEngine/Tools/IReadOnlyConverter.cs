namespace DanmakuCardGameEngine.Tools {
    /// <summary>
    /// Defines an interface for objects that can be converted into a read-only representation of themselves.
    /// This is useful for exposing immutable views of mutable objects, ensuring data integrity.
    /// </summary>
    /// <typeparam name="T">The type of the read-only representation.</typeparam>
    public interface IReadOnlyConverter<out T>{
        /// <summary>
        /// Converts the current object into its read-only representation.
        /// </summary>
        /// <returns>A read-only instance of the object.</returns>
        T ToReadOnly();
    }
}