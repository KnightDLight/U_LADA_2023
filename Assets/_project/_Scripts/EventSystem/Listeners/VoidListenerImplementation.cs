using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidListenerImplementation : VoidEventListener
{
	[SerializeField]
	UnityEvent _onEventRaise;
	public override void OnEventRaised(object eventData)
	{
		Debug.Log("VOID EVENT HAPPENED");
		_onEventRaise?.Invoke();
	}
}
