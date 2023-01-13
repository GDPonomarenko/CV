using System.Collections;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private float x, z;
    public float speedMove, speedRotate, speedRun;
    private float speed;
    public Animator _animator;
    public Transform _transform;
    public bool dialog;
    public GameObject radar;
    private bool isMove;
    public float timeWaitToMove;
    private AudioSource audioSource;
    public AudioClip walk, run;


    void Start()
    {
        isMove = false;
        speed = speedMove;
        _animator.SetBool("Walving", true);
        StartCoroutine(WaitIsMove());
        StartCoroutine(WaitAnimationStart());
        radar.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (isMove) {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (radar.active)
                {
                    radar.SetActive(false);
                }
                else
                {
                    radar.SetActive(true);
                }
            }

            if (z > 0)
            {
                _transform.position += _transform.forward * z * speed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    speed = Mathf.Lerp(speed, speedRun, Time.deltaTime * 2f);
                    _animator.SetBool("Run", true);
                }
                else
                {
                    speed = speedMove;
                    _animator.SetBool("Walk", true);
                    _animator.SetBool("Run", false);
                }
            }
            else
            {
                _animator.SetBool("Walk", false);
                _animator.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _transform.Rotate(new Vector3(_transform.rotation.x, _transform.rotation.y - speedRotate, _transform.rotation.z));
                if (!Input.GetKey(KeyCode.W))
                {
                    _animator.SetBool("TurnLeft", true);
                }
                else
                {
                    _animator.SetBool("TurnLeft", false);
                }
            }
            else
            {
                _animator.SetBool("TurnLeft", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _transform.Rotate(new Vector3(_transform.rotation.x, _transform.rotation.y + speedRotate, _transform.rotation.z));
                if (!Input.GetKey(KeyCode.W))
                {
                    _animator.SetBool("TurnRight", true);
                }
                else
                {
                    _animator.SetBool("TurnRight", false);
                }
            }
            else
            {
                _animator.SetBool("TurnRight", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                _animator.SetBool("Jump", true);
            }
            else
            {
                _animator.SetBool("Jump", false);
            }
        }
    }

    public IEnumerator WaitAnimationStart() {
        yield return new WaitForSeconds(3);
        _animator.SetBool("Walving", false);
        _animator.SetBool("IdleHappy", true);
    }

    public IEnumerator WaitIsMove() {
        yield return new WaitForSeconds(timeWaitToMove);
        isMove = true;
    }


    public void PlayWalk() {
        audioSource.pitch = Random.RandomRange(0.9f, 1.1f);
        audioSource.clip = walk;
        audioSource.Play();
    }

}
