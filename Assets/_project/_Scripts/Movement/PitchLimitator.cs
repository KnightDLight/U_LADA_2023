using UnityEngine;

public class PitchLimitator : MonoBehaviour
{
	[SerializeField]
	float _min;
	[SerializeField]
	float _max;

	private void Update()
	{
		Vector3 currentRot = transform.rotation.eulerAngles;
		float pitch = currentRot.x;
		pitch = Mathf.Clamp(pitch, _min, _max);
		currentRot.y = pitch;
		transform.localRotation = Quaternion.Euler(currentRot);
	}
}