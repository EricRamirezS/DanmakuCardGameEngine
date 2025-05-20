using System;

namespace DanmakuCardGameEngine.Exceptions {
    internal class RoleDeckNotFoundException : Exception {
        public RoleDeckNotFoundException() : base("No role deck was found.") { }
    }
}