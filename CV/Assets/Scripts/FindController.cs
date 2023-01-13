using System.Collections;
using UnityEngine;

public class FindController : MonoBehaviour
{
    public GameObject uiFind;
    public string name;
    public int count;

    void Start()
    {
        uiFind = GameObject.FindWithTag("UIFingTag");
        StartCoroutine(AnimationSelect());
    }

    private IEnumerator AnimationSelect() {
        yield return new WaitForSeconds(2);
        uiFind.GetComponent<UIFind>().nameApp = name;
        uiFind.GetComponent<UIFind>().countSkill = count;
        uiFind.GetComponent<UIFind>().UIFindActive.SetActive(true);
        uiFind.GetComponent<UIFind>().SetData();
        yield return new WaitForSeconds(5);
        Destroy(gameObject);

    }
}
