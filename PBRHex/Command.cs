using System;

namespace PBRHex
{
    public abstract class Command
    {
        // non-stateful Commands should ALWAYS return false!
        public abstract bool Execute();
        public abstract void Undo();
        public abstract void Redo();
    }
}
