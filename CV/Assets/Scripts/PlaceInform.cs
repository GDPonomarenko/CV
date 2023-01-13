using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;


public class PlaceInform : Dialog
{
    public List<string> placeString;
    public List<float> placeTime;
    private bool timeWaitStart;

    public void Start()
    {
        textMeshPro = GameObject.FindWithTag("TextDialogue").GetComponent<TMP_Text>();
        canvasAnimator = GameObject.FindWithTag("AnimatorDialogue").GetComponent<Animator>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        timeWaitStart = false;
        StartCoroutine(WaitTimeToStart());

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Character") {
            if (timeWaitStart) {
                StartCoroutine(Dialoque(placeString, placeTime));
            }
        }
    }

    private IEnumerator WaitTimeToStart()
    {
        yield return new WaitForSeconds(50);
        timeWaitStart = true;
    }
}
