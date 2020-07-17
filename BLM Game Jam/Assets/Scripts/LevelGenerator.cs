using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // List of objects to spawn
    public GameObject[] objects;
    // Time between each object spawn
    public float spawnTime;
    // Player GameObject
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("Spawn", 2.0f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 12.0f, transform.position.y, transform.position.z);
    }

    // Spawn a random object from list
    void Spawn()
    {
        Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.identity);
    }
}

