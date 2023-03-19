using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Input Reader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, PlayerActionsMap.IGameplayActions
{
	public event UnityAction<Vector2>	MovementEvent = delegate { };
	public event UnityAction<Vector2>	MoveCameraEvent = delegate { };
	private PlayerActionsMap			_inputMap;

	private void OnEnable()
	{
		if (_inputMap != null)
			return;
		_inputMap = new();
		_inputMap.Gameplay.SetCallbacks(this);
		_inputMap.Enable();
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
		MovementEvent.Invoke(context.ReadValue<Vector2>());
	}

	public void OnMouseDelta(InputAction.CallbackContext context)
	{
		MoveCameraEvent.Invoke(context.ReadValue<Vector2>());
	}
}