using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
	[SerializeField]
	InputReader _inputEventsReader;
	InteractionsSelector _interactionsSelector;
	void Awake()
	{
		_inputEventsReader.LookAtEvent += TryLooking;
		_interactionsSelector = GetComponent<InteractionsSelector>();
	}

	private void TryLooking()
	{
		ILookable interaction;
		GameObject currentSelection;

		currentSelection = _interactionsSelector.CurrentSelectedInteraction;
		if (currentSelection == null)
			return;
		interaction = currentSelection.GetComponent<ILookable>();
		if (interaction == null)
			return;
		interaction.GetLookedAt();
		Debug.Log($"Looked at : " + currentSelection.name);
	}
}
