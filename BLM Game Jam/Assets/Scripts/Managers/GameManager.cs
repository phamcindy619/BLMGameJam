using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    void Awake()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        youWinPanel.SetActive(false);
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        youWinPanel.SetActive(true);
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
}
