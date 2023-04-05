using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New GoTo Event", menuName = "EventSystem/Create GoTo Event")]
public class GoToEventChannelSO : ScriptableObject
{
	public UnityAction OnEventRaised;
	public void RaiseEvent() => OnEventRaised?.Invoke();
}
