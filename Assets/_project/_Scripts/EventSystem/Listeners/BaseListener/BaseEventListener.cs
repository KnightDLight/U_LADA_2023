using UnityEngine;

public abstract class BaseEventListener : MonoBehaviour, IEventListener
{
    public abstract void OnEventRaised(object eventData);
}
