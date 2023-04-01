using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScaleWhenHighlighted : MonoBehaviour, IInteractionHighLightEffect
{
	[SerializeField]
	float _scaleIncrement;
	float _desiredScale;
	[SerializeField, Range(0,1)]
	float dampingRatio = 0.5f;
	[SerializeField]
	float angularFrequency = 1.0f;
	private SpringUtils.tDampedSpringMotionParams motionParams = new();
	float _currentScale;
	Vector3 _initialScale;
	void Start()
	{
		_currentScale = 1;
		_initialScale = transform.localScale;
		_desiredScale = 1;
		SpringUtils.CalcDampedSpringMotionParams(ref motionParams, Time.deltaTime, angularFrequency, dampingRatio);
	}
	private void Update()
	{
		float velocity = 0;
		SpringUtils.UpdateDampedSpringMotion(ref _currentScale, ref velocity, _desiredScale, in motionParams);
		float newScale = (motionParams.m_posPosCoef + motionParams.m_posVelCoef) * _currentScale;
		transform.localScale = newScale * _initialScale;
	}
	public void Activate()
	{
		_desiredScale = _scaleIncrement;
	}
	public void Deactivate()
	{
		_desiredScale = 1;
	}
}