using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour, IInteractable, IHasOptions
{
	List<InteractionOption> _options;
	int _currentSelection;
	private void Awake()
	{
		InteractionOption[] results = GetComponents<InteractionOption>();
		_currentSelection = 0;
		if (results.Length == 0)
			return;
		_options = new List<InteractionOption>(results);
	}
	public void Interact()
	{
		if (_options.Count == 0)
			return;
		_options[_currentSelection].Interact();
	}

	public void SelectNext()
	{
		if (_options.Count == 0)
			return;
		_currentSelection++;
		_currentSelection = _currentSelection >= _options.Count ? 0 : _currentSelection;
		Debug.Log($"CurrentSelection : {_options[_currentSelection].InteractionData.Name}");
	}
}