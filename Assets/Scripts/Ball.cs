using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float ballStartYPos = 0.7f;
    [SerializeField] float StartYVelocity = 15f;
    [SerializeField] float minXVelocity = -2f;
    [SerializeField] float maxXVelocity = 2f;
    [SerializeField] AudioClip[] ballSounds;

    AudioSource ballBounceSource;
    bool ballLaunched = false;
    

    void Start()
    {
        ballBounceSource = GetComponent<AudioSource>();
        if(!ballBounceSource)
        {
            Debug.LogError("No sound connected");
        }
        if(!paddle)
        {
            Debug.LogError("Attach paddle Component");
        }
    }

    void Update()
    {
        if(!ballLaunched)
        {
            StickBallToPaddle();
            LaunchBall();
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 ballPosition = new Vector2(paddle.transform.position.x, ballStartYPos);
        transform.position = ballPosition;
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ballLaunched = true;
            float RandomStartXVelocity = Random.Range(minXVelocity, maxXVelocity);
            GetComponent<Rigidbody2D>().velocity = new Vector2(RandomStartXVelocity, StartYVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ballLaunched)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            ballBounceSource.PlayOneShot(clip);
        }
    }
}
