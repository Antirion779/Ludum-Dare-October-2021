using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameManager.score = 0;
    }
}
