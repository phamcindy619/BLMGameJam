using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
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
    }

    public void addScore(string itemName, int incr)
    {
        int value = scores[itemName.ToLower()];
        scores[itemName.ToLower()] = value + incr;
        updateScoreBoard();
    }
}
