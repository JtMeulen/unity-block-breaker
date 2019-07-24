using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] GameObject particleEffect;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();

        if (!level)
        {
            Debug.LogError("Could not find Level Object");
        }

        level.addToBlockCounter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
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
