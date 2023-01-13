using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFind : MonoBehaviour
{
    public string nameApp;
    public int countSkill;
    public List<Image> iconSkill;
    public TMP_Text TMPtext;
    public Sprite yes, no;
    public GameObject UIFindActive;
    public Animator dialog;
    public GameObject radar;

    private void FixedUpdate()
    {
        if (UIFindActive.active) {
            dialog.SetBool("Dialogue", false);
            radar.SetActive(false);
        }
    }

    public void SetData() {
        for (int x = 0; x < iconSkill.Count; x++)
        {
            iconSkill[x].sprite = no;
        }

        TMPtext.SetText(nameApp);
        for (int x = 0; x < countSkill; x++)
        {
            iconSkill[x].sprite = yes;
        }

    }

    public void DownGo() {
        UIFindActive.SetActive(false);
    }

}
