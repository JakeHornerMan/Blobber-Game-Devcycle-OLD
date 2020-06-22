//Simpler Version of CamerFollow
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    //public float smoothSpeed = 1.0f;
    public Vector3 offset;

    private void LateUpdate()
    {
        
        transform.position = target.position + offset;
    }
}
