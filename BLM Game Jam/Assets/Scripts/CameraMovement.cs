using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Speed of camera moving
    public float speed;
    public GameObject wall;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        wall.transform.position = new Vector3(transform.position.x - 25, 0, 0);
    }
}
