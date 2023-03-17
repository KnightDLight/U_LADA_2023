using UnityEngine;

public class ForwardCalculatorConsideringCameraAndInput
{
	private Transform _gameplayCamera;
	public ForwardCalculatorConsideringCameraAndInput(Transform gameplayCamera)
	{
		_gameplayCamera = gameplayCamera;
	}

	public Vector3	GetForwardRelativeToCameraAndMovementInput(Vector2 movementInput)
	{
		Vector3	camForward;
		Vector3	forwardVector;

		camForward = _gameplayCamera.forward;
		camForward.y = 0;
		forwardVector = camForward * movementInput.y + _gameplayCamera.right * movementInput.x;
		forwardVector.y = 0;
		return forwardVector.normalized; 
	}
}