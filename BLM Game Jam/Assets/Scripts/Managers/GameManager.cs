using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject prologuePanel;
    public GameObject gameOverPanel;
    public static GameManager instance = null;

    void Start()
    {
        gameOverPanel.SetActive(false);
        OpenPrologue();
    }

    void Awake()
    {
        // Check if there is another SoundManager
        if (instance == null)
            instance = this;
        // Destroy any duplicate
        else if (instance != this)
            Destroy(gameObject);
        
        // Don't destroy SoundManager when reloading the scene
        DontDestroyOnLoad(gameObject);
    }

    void OpenPrologue()
    {
        prologuePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePrologue()
    {
        prologuePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FinishGame()
    {
        Debug.Log("Game Finished!");
    }
}
