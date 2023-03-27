using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField]
	InputReader _inputEventsReader;
    InteractionsScanner _interactionsScanner;
	private void Awake()
	{
		_interactionsScanner = GetComponent<InteractionsScanner>();
		_inputEventsReader.Interact += Interact;
	}

	private void Interact()
	{
		Debug.Log("Interact Input Pressed");
		var currentInteraction = _interactionsScanner.GetClosestInteractableGameObject();
		if (currentInteraction == null)
			return;
		currentInteraction.GetComponent<IInteractable>().Interact();
	}
}
