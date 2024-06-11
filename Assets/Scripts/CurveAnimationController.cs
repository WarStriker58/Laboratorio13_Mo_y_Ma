using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveAnimationController : MonoBehaviour
{
    [SerializeField] private float pingPongDuration = 2f;
    [SerializeField] private float animationScale = 5f;
    [SerializeField] private float yOffset = -2.5f;

    [Header("Transform")]
    [SerializeField] private Transform cubeTransform;
    [SerializeField] private AnimationCurve curveAnimation;

    private void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time, pingPongDuration);

        float yPosition = curveAnimation.Evaluate(pingPongValue) * animationScale + yOffset;

        cubeTransform.position = new Vector3(0f, yPosition, 0f);
    }
}