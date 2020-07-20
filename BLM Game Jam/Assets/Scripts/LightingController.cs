using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{

    public Color startColor;
    public Color endColor;
    public float durationInSeconds = 1.0f;

    public float startIntensity;
    public float endIntensity;


    private bool reverse = false;
    private float t = 0.0f;
    private Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // t += (Time.time - startTime )/ durationInSeconds;
        if (reverse){
            t -= Time.deltaTime / durationInSeconds;
        }else {
            t += Time.deltaTime / durationInSeconds;
        }

        if (t >= 1) {
            reverse = true;
        }else if(t <= 0) {
            reverse = false;
        }

        Debug.Log(t);
        myLight.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
        myLight.color = Color.Lerp(startColor, endColor, t);
    }
}
