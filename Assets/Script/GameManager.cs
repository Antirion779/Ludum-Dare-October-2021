using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Plateau")]
    public static int taillePlateau = 6;
    public static int positionPlayerX = 0;
    public static int positionPlayerY = 0;

    [Header("Enemy")] 
    public static float tempsDeReaction = 1;

    public static float fallSpeed = 2;

    [SerializeField]
    GameObject player;
    
    [SerializeField]
    GameObject decor1; 
    [SerializeField]
    GameObject decor2;
    [SerializeField]
    GameObject decor3;

    [SerializeField]
    Text chronoText;

    [Header("Variable")]
    [SerializeField] 
    private int chrono;
    private int memoryChrono;
    private bool nextSecond;
    private float speedModifier;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void FixedUpdate()
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
            LightManager.instance.ResetLight();

            speedModifier = 1;
            tempsDeReaction = 1;
            fallSpeed = 2;

            chrono = memoryChrono;

            int tableau = Random.Range(0, 4);
            int modifier1 = 100;
            int modifier2 = 200;

            if (score > 10)
            {
                modifier1 = Random.Range(0, 6);
                while (modifier1 == tableau)
                {
                    modifier1 = Random.Range(0, 6);
                }

                int chooseDecor = Random.Range(0, 3);
                if(chooseDecor == 0)
                {
                    decor1.SetActive(true);
                    decor2.SetActive(false);
                    decor3.SetActive(false);
                }
                else if (chooseDecor == 1)
                {
                    decor1.SetActive(false);
                    decor2.SetActive(true);
                    decor3.SetActive(false);
                }
                else
                {
                    decor1.SetActive(false);
                    decor2.SetActive(false);
                    decor3.SetActive(true);
                }
            }

            if (score > 20)
            {
                modifier2 = Random.Range(0, 6);
                while (modifier2 == tableau || modifier2 == modifier1)
                {
                    modifier2 = Random.Range(0, 6);
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
            if (modifier1 == 4 || modifier2 == 4)
            {
                speedModifier = 0.5f;
                tempsDeReaction = 0.5f;
            }
            if (modifier1 == 5 || modifier2 == 5)
            {
                LightManager.instance.VariationLight();

                if(tableau == 2)
                {
                    LightManager.instance.ActivateEnemyLight();
                }
            }
        }
    }

    private IEnumerator WaitForTimer()
    {
        if(chrono != 0)
        {
            nextSecond = true;
            yield return new WaitForSeconds(speedModifier);
            chrono--;
            nextSecond = false;
        }
    }
}
