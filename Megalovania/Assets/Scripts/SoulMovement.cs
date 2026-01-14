using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoulMovement : MonoBehaviour
{
    /// <summary>
    /// VEX
    /// Last Updated: 1/14/2026
    /// Animates the Red Soul for intro and fades in Canvas Battle Group
    /// </summary>
    public Vector2 targetPosition;
    public float speed = 0.1f;
    public CanvasGroup canvasObject;
    public float flickerDuration = 0.1f;
    public float fadeDuration = 1.0f;

    private bool flicker = false;
    private SpriteRenderer spriteRenderer;
    private FadeTalk scriptFadeTalk;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Flicker());
    }

    // Update is called once per frame
    void Update()
    {
        if (flicker == true)
        {
            // Check if the object has reached the target position
            if ((Vector2)transform.position != targetPosition)
            {
                // Move towards the target position at a constant speed
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                
            }

            if ((Vector2)transform.position == targetPosition)
            {
                this.spriteRenderer.enabled = false;
                //scriptFadeTalk.StartFadeIn(1.0f);
                StartCoroutine(FadeCanvas(canvasObject, canvasObject.alpha, 1f, fadeDuration));
            }
        }
    }


    private IEnumerator Flicker()
    {
        this.spriteRenderer.enabled = false;
        yield return new WaitForSeconds(flickerDuration);
        this.spriteRenderer.enabled = true;
        yield return new WaitForSeconds(flickerDuration);
        this.spriteRenderer.enabled = false;
        yield return new WaitForSeconds(flickerDuration);
        this.spriteRenderer.enabled = true;
        yield return new WaitForSeconds(flickerDuration);
        flicker = true;
    }

    public void FinishTask()
    {
        //canvasObject.SetActive(true);
    }

    IEnumerator FadeCanvas(CanvasGroup cg, float startAlpha, float endAlpha, float duration)
    {

        float startTime = Time.time;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed = Time.time - startTime;
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, timePassed / duration);
            yield return null;
        }

        cg.alpha = endAlpha;
    }
    
}
