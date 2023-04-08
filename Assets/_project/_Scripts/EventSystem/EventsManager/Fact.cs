using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Fact", menuName = "Events/Create New Fact")]
public class Fact : ScriptableObject
{
	[SerializeField]
	int _value;

	public int Value { get => _value; set => _value = value; }
}
