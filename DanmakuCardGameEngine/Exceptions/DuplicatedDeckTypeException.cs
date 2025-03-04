using System;

namespace DanmakuCardGameEngine.Exceptions {
    public class DuplicatedDeckTypeException : Exception {
        public DuplicatedDeckTypeException(Type type) {
        }
    }
}