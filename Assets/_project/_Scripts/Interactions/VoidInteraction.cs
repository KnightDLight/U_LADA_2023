using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidInteraction : InteractableObject
{
	[SerializeField]
	SO_InteractionOption _interactionData;
	[SerializeField]
	List<BaseEvent> _triggers;
	public override void Interact()
	{
		foreach(BaseEvent e in _triggers)
		{
			e.Raise();
		}
	}
}
