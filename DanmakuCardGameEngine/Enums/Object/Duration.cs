using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Commons {
    public class Duration : NamedObject, IDuration {
        protected Duration(string name) : base(name) { }
    }
}