using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/// <summary>
/// VEX
/// Last Updated: 1/14/2026
/// Fades in BOSS and is logic for intro Talk
/// </summary>

public class FadeTalk : MonoBehaviour
{
    public SpriteRenderer spriteRendererBoss;

    void Start()
    {
        spriteRendererBoss = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
       
    }

    IEnumerator SpriteFadeIn(float duration)
    {
        float startAlpha = spriteRendererBoss.color.a;
        float targetAlpha = 1.0f; 
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);

            Color currentColor = spriteRendererBoss.color;
            currentColor.a = newAlpha;
            spriteRendererBoss.color = currentColor;

            yield return null; 
        }

        Color finalColor = spriteRendererBoss.color;
        finalColor.a = targetAlpha;
        spriteRendererBoss.color = finalColor;
    }

    public void StartFadeIn(float duration)
    {
        StartCoroutine(SpriteFadeIn(duration));
    }

}
