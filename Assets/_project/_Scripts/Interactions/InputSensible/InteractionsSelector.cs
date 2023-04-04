using System.Collections.Generic;
using UnityEngine;

public class InteractionsSelector : MonoBehaviour
{
	[SerializeField]
	GameObject _scanner;
	InteractionsHighLighter	_highLighter;
    IInteractionsScanner	_interactionsScanner;
	List<GameObject>		availableInteractions;
	[SerializeField]
	InputReader				_inputReader;
	GameObject				_currentSelectedInteraction;
	int						_currentSelectionIndex;

	public GameObject CurrentSelectedInteraction {get => _currentSelectedInteraction;}

	private void Awake()
	{
		_highLighter = new();
		_currentSelectedInteraction = null;
		_currentSelectionIndex = 0;
		_interactionsScanner = _scanner.GetComponent<IInteractionsScanner>();
		_inputReader.SwapSelectionEvent += OnManualSelectionSwap;
	}

	private void OnManualSelectionSwap()
	{
		GameObject	target;
		int			maxIndex;

		if (availableInteractions.Count <= 1)
			return;
		maxIndex = availableInteractions.Count - 1;
		_currentSelectionIndex++;
		if (_currentSelectionIndex > maxIndex)
			_currentSelectionIndex = 0;
		target = availableInteractions[_currentSelectionIndex];
		_highLighter.UnHighLight(_currentSelectedInteraction);
		_highLighter.Highlight(target);
		_currentSelectedInteraction = target;
	}

	private void Update()
	{
		availableInteractions = _interactionsScanner.GetAvailableInteractions();
		if (_currentSelectedInteraction == null)
		{
			if (availableInteractions.Count != 0)
				SelectFirstAvailableInteraction();
			return;
		}
		if (!availableInteractions.Contains(_currentSelectedInteraction))
		{
			_highLighter.UnHighLight(_currentSelectedInteraction);
			_currentSelectedInteraction = null;
			return;
		}
	}
	private void SelectFirstAvailableInteraction()
	{
		GameObject target;

		_currentSelectionIndex = 0;
		target = availableInteractions[_currentSelectionIndex];
		_highLighter.Highlight(target);
		_currentSelectedInteraction = target;
	}

}