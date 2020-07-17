using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public string pickupName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("oof");
        if (other.gameObject.CompareTag("Player")) 
        {
            ScoreManager.instance.addScore(pickupName, 1);
        }
    }
}
