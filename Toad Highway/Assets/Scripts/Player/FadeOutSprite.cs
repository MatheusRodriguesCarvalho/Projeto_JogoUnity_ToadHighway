using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSprite : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Tempo em segundos para o fade out
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFading = false;

    void Start()
    {
        // Obtém o SpriteRenderer do objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            //Debug.Log("SpriteRenderer found!");
            originalColor = spriteRenderer.color;
        }
        else
        {
            //Debug.LogError("Sprite Renderer Not Found!");
        }
    }

    void Update()
    {
        // Verifica se a tecla 'B' foi pressionada
        if (Input.GetKeyDown(KeyCode.B) && !isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    private System.Collections.IEnumerator FadeOut()
    {
        Debug.Log("Start Fade");

        float elapsedTime = 0f;
        isFading = true;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(originalColor.a, 0, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Certifica que o alfa está em 0 no final
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        isFading = false;

    }
}