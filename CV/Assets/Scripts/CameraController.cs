using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 newPos;
    public float diplaceX, diplaceZ;

    void Update()
    {
        transform.LookAt(target);
        newPos = new Vector3(target.position.x - diplaceX, transform.position.y, target.position.z-diplaceZ);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime*0.3f);
    }
}
