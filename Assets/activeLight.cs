using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggle : MonoBehaviour
{
    private Light2D[] lightObjects;

    void Start()
    {
        
        lightObjects = GetComponentsInChildren<Light2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            foreach (Light2D light in lightObjects)
            {
                light.enabled = !light.enabled;
            }
        }
    }
}
