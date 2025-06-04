namespace DanmakuCardGameEngine.Models.Cards.Type {
    /// <summary>
    /// Defines an interface for an Item Card in the Danmaku Card Game Engine.
    /// Item cards are typically played by a player and placed in their item field.
    /// They usually have effects while they are on the player's item field,
    /// and may also have effects that trigger when they are played, discarded,
    /// or when the player takes control of the item.
    /// </summary>
    public interface IItemCard : ICard { }
}