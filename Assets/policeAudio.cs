using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SirenAndLightController : MonoBehaviour
{
    public AudioSource sirenAudio;
    public Light2D light2D;
    public float blinkInterval = 0.5f;

    private bool isBlinking = false;
    private Color currentColor;

    void Start()
    {
        sirenAudio.Stop();
        currentColor = Color.blue;
        light2D.color = currentColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!sirenAudio.isPlaying)
            {
                sirenAudio.Play();
                if (!isBlinking)
                {
                    StartCoroutine(BlinkLight());
                }
            }
            else
            {
                sirenAudio.Stop();
                isBlinking = false;
                light2D.enabled = false;
            }
        }
    }

    private System.Collections.IEnumerator BlinkLight()
    {
        isBlinking = true;

        while (sirenAudio.isPlaying)
        {
            light2D.enabled = !light2D.enabled;
            currentColor = light2D.enabled ? (currentColor == Color.blue ? Color.red : Color.blue) : currentColor;
            light2D.color = currentColor;
            yield return new WaitForSeconds(blinkInterval);
        }

        light2D.enabled = false;
        isBlinking = false;
    }
}
