using UnityEngine;

[CreateAssetMenu(fileName = "New Void Event", menuName = "Events/Void Event")]
public class VoidEvent : BaseEvent
{
	public void Raise()
	{
		NotifyListeners();
	}

	protected override void NotifyListeners()
    {
		foreach (IEventListener listener in _listeners)
			listener.OnEventRaised(null);
	}

}
