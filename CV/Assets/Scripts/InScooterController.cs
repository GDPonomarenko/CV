using UnityEngine;

public class InScooterController : MonoBehaviour
{
    public Transform frontWhel, backWhel;
    public float speedWhelRotate;
    public float speed;
    private Transform _transform;
    private float x, z;
    public float speedGoInScooter, speedTurnInScooter, speedMoveRightLeft;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Debug.Log(frontWhel.rotation.y);
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        _transform.position += _transform.forward * z * speed;
        _transform.position = new Vector3(_transform.position.x,-3.7f , _transform.position.z);

        frontWhel.Rotate(new Vector3(speedWhelRotate, 0, 0));
        backWhel.Rotate(new Vector3(speedWhelRotate, 0,0));

        if (Input.GetKey(KeyCode.W))
        {
            speed = Mathf.Lerp(speed, speedGoInScooter, Time.deltaTime *2);
        }
        else {
            speed = Mathf.Lerp(speed, 0.02f,Time.deltaTime/2);
            speedWhelRotate = 0;
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _transform.Rotate(new Vector3(0, -1f, 0));
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _transform.Rotate(new Vector3(0, 1f, 0));
            }
        }


    }
}
