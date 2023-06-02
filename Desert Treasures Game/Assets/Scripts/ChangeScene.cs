using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int nextSceneId = 0;

    private void Update()
    {
        nextSceneId = FigureController.levelNumber + 1;
    }

    public void PlayLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void StartNewLevel()
    {
        SceneManager.LoadScene(nextSceneId);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
