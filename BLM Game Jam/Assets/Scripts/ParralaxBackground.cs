using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{

    public float parallaxEffectMultiplier;

    private float textureUnitSizeX;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
            float offsetPosition = (transform.position.x - cameraTransform.position.x) % textureUnitSizeX;
            Debug.Log(offsetPosition);
            // offsetPosition = 0f;
            transform.position = new Vector3(cameraTransform.position.x + offsetPosition, transform.position.y);
        }
    }
}
