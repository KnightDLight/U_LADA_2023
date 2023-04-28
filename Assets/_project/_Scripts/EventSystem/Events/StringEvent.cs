using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String Event", menuName = "Events/String Event")]
public class StringEvent : BaseEvent
{
	[SerializeField]
	string _dataToTransfer;
	protected override void NotifyListeners()
	{
		if (_dataToTransfer == null)
			return;
		foreach (IEventListener listener in _listeners)
			listener.OnEventRaised(_dataToTransfer);
	}
	public void SetString(string data) => _dataToTransfer = data;
	public string GetString() => _dataToTransfer;
}
