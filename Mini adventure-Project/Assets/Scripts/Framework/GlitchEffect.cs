using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 originalPosition;

    [Header("Glitch Settings")]
    public float glitchDuration = 0.5f;
    public float glitchInterval = 0.1f;
    public Vector2 glitchOffsetRange = new Vector2(0.1f, 0.1f);
    public Color glitchColor = Color.red;

    private bool isGlitching = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("GlitchEffect: SpriteRenderer not found!");
            enabled = false;
            return;
        }
        originalPosition = transform.localPosition;
        StartGlitch();
    }

    public void StartGlitch()
    {
        if (!isGlitching)
        {
            StartCoroutine(GlitchCoroutine());
        }
    }

    private IEnumerator GlitchCoroutine()
    {
        isGlitching = true;
        float timer = 0f;

        while (timer < glitchDuration)
        {
            // Random offset position
            Vector3 offset = new Vector3(
                Random.Range(-glitchOffsetRange.x, glitchOffsetRange.x),
                Random.Range(-glitchOffsetRange.y, glitchOffsetRange.y),
                0f
            );
            transform.localPosition = originalPosition + offset;

            // Change color
            spriteRenderer.color = glitchColor;

            yield return new WaitForSeconds(glitchInterval);

            // Reset position and color
            transform.localPosition = originalPosition;
            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(glitchInterval);

            timer += glitchInterval * 2; // Two intervals per cycle
        }

        // Ensure the sprite is reset after glitching
        transform.localPosition = originalPosition;
        spriteRenderer.color = Color.white;
        isGlitching = false;
    }
}
