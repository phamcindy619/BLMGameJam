using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    private Dictionary<string, int> scores;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            scores = new Dictionary<string, int>();
        }
    }
    
    private void updateScoreBoard() {
        string newScore = "";
        foreach(var item in scores)
        {
            newScore += $"{item.Key} x {item.Value}";
        }
        text.text = newScore;
    }

    public void addScore(string itemName, int incr)
    {
        int value;
        if( scores.TryGetValue(itemName, out value) )
        {
            scores[itemName] = value + incr;
        }else {
            scores[itemName] = incr;
        } 
        updateScoreBoard();
    }
}
