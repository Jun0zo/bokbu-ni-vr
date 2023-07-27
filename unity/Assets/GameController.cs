using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject camera;
    public Canvas canvas;

    public float fadeDuration = 2f;
    public bool isStart = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            StartFadeOut();
            camera.GetComponent<Camera_mmove>().isStarted = true;
            

        }
    }

    private Image[] images; // Array to store child Image components

    public void StartFadeOut()
    {
        // If the canvas is not assigned, use the current GameObject (this)
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }

        // Get all the child Image components
        images = canvas.GetComponentsInChildren<Image>(true);

        // Start the fade-out process
        StartCoroutine(FadeOutCanvas());
    }

    private IEnumerator FadeOutCanvas()
    {
        // If the images array is empty or null, display a warning and exit the coroutine
        if (images == null || images.Length == 0)
        {
            Debug.LogWarning("No child Image components found in the Canvas.");
            yield break;
        }

        // Make sure all child images are fully visible before starting the fade-out
        foreach (Image image in images)
        {
            image.canvasRenderer.SetAlpha(1f);
        }

        // Calculate the increment for each frame based on the fade duration
        float fadeIncrement = Time.deltaTime / fadeDuration;

        // Loop until all child images become fully transparent (alpha = 0)
        while (images[0].canvasRenderer.GetAlpha() > 0f)
        {
            // Reduce the alpha value of all child images over time
            foreach (Image image in images)
            {
                image.canvasRenderer.SetAlpha(image.canvasRenderer.GetAlpha() - fadeIncrement);
            }

            yield return null; // Wait for the next frame
        }

        // Ensure all child images are completely transparent
        foreach (Image image in images)
        {
            image.canvasRenderer.SetAlpha(0f);
        }
    }
}
