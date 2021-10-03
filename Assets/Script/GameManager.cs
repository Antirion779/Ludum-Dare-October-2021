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
    GameObject player;

    [SerializeField]
    Text chronoText;
    [SerializeField]
    GameObject panelGameOver;

    [Header("Variable")]
    [SerializeField] 
    private int chrono;
    private int memoryChrono;
    private bool nextSecond;

    public bool gameIsOn;

    public void Start()
    {
        if (instance == null)
            instance = this;

        memoryChrono = chrono;
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    private void Update()
    {
        chronoText.text = chrono.ToString();
        
        if(!nextSecond)
            StartCoroutine(WaitForTimer());

        /*if (Input.GetKeyDown(KeyCode.U))
        {
            EnemySpawnManager.instance.SpawnEnemy();
        }*/

        if(chrono == 0)
        {
            GameOver();
            Destroy(player);
        }

        if (!gameIsOn)
        {
            gameIsOn = true;
            PlateauManager.ResetMap();
            ItemSpawn.instance.ResetBottle();
            TableauAtoBSystem.instance.ResetPlateau();
            EnemySpawnManager.instance.ResetEnemy();
            EnemySpawnManager.instance.killEnemyObjectif = false;
            EnemySpawnManager.instance.ResetBullet();
            EnemySpawnManager.instance.ResetEnemyBall();

            chrono = memoryChrono;

            int tableau = Random.Range(0, 3);
            //Debug.Log("RANDOM =" + tableau);

            player.transform.position = PlateauManager.plateau[positionPlayerX, positionPlayerY];
            player.GetComponent<Player>().playerPositionX = positionPlayerX;
            player.GetComponent<Player>().playerPositionY = positionPlayerY;

            if (tableau == 0)
            {
                TableauAtoBSystem.instance.ActivateGame();
            }
            else if (tableau == 1)
            {
                ItemSpawn.instance.SpawnAnItem();
                ItemSpawn.instance.tableauIsOn = true;
            }
            else if (tableau == 2)
            {
                EnemySpawnManager.instance.SpawnEnemy();
                EnemySpawnManager.instance.killEnemyObjectif = true;
            }
        }
    }

    private IEnumerator WaitForTimer()
    {
        if(chrono != 0)
        {
            nextSecond = true;
            yield return new WaitForSeconds(1f);
            chrono--;
            nextSecond = false;
        }
    }
}
