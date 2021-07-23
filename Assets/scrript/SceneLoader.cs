using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    gameStatus gamestatus;

    private void Awake()
    {
        gamestatus = FindObjectOfType<gameStatus>();
    }
    public void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gamestatus.ResetGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
