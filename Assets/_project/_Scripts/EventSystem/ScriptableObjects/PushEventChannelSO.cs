using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Push Event", menuName = "EventSystem/Create Push Event")]
public class PushEventChannelSO : ScriptableObject
{
	public UnityAction OnEventRaised;
	public void RaiseEvent() => OnEventRaised?.Invoke();
}
