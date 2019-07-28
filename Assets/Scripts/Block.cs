using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] GameObject particleEffect;
    [SerializeField] Sprite[] blockSprites;

    private int maxHits = 1;

    private Level level;
    private SpriteRenderer spriteRenderer;

    int totalHits = 0;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (!level || !spriteRenderer)
        {
            Debug.LogError("Could not find Level Object or SpriteRenderer");
        }

        if (gameObject.tag == "Breakable")
        {
            level.addToBlockCounter();
        }

        maxHits = blockSprites.Length + 1;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        totalHits++;
        if (totalHits == maxHits)
        {
            DestroyBlock();
        }
        else
        {
            spriteRenderer.sprite = blockSprites[totalHits - 1];
        }
        
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
        level.removeFromBlockCounter();
        FindObjectOfType<GameSession>().addScore();
        TriggerParticleVFX();
        Destroy(gameObject);
    }

    private void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
