using System;

internal class RoleDeckEmptyException : Exception {
    public RoleDeckEmptyException() : base("A role deck was found, but it has no cards.") { }
}