using UnityEngine;
using System.Collections;


public class Box : MonoBehaviour
{
    public GameObject prefabSkills;
    public GameObject openBox;
    private bool check;
    private Vector3 newPos;
    private bool d;
    private GameObject listPrefab;
    private Animator findUI;
    public GameObject countSkills;

    public bool timeWaitStart;


    void Start()
    {
        d = false;
        timeWaitStart = false;
        listPrefab = GameObject.FindWithTag("Radar");
        findUI = GameObject.FindWithTag("AnimatorDialogue").GetComponent<Animator>();
        countSkills = GameObject.Find("CountSkills");
        StartCoroutine(WaitTimeToStart());
    }

    void Update()
    {
        newPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        if (check && !d && timeWaitStart) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(openBox, newPos, Quaternion.identity);
                Instantiate(prefabSkills, newPos, Quaternion.identity);

                d = true;
                listPrefab.GetComponent<Radar>().prefabs.Remove(gameObject.transform);
                findUI.SetBool("Dialogue", false);
                countSkills.GetComponent<CountSkills>().SetCount();
                Destroy(gameObject);
            }

        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Character") {
            check = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Character")
        {
            check = false;
            d = false;
        }
    }

    private IEnumerator WaitTimeToStart() {
        yield return new WaitForSeconds(50);
        timeWaitStart = true;
    }
}
