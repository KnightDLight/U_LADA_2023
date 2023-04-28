using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Load Scene Rule", menuName = "Events/Rules/Create Load Scene Rule")]
public class LoadSceneRule : Rule
{
	[SerializeField]
	List<BaseEvent> _execute;
	protected override void Execute()
	{
		foreach(BaseEvent e in _execute)
		{
			e.Raise();
		}
	}
}
