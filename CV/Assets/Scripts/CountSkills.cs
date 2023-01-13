using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class CountSkills : MonoBehaviour
{
    public int countSkills;
    public TMP_Text textCount;
    public int allSkills;

    public GameObject allSkillsGO;
    public GameObject radar;

    public GameObject dialog;
    void Start()
    {
        countSkills = 0;
    }

    private void FixedUpdate()
    {
        
    }

    public void SetCount() {
        countSkills++;
        textCount.SetText(countSkills.ToString()+"/"+ allSkills);

        if (countSkills == allSkills)
        {
            radar.SetActive(false);
            StartCoroutine(WaitStartAllSkills());
            dialog.SetActive(false);
            allSkillsGO.SetActive(true);
        }

    }

    public void OnReplayDown() {
        SceneManager.LoadScene(0);
    }


    private IEnumerator WaitStartAllSkills() {
        yield return new WaitForSeconds(4);
    }
}
