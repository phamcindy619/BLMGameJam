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

    public void addScore(string itemName, int incr)
    {
        int value;
        if( scores.TryGetValue(itemName, out value) )
        {
            scores[itemName] = value + incr;
        }else {
            scores[itemName] = incr;
        } 
        text.text = itemName + " " + scores[itemName].ToString();
    }
}
