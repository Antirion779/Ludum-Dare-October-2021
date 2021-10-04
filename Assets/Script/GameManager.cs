using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Plateau")]
    public static int taillePlateau = 6;
    public static int positionPlayerX = 0;
    public static int positionPlayerY = 0;

    [Header("Enemy")] 
    public static float tempsDeReaction = 1;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text chronoText;
    Text scoreText;
    [SerializeField]
    GameObject panelGameOver;

    [Header("Variable")]
    [SerializeField] 
    private int chrono;
    private int memoryChrono;
    private bool nextSecond;

    [SerializeField] private Text objectifText;

    public static int score;

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
            EnemySpawnManager.instance.ResetBullet();
            EnemySpawnManager.instance.killEnemyObjectif = false;
            FallGameManager.instance.isVictory = false;
            FallGameManager.instance.ResetExplosion();

            chrono = memoryChrono;

            int tableau = Random.Range(0, 4);
            int modifier1 = 100;
            int modifier2 = 200;

            if (score > 15)
            {
                modifier1 = Random.Range(0, 4);
                while (modifier1 == tableau)
                {
                    modifier1 = Random.Range(0, 4);
                }

            }

            if (score > 30)
            {
                modifier2 = Random.Range(0, 4);
                while (modifier2 == tableau || modifier2 == modifier1)
                {
                    modifier2 = Random.Range(0, 3);
                }
            }
            //Debug.Log("RANDOM =" + tableau);

            player.transform.position = PlateauManager.plateau[positionPlayerX, positionPlayerY];
            player.GetComponent<Player>().playerPositionX = positionPlayerX;
            player.GetComponent<Player>().playerPositionY = positionPlayerY;

            Debug.Log("Tableau : " + tableau + " ; " + "Modifier1 : " + modifier1 + " ; " + "Modifier2 : " + modifier2);

            //Debug.Log("score : " + score);
            if (tableau == 0 || modifier1 == 0 || modifier2 == 0)//trou
            {
                 TableauAtoBSystem.instance.ActivateGame();
                 if (tableau == 0)
                 {
                     TableauAtoBSystem.instance.ActiveVictory();
                     objectifText.text = "Reach the flag";
                 }
            }
            if (tableau == 1 || modifier1 == 1 || modifier2 == 1)//bouteille
            {
                 ItemSpawn.instance.SpawnAnItem();
                 if (tableau == 1)
                 {
                     ItemSpawn.instance.tableauIsOn = true;
                    objectifText.text = "Collect all the bottles";
                 }
            }
            if (tableau == 2 || modifier1 == 2 || modifier2 == 2)//Enemie
            {
                 EnemySpawnManager.instance.SpawnEnemy();
                 if (tableau == 2)
                 {
                     EnemySpawnManager.instance.killEnemyObjectif = true;
                    objectifText.text = "Kill the enemies";
                 }
            }
            if(tableau == 3 || modifier1 == 3 || modifier2 == 3)//fall thing
            {
                FallGameManager.instance.SpawnGoodCase();
                if (tableau == 3)
                {
                    FallGameManager.instance.isVictory = true;
                    objectifText.text = "Survive";
                }
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
