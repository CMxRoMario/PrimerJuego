using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFinal : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float resetPosition = -10f;

    void Update()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

        if (transform.position.x >= resetPosition)
        {
            ResetCamera();
        }
    }

    void ResetCamera()
    {
        float newXPosition = transform.position.x - resetPosition;

        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
