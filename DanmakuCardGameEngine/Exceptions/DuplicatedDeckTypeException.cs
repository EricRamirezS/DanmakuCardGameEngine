using System;

namespace DanmakuCardGameEngine.Models.Deck {
    public class DuplicatedDeckTypeException : Exception {
        public DuplicatedDeckTypeException(Type type) {
        }
    }
}