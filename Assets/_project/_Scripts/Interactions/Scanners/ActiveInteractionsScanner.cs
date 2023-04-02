using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveInteractionsScanner : MonoBehaviour
{
	public List<GameObject>	AvailableInteractions { get => _availableInteractions; }
	List<GameObject>		_availableInteractions = new();
	[SerializeField]
	Vector3					_positionOffset;
	[SerializeField]
	float					_radius;

	private void Update()
	{
		Collider[] results;

		results = Physics.OverlapSphere(transform.position + _positionOffset, _radius);
		AddMissingInteractions(results);
		RemoveDifference(results);
	}

	private void RemoveDifference(Collider[] results)
	{
		List<GameObject>	toRemove;

		toRemove = new();
		foreach (GameObject go in _availableInteractions)
		{
			if (!results.Any(c => c.gameObject == go))
				toRemove.Add(go);
		}
		foreach(GameObject go in toRemove)
		{
			if (_availableInteractions.Contains(go))
				_availableInteractions.Remove(go);
		}
	}

	private void AddMissingInteractions(Collider[] results)
	{
		foreach (Collider hit in results)
		{
			if (hit.GetComponent<IInteractable>() == null)
				continue;
			if (!_availableInteractions.Contains(hit.gameObject))
				_availableInteractions.Add(hit.gameObject);
		}
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position + _positionOffset, _radius);
	}
}