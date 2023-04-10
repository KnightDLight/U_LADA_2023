using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class StringEventListener : MonoBehaviour, IEventListener
{
    [SerializeField] 
    protected List<StringEvent> _listeningTo;

    public abstract void OnEventRaised(object eventData);

    protected virtual void OnEnable()
    {
        foreach(StringEvent relevantEvent in _listeningTo)
		{
            relevantEvent.RegisterListener(this);
        }
    }

    protected virtual void OnDisable()
    {
        foreach (StringEvent relevantEvent in _listeningTo)
        {
            relevantEvent.UnregisterListener(this);
        }
    }
}