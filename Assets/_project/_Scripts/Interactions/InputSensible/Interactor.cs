using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField]
	InputReader				_inputEventsReader;
	InteractionsSelector _interactionsSelector;
	void Awake()
	{
		_inputEventsReader.InteractEvent += Interact;
		_interactionsSelector = GetComponent<InteractionsSelector>();
	}

	private void Interact()
	{
		IInteractable	interaction;
		GameObject		currentSelection;

		currentSelection = _interactionsSelector.CurrentSelectedInteraction;
		if (currentSelection == null)
			return;
		interaction = currentSelection.GetComponent<IInteractable>();
		if (interaction == null)
			return;
		interaction.Interact();
		Debug.Log($"Interacted with : " + currentSelection.name);
	}
}