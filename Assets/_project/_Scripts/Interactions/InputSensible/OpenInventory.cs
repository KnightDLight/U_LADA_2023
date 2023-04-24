using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
	[SerializeField]
	InputReader _inputEventsReader;
	InteractionsSelector _interactionsSelector;
	void Awake()
	{
		_inputEventsReader.OpenInventoryEvent += Open;
		_interactionsSelector = GetComponent<InteractionsSelector>();
	}
	bool _isOpen = false;
	private void Open()
	{
		_isOpen = !_isOpen;
		Debug.Log($"Inventory is open : {_isOpen}");
	}
}
