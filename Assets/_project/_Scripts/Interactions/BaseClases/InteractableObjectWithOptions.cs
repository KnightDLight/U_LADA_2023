using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObjectWithOptions : InteractableObject, IHasOptions
{
	[SerializeField]
	protected List<SO_InteractionOption> b_availableOptions;
	protected int b_currentSelection;
	public override void Interact()
	{
		b_availableOptions[b_currentSelection].RaiseEvent();
	}
	public void SelectNext()
	{
		b_currentSelection++;
		if (b_currentSelection >= b_availableOptions.Count)
			b_currentSelection = 0;
		Debug.Log($"Opción seleccionada de objeto {gameObject.name} es ahora : {b_availableOptions[b_currentSelection].Name}");

	}
	public SO_InteractionOption GetCurrentSelection()
	{
		return b_availableOptions[b_currentSelection];
	}
	
	protected virtual void Awake()
	{
		b_currentSelection = 0;
	}
}