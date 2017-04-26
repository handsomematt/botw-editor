using System;
using System.Collections.Generic;

namespace BotWEditor.Editor.Components
{
    public sealed class EditorObject
    {
        private readonly List<BaseComponent> _objectComponentList;

        public string Name;

        public List<BaseComponent> components
        {
            get { return _objectComponentList; }
        }

        public Transform transform
        {
            get { return _transformCache ?? (_transformCache = AddComponent<Transform>()); }
        }

        private Transform _transformCache;

        public EditorObject()
        {
            _objectComponentList = new List<BaseComponent>();
        }

        public EditorObject(string name)
            : this()
        {
            this.Name = name;
        }

        public T AddComponent<T>() where T : BaseComponent
        {
            var newComp = (T)Activator.CreateInstance(typeof(T));
            _objectComponentList.Add(newComp);
            newComp.editorObject = this;

            return newComp;
        }

        public T GetComponent<T>() where T : BaseComponent
        {
            foreach (var comp in _objectComponentList)
            {
                if (comp is T)
                    return (T)comp;
            }

            return null;
        }
    }
}
