using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	[SerializeField]
	InputReader _input;
	[SerializeField]
	CharacterController _charController;
	[SerializeField]
	Transform _gameplayCam;

	ForwardCalculatorConsideringCameraAndInput _forwardCalculator;
	Vector3 activeMovDir;
	Vector2 _movementInput;

	private void Awake()
	{
		if (_gameplayCam == null)
			return;
		_forwardCalculator = new(_gameplayCam);
		_charController = GetComponent<CharacterController>();
		_input.MovementEvent += UpdateMovementInput;
	}

	private void UpdateMovementInput(Vector2 movementInput)
	{
		_movementInput = movementInput;
	}
	private void Update()
	{
		Vector3 movementDir;
		activeMovDir = _forwardCalculator.GetForwardRelativeToCameraAndMovementInput(_movementInput);
		movementDir = activeMovDir;
		_charController.Move(movementDir * Time.deltaTime);
	}
}