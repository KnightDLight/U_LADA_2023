using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class StringEventListener : MonoBehaviour, IEventListener
{
    [SerializeField] 
    protected StringEvent _listeningTo;

    public abstract void OnEventRaised(object eventData);

    protected virtual void OnEnable()
    {
        _listeningTo.RegisterListener(this);
    }

    protected virtual void OnDisable()
    {
        _listeningTo.UnregisterListener(this);
    }
}