namespace BotWEditor.Editor.Components
{
    public class BaseComponent
    {
        public EditorObject editorObject { get; set; }

        public Transform transform
        {
            get { return editorObject.transform; }
        }

        public virtual void Update() { }
    }
}
