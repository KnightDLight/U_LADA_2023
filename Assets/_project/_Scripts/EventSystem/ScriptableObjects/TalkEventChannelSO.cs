using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Talk Event", menuName = "EventSystem/Create Talk Event")]
public class TalkEventChannelSO : ScriptableObject
{
	public UnityAction OnEventRaised;
	public void RaiseEvent() => OnEventRaised?.Invoke();
}
