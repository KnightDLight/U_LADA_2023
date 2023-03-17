using UnityEngine;

public class CameraRotator : MonoBehaviour
{
	[SerializeField]
	InputReader _input;
	[SerializeField]
	Transform	_target;
	[SerializeField]
	float _pitchLimit = 80;

	Vector2		_desiredMouseDelta;
	bool		_isActive;
	float		_yaw;
	float		_pitch;

	public bool IsActive { get => _isActive; set => _isActive = value; }

	private void Awake()
	{
		_input.MoveCameraEvent += RegisterMouseInput;
		IsActive = true;
		Cursor.lockState = CursorLockMode.Locked;
		Debug.Log("Mouse Locked Here");
	}

	private void RegisterMouseInput(Vector2 mouseDelta)
	{
		_desiredMouseDelta = mouseDelta;
	}

	private void Update()
	{
		if (!IsActive)
			return;
		Vector3 desiredAngles;
		desiredAngles = transform.localRotation.eulerAngles;
		AddInputToRotation();
		LimitPitch();
		desiredAngles = new Vector3(_pitch, _yaw, desiredAngles.z);
		SetRotation(desiredAngles);
	}

	private void SetRotation(Vector3 eulerAngles)
	{
		_target.localRotation = Quaternion.Euler(eulerAngles);
	}

	private void AddInputToRotation()
	{
		_yaw += _desiredMouseDelta.x * Time.deltaTime;
		_pitch += _desiredMouseDelta.y * Time.deltaTime;
	}

	private void LimitPitch()
	{
		_pitch = Mathf.Clamp(_pitch, -_pitchLimit, _pitchLimit);
	}
}