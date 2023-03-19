using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	InputReader _inputEventsReader;
	[SerializeField]
	Transform _forwardReference;
	[SerializeField]
	float _gravityValue;
	private CharacterController _controller;
	private Vector2 _movementInput;
	private GroundDetector _groundDetector;

	private void RegisterMovementInput(Vector2 movementInput) => _movementInput = movementInput;

	private void Awake()
	{
		_controller = GetComponent<CharacterController>();
		_inputEventsReader.MovementEvent += RegisterMovementInput;
		_groundDetector = GetComponent<GroundDetector>();
	}
	private void Update()
	{
		Vector3 forward;
		float ySpeed;
		Vector3 desiredMovement;

		forward = CalculatePlayerDesiredForward();
		ySpeed = CalculateVerticalSpeed();
		desiredMovement = forward + Vector3.up * ySpeed;
		ApplyMovement(desiredMovement);
	}
	private void ApplyMovement(Vector3 desiredMovement)
	{
		_controller.Move(desiredMovement * Time.deltaTime);
	}
	private float CalculateVerticalSpeed()
	{
		bool isGrounded;

		isGrounded = _groundDetector.IsGrounded;
		if (isGrounded)
			return (0);
		return _gravityValue;
	}

	private Vector3 CalculatePlayerDesiredForward()
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