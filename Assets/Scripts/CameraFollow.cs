using UnityEngine;

/*
 * CameraFollow
 * Smoothly follows a target object using a fixed offset.
 * Used to keep the camera behind the player in the endless runner.
 */
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );
    }
}
