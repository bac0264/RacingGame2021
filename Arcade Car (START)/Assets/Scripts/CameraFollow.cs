using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraPoint;

    public Transform vehicle;
    // Smooth the Camera with LateUpdate

    private void LateUpdate()
    {
        transform.position = cameraPoint.transform.position;
        transform.eulerAngles = vehicle.eulerAngles;
    }
}
