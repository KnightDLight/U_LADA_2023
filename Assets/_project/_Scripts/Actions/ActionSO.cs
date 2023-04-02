using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Action", menuName = "Actions/Create New Action")]
public class ActionSO : ScriptableObject
{
	[SerializeField]
	string	_name;
	[SerializeField]
	string _description;
	[SerializeField]
	Sprite _relatedIcon;

}
