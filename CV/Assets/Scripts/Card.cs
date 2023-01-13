using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject UI;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Character") {
            UI.SetActive(true);
        }
    }


    public void OnXDown() {
        UI.SetActive(false);
    }
}
