using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOption : MonoBehaviour
{
	[SerializeField]
	SO_InteractionOption _interactionData;
	[SerializeField]
	List<BaseEvent> _triggers;

	public SO_InteractionOption InteractionData { get => _interactionData;}

	public void Interact()
	{
		Debug.Log($"Interacted : " + _interactionData.Name);
		foreach(BaseEvent triggeredEvents in _triggers)
			triggeredEvents.Raise();
	}
}
