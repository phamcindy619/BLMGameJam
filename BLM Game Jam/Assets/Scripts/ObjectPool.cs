using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance = null;

    private List<GameObject> pooledObjects;
    public List<GameObject> objectsToPool;
    // Number of each objects to pre-instantiate
    public int amountToPool = 1;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Pre-instantiate the objects
        pooledObjects = new List<GameObject>();
        foreach (GameObject obj in objectsToPool)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject newObj = (GameObject) Instantiate(obj);
                newObj.SetActive(false);
                pooledObjects.Add(newObj);
            }
        }
    }

    public GameObject GetRandomPooledObject()
    {
        int randIndex;
        do
        {
            randIndex = Random.Range(0, pooledObjects.Count);
        } while (pooledObjects[randIndex].activeInHierarchy);
        return pooledObjects[randIndex];
    }
}
