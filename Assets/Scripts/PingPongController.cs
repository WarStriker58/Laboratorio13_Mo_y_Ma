using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongController : MonoBehaviour
{
    [SerializeField] private float pingPongDuration = 10f;
    [SerializeField] private float offset = -5f;
    [SerializeField] private float minValue = -5f;
    [SerializeField] private float maxValue = 5f;

    [Header("Transform")]
    [SerializeField] private Transform cubeTransform;

    private void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time, pingPongDuration) + offset;

        float clampedValue = Mathf.Clamp(pingPongValue, minValue, maxValue);

        cubeTransform.position = new Vector3(clampedValue, 0f, 0f);
    }
}