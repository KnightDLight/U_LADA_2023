using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractable : MonoBehaviour, IInteractable
{
	public void Interact()
	{
		Debug.Log($"AH {this.name}");
	}
}
