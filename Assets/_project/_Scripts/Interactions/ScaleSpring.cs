using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSpring : MonoBehaviour
{
    public float dampingRatio = 0.5f;
    public float angularFrequency = 1.0f;

    private SpringUtils.tDampedSpringMotionParams motionParams = new();
    void Start()
    {
        scale = transform.localScale.x;
        SpringUtils.CalcDampedSpringMotionParams(ref motionParams, Time.fixedDeltaTime, angularFrequency, dampingRatio);
	}
    float scale;
	float velocity = 0.0f;
	void Update()
    {
        //float scale = transform.localScale.x;
		SpringUtils.UpdateDampedSpringMotion(ref scale, ref velocity, 2, in motionParams);
        // actualizar la posición y la velocidad usando los parámetros del resorte
        float newScale = motionParams.m_posPosCoef * scale + motionParams.m_posVelCoef * velocity;
        float newVelocity = motionParams.m_velPosCoef * scale + motionParams.m_velVelCoef * velocity;

        // actualizar la escala del objeto
        transform.localScale = new Vector3(newScale, newScale, newScale);

        velocity = newVelocity;
    }
}
