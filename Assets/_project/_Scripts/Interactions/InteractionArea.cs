using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class InteractionArea : MonoBehaviour
{
	[SerializeField]
	List<GameObject> _relatedInteractableObjects = new();

	public List<GameObject> Interactions { get => _relatedInteractableObjects; }

	private void OnValidate()
	{
		var toRemove = new List<GameObject>();
		foreach(GameObject interaction in _relatedInteractableObjects)
		{
			if (interaction.GetComponent<IInteractable>() == null)
				toRemove.Add(interaction);
		}
		foreach (GameObject removable in toRemove)
			_relatedInteractableObjects.Remove(removable);
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		foreach(GameObject interactable in _relatedInteractableObjects)
		{
			Gizmos.DrawLine(transform.position, interactable.transform.position);
		}
	}

}
