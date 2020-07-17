using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        Application.LoadLevel(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
