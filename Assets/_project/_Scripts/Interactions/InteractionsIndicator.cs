using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsIndicator : MonoBehaviour
{
	InteractionsScanner _interactionsScanner;
	GameObject _closestInteraction;
	GameObject _currentlyFocusedInteraction;

	private void Awake()
	{
		_interactionsScanner = GetComponent<InteractionsScanner>();
	}
	private void Update()
	{
		if (_interactionsScanner == null)
			return;
		_closestInteraction = _interactionsScanner.GetClosestInteractableGameObject();
		if (_closestInteraction == null)
		{
			if (_currentlyFocusedInteraction == null)
				return;
			UnHighLight(_currentlyFocusedInteraction);
			_currentlyFocusedInteraction = null;
			return;
		}
		if (_closestInteraction == _currentlyFocusedInteraction)
			return;
		if (_currentlyFocusedInteraction != null)
			UnHighLight(_currentlyFocusedInteraction);
		_currentlyFocusedInteraction = _closestInteraction;
		HighLight(_currentlyFocusedInteraction);
	}

	private void HighLight(GameObject target)
	{
		var visuallIndicators = target.GetComponents<IIInteractionVisualIndicator>();
		foreach (IIInteractionVisualIndicator visualIndicator in visuallIndicators)
		{
			visualIndicator.Activate();
		}
	}

	private void UnHighLight(GameObject target)
	{
		var visuallIndicators = target.GetComponents<IIInteractionVisualIndicator>();
		foreach (IIInteractionVisualIndicator visualIndicator in visuallIndicators)
		{
			visualIndicator.Deactivate();
		}
	}
}