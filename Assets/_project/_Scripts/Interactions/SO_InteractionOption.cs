using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Interaction", menuName ="Interactions/Create New Interaction Option")]
public class SO_InteractionOption : ScriptableObject
{
	[SerializeField]
	string _name;
	[SerializeField]
	string _description;
	public UnityAction OnEventRaised;

	public string Name { get => _name;}

	public void RaiseEvent()
	{
		OnEventRaised?.Invoke();
	}
}
