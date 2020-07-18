using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private Dictionary<string, int> endScores;
    private Dictionary<string, int> scores;

    private Dictionary<string, TextMeshProUGUI> textMeshes;

    public TextMeshProUGUI MaskScore;
    public TextMeshProUGUI SunscreenScore;
    public TextMeshProUGUI HatScore;
    public TextMeshProUGUI WaterScore;
    public TextMeshProUGUI FoodScore;



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            scores = new Dictionary<string, int>
            {
                {"mask", 0 },
                {"sunscreen", 0},
                {"hat", 0},
                {"water", 0},
                {"food", 0},
            };

            endScores = new Dictionary<string, int>
            {
                {"mask", 7},
                {"sunscreen", 15},
                {"hat", 7},
                {"water", 15},
                {"food", 15},
            };
            
            textMeshes = new Dictionary<string, TextMeshProUGUI>
            {
                {"mask", MaskScore},
                {"sunscreen", SunscreenScore},
                {"hat", HatScore},
                {"water", WaterScore},
                {"food", FoodScore},
            };
        }

    }
    
    private void updateScoreBoard() 
    {
        foreach(var item in scores)
        {
            textMeshes[item.Key].text = $" x {item.Value}";
        }
        // End game if scores reached
        if (CheckIfFinish())
            FinishGame();
    }

    public void addScore(string itemName, int incr)
    {
        int value = scores[itemName.ToLower()];
        scores[itemName.ToLower()] = value + incr;
        updateScoreBoard();
    }

    // Check whether enough items are collected to finish game
    bool CheckIfFinish()
    {
        foreach (KeyValuePair<string, int> item in scores)
        {
            if (item.Value < endScores[item.Key])
                return false;
        }
        return true;
    }

    void FinishGame()
    {
        Debug.Log("Game Finished!");
    }
}
