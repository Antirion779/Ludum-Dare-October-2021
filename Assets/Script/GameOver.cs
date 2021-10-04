using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string mainMenu;
    [SerializeField] private string restart;

    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene(restart);
    }
}
