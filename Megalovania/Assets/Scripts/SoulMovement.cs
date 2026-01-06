using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulMovement : MonoBehaviour
{
    /// <summary>
    /// VEX
    /// Last Updated: 1/5/2026
    /// Animates the Red Soul for intro
    /// </summary>
    public Vector2 targetPosition;
    public float speed = 0.1f;

    private bool flicker = false;
    private SpriteRenderer spriteRenderer;
    public float flickerDuration = 0.1f; 

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

}
