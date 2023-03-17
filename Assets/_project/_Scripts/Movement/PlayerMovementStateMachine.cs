using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
	[SerializeField]
	InputReader	_playerInput;
	[Header("Movement Settings"), Space, Header("Walk"), SerializeField]
	float _walkSpeed;
	[SerializeField]
	float _runSpeed;
	
	PlayerLocomotionStates	CurrentState = PlayerLocomotionStates.idle;
	Vector2					_movementInput;

	private void MovementInputDetected(Vector2 movementInput) => _movementInput = movementInput;

	private void Awake()
	{
		_playerInput.MovementEvent += MovementInputDetected;
	}

	private void Update()
	{
		if (CurrentState == PlayerLocomotionStates.frozen)
			return;
	}
}
public enum PlayerLocomotionStates
{
	idle,
	walk,
	run,
	frozen
}