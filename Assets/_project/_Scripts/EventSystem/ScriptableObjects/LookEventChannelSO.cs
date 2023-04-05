using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Look Event", menuName = "EventSystem/Create Look Event")]
public class LookEventChannelSO : ScriptableObject
{
	public UnityAction OnEventRaised;
	public void RaiseEvent() => OnEventRaised?.Invoke();
}
