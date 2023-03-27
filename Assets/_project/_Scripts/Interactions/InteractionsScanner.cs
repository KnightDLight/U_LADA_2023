using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsScanner : MonoBehaviour
{
	[SerializeField]
	Vector3 _positionOffset;
	[SerializeField]
	float _radius;
	public GameObject GetClosestInteractableGameObject()
	{
		Collider[] results = Physics.OverlapSphere(transform.position + _positionOffset, _radius);
		Vector3 center = transform.position + _positionOffset;
		GameObject closestInteraction = null;
		float closestDistance = float.MaxValue;
		for (int i = 0; i < results.Length; i++)
		{
			Collider hit = results[i];
			var interaction = hit.gameObject.GetComponent<IInteractable>();
			if (interaction != null)
			{
				float distance = Vector3.Distance(center, hit.transform.position);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestInteraction = hit.gameObject;
				}
			}
		}
		return closestInteraction;
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position + _positionOffset, _radius);
	}
}