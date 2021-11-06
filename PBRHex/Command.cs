using System.Windows.Forms;

namespace PBRHex
{
    public abstract class Command<T> where T : Form
    {
        protected T Editor;

        public Command(T editor) {
            Editor = editor;
        }
        // non-StatefulCommands should ALWAYS return false!
        public abstract bool Execute();
        public abstract void Undo();
        public abstract void Redo();
    }
}
