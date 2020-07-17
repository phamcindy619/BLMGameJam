using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 3;
    public GameObject[] hearts;


    private int health;
    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
        health = maxHealth;
    }

    public void Damage()
    {
        health--;
        Debug.Log(health);
        Debug.Log(hearts.Length);
        Destroy(hearts[health]);
        Debug.Log("ouchie meanie");
        Debug.Log(health);

        if ( health < 0)
        {
            player.Die();
        }
    }
}
