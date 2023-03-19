using UnityEngine;

public class GroundDetector : MonoBehaviour
{
	[SerializeField]
	Vector3 _offset;
	[SerializeField]
	float _radius;
	[SerializeField]
	LayerMask _detectionMask;
	[SerializeField]
	bool _debug;
	public bool IsGrounded { get; private set; }
	private void Update() => IsGrounded = Physics.CheckSphere(transform.position + _offset, _radius, _detectionMask);
	private void OnDrawGizmosSelected()
	{
		if (!_debug)
			return;
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position + _offset, _radius);
	}
}