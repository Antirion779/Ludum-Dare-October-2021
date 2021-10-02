using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Plateau")]
    public static int taillePlateau = 6;
    public static int positionPlayerX = 0;
    public static int positionPlayerY = 0;

    [Header("Enemy")] public static float tempsDeReaction = 1;

    [SerializeField]
    GameObject panelGameOver;

    public void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }
}
