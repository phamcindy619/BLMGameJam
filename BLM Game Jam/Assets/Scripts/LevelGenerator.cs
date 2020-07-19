using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Time between each object spawn
    public float spawnTime;
    // Distance away from player to spawn
    public float spawnDistance;
    // Time until objects begin spawning
    public float spawnDelay;
    // Camera GameObject
    private GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraObj.transform.position.x + spawnDistance, transform.position.y, 0);
    }

    // Spawn a random object from list
    void Spawn()
    {
        GameObject obj = ObjectPool.instance.GetRandomPooledObject();
        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }
}

