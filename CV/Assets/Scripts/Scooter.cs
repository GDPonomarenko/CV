using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : MonoBehaviour
{
    private bool check;
    public GameObject character;
    public GameObject scooter;
    public bool inScooter;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && check) {
            if (inScooter)
            {
                character.SetActive(true);
                character.transform.position = transform.position;
                scooter.SetActive(false);
            }
            else {
                character.transform.position = transform.position;
                character.SetActive(false);
                scooter.SetActive(true);
                inScooter = true;
            }
            
        }
    }

    /*private void OnTriggerEnter(Collider collider)
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
        }
    }*/
}
