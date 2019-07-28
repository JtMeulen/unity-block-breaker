using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] bool autoPlay;
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerDestroy = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    int totalScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if(!scoreText)
        {
            Debug.LogError("Missing Score Object");
        }
        scoreText.text = totalScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addScore()
    {
        totalScore += pointsPerDestroy;
        scoreText.text = totalScore.ToString();
    }

    public void DestroySingletonObject()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }
}
