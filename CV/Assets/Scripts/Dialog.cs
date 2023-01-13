using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float timeWaitBetwenLetter;
    public List<string> textStart;
    public List<float> timeWaitStart;
    public AudioSource audioSource;
    private int x;
    public Animator canvasAnimator;

    private void Awake()
    {
        StartCoroutine(Dialoque(textStart, timeWaitStart));
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private IEnumerator PrintText(string line) {
        textMeshPro.text = "";
        foreach (char letter in line.ToCharArray()) {
            
            textMeshPro.text += letter;
            yield return new WaitForSeconds(timeWaitBetwenLetter);
            audioSource.pitch = Random.RandomRange(0.8f, 1.1f);
            audioSource.Play();
        }
    }

    public IEnumerator Dialoque(List<string> text, List<float> timeWait) {
        canvasAnimator.SetBool("Dialogue", true);
        for (x = 0; x < text.Count; x ++) {
            float countTime = (text[x].Length * timeWaitBetwenLetter) +3;
            if (canvasAnimator.GetBool("Dialogue") == false) {
                canvasAnimator.SetBool("Dialogue", true);
            }
            StartCoroutine(PrintText(text[x]));
            yield return new WaitForSeconds(countTime);

            if (timeWait[x] > 0)
            {
                canvasAnimator.SetBool("Dialogue", false);
            }
            yield return new WaitForSeconds(timeWait[x]);
        }
        canvasAnimator.SetBool("Dialogue", false);
        yield break;
    }
}
