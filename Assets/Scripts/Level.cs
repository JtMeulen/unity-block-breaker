using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    private int blocksRemaining;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        if (!sceneLoader)
        {
            Debug.LogError("Missing SceneLoader Object");
        }
    }

    public void addToBlockCounter()
    {
        blocksRemaining++;
    }

    public void removeFromBlockCounter()
    {
        blocksRemaining--;
        if(blocksRemaining <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
