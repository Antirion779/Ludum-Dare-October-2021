using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        scoreText.text = "You have completed : " + GameManager.score + " Rooms";
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        GameManager.score = 0;
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameManager.score = 0;
    }
}
