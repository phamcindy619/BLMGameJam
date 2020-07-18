using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    private GameObject prologuePanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        prologuePanel = GameObject.Find("PrologueBox");
        prologuePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        prologuePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
