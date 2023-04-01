using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveInteractionsScanner : MonoBehaviour, IInteractionsScanner
{
	List<GameObject> _availableInteractions = new();
	public List<GameObject> GetAvailableInteractions()
	{
		return _availableInteractions;
	}
	private void OnTriggerEnter(Collider other)
	{
		var interactionArea = other.GetComponent<InteractionArea>();
		if (interactionArea == null)
			return;
		_availableInteractions =  new(interactionArea.Interactions);
	}
	private void OnTriggerExit(Collider other)
	{
		_availableInteractions.Clear();
	}
}
