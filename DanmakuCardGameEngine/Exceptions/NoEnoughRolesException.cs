using System;
using DanmakuCardGameEngine.Enums.Object;

internal class NoEnoughRolesException : Exception {
    public NoEnoughRolesException(IRoleType heroine, int minPlayers) : base(
        $"No enough {heroine} roles found. At least {minPlayers} {(minPlayers == 1 ? "is" : "are")} required.") { }
}