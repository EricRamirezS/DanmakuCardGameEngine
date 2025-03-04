using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Commons {
    public interface IDuration : INamedObject { }

    public class Duration : NamedObject, IDuration {
        protected Duration(string name) : base(name) { }
    }
}