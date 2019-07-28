using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float clampMin = 1f;
    [SerializeField] float clampMax = 15f;

    Ball ball;
    GameSession gameSession; 

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        if (!gameSession.IsAutoPlayEnabled())
        {
            float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
            SetPaddlePosition(mousePosInUnits);
        }
        else
        {
            SetPaddlePosition(ball.transform.position.x);
        }
    }

    private void SetPaddlePosition(float xPosition)
    {
        Vector2 paddlePosition = new Vector2(
            Mathf.Clamp(xPosition, clampMin, clampMax),
            transform.position.y
        );
        transform.position = paddlePosition;
    }
}
