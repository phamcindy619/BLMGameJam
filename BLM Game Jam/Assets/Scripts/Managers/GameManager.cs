﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject prologuePanel;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    void Awake()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        youWinPanel.SetActive(false);
        OpenPrologue();
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

    public void FinishGame()
    {
        youWinPanel.SetActive(true);
        Time.timeScale = 0;
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
