using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEvent : ScriptableObject
{
    protected List<IEventListener> _listeners = new();
    public virtual void RegisterListener(IEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }

    public virtual void UnregisterListener(IEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }
    public virtual void Raise()
	{
        NotifyListeners();
	}
    protected abstract void NotifyListeners();
}