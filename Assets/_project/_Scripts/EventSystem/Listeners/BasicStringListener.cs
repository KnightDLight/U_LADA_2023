using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicStringListener : StringEventListener
{
	[SerializeField]
	List<UnityEvent> _triggers;
	public override void OnEventRaised(object eventData)
	{
		foreach (UnityEvent e in _triggers)
		{
			e?.Invoke();
		}
	}
}
