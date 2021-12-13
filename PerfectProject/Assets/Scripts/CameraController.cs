using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private void FixedUpdate()
    {
        if (target.localScale.x < 0 && offset.x > 0)
        {
            offset.x *= -1;
        }
        else if(target.localScale.x > 0 && offset.x < 0)
        {
            offset.x *= -1;
        }
        transform.position = Vector3.Lerp(transform.position, target.position,damping) + offset;

    }
}
