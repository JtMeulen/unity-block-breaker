using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float clampMin = 1f;
    [SerializeField] float clampMax = 15f;

    void Start()
    {

    }

    void Update()
    {
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(
            Mathf.Clamp(mousePosInUnits, clampMin, clampMax),
            transform.position.y
        );
        transform.position = paddlePosition;
    }
}
