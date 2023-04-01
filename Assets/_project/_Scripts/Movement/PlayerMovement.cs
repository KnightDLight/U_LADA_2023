using UnityEngine;

[RequireComponent(typeof(CharacterController)), SelectionBase]
public class PlayerMovement : MonoBehaviour
{
	CharacterController	_controller;
	GroundDetector		_groundDetector;
	[SerializeField]
	InputReader			_inputEventsReader;
	[SerializeField]
	Transform			_forwardReference;
	Vector2				_movementInput;
	[SerializeField]
	float				_gravityValue;

	void RegisterMovementInput(Vector2 movementInput) => _movementInput = movementInput;

	void Awake()
	{
		_controller = GetComponent<CharacterController>();
		_inputEventsReader.MovementEvent += RegisterMovementInput;
		_groundDetector = GetComponent<GroundDetector>();
	}

	void Update()
	{
		Vector3	forward;
		Vector3	desiredMovement;
		float	ySpeed;

		forward = CalculatePlayerDesiredForward();
		ySpeed = CalculateVerticalSpeed();
		desiredMovement = forward + Vector3.up * ySpeed;
		ApplyMovement(desiredMovement);
	}

	void ApplyMovement(Vector3 desiredMovement)
	{
		_controller.Move(desiredMovement * Time.deltaTime);
	}

	float CalculateVerticalSpeed()
	{
		bool isGrounded;

		isGrounded = _groundDetector.IsGrounded;
		if (isGrounded)
			return (0);
		return _gravityValue;
	}

	Vector3 CalculatePlayerDesiredForward()
	{
		Vector3 forwardRef;
		Vector3 rightRef;
		Vector3 desiredForward;
		
		forwardRef = _forwardReference.forward;
		rightRef = _forwardReference.right;
		desiredForward = forwardRef * _movementInput.y + rightRef * _movementInput.x;
		desiredForward.y = 0;
		desiredForward.Normalize();
		return desiredForward;
	}
}