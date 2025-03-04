using System;

internal class RoleDeckNotFoundException : Exception {
    public RoleDeckNotFoundException() : base("No role deck was found.") { }
}