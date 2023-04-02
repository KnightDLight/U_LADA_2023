using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsTriggerer : MonoBehaviour, IInteractable
{
	[SerializeField]
	List<ActionSO> _relatedActions;
	public void Interact()
	{
		if (_relatedActions.Count == 0)
			return;
		foreach (ActionSO action in _relatedActions)
		{
			// Trigger the action related event.
		}
	}
}
