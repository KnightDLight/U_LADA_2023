using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Use Event", menuName = "EventSystem/Create Use Event")]
public class UseEventChannelSO : ScriptableObject
{
	public UnityAction OnEventRaised;
	public void RaiseEvent() => OnEventRaised?.Invoke();
}
