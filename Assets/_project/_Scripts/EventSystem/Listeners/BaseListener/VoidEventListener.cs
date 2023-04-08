using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VoidEventListener : MonoBehaviour, IEventListener
{
	[SerializeField]
	protected VoidEvent _event;
	protected virtual void Awake()
	{
		_event.RegisterListener(this);
	}
	protected virtual void OnDisable()
	{
		_event.UnregisterListener(this);
	}
	public abstract void OnEventRaised(object eventData);
}
