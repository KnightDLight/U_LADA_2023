using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input Reader", menuName = "Game/Menus Input Reader")]
public class InputReader_Menus : ScriptableObject, PlayerActionsMap.IMenusActions
{
	public event UnityAction OnAcceptEvent = delegate { };
	private PlayerActionsMap _inputMap;

	private void OnEnable()
	{
		if (_inputMap != null)
			return;
		_inputMap = new();
		_inputMap.Menus.SetCallbacks(this);
		_inputMap.Enable();
	}
	public void OnAccept(InputAction.CallbackContext context)
	{
		if (context.action.phase == InputActionPhase.Canceled)
			OnAcceptEvent.Invoke();
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
	}
}
