using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsOptionsSelector : MonoBehaviour
{
   [SerializeField]
	InputReader				_inputEventsReader;
	InteractionsSelector	_interactionsSelector;
	void Awake()
	{
		_inputEventsReader.SwapOptionEvent += Swap;
		_interactionsSelector = GetComponent<InteractionsSelector>();
	}

	private void Swap()
	{
		IHasOptions	hasOptions;
		GameObject		currentSelection;

		currentSelection = _interactionsSelector.CurrentSelectedInteraction;
		if (currentSelection == null)
			return;
		hasOptions = currentSelection.GetComponent<IHasOptions>();
		if (hasOptions == null)
			return;
		hasOptions.SelectNext();
	}
}
