using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objective;
    public float cameraVelocity = 0.025f;
    public Vector3 displacement;

    private void Update()
    {
        Vector3 position = objective.position + displacement;
        Vector3 softenedPosition = Vector3.Lerp(transform.position, position, cameraVelocity);
        transform.position = softenedPosition;  
    }
}
