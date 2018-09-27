using System;

namespace EcsRx.Persistence.Editor.EditorInputs
{
    public abstract class SimpleEditorInput<T> : IEditorInput
    {
        public virtual bool HandlesType(Type type)
        { return type == typeof(T); }

        public T GetValue(object value)
        { return (T)value; }

        public UIStateChange CreateUI(string label, object value)
        {
            var underlyingValue = GetValue(value);
            var returnedValue = CreateTypeUI(label, underlyingValue);

            if(returnedValue.Equals(underlyingValue))
            { return UIStateChange.NoChange; }
            
            return new UIStateChange {HasChanged = true, Value = returnedValue };
        }

        protected abstract T CreateTypeUI(string label, T value);
    }
}