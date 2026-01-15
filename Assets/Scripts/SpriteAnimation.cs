using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private float totalAnimationTime = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool playOnStart = true;

    private float elapsedTime;
    private bool isPlaying;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (sprites.Count > 0)
        {
            spriteRenderer.sprite = sprites[0];
        }

        if (playOnStart)
        {
            Play();
        }
    }

    private void Update()
    {
        if (!isPlaying || sprites.Count == 0)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        float transitionTime = totalAnimationTime / sprites.Count;

        // Utiliser modulo pour boucler correctement le temps
        float normalizedTime = elapsedTime % totalAnimationTime;
        int currentSpriteIndex = (int)(normalizedTime / transitionTime);

        // Sécurité : s'assurer que l'index est valide
        if (currentSpriteIndex < 0 || currentSpriteIndex >= sprites.Count)
        {
            currentSpriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    public void Play()
    {
        isPlaying = true;
        elapsedTime = 0f;
    }

    public void Stop()
    {
        isPlaying = false;
    }

    public void SetAnimationTime(float newTime)
    {
        totalAnimationTime = newTime;
    }

    public float GetTransitionTime()
    {
        return sprites.Count > 0 ? totalAnimationTime / sprites.Count : 0f;
    }
}