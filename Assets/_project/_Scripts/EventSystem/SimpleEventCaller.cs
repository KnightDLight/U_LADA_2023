using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventCaller : MonoBehaviour
{
	[SerializeField]
	BaseEvent _eventToRaise;
	public void Raise()
	{
		_eventToRaise.Raise();
	}
}
