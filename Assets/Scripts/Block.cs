using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakSound;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.addToBlockCounter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
        level.removeFromBlockCounter();
        Destroy(gameObject);

    }
}
