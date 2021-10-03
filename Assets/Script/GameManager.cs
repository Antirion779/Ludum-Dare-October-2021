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
    GameObject enemy;

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
        
        if(chrono == 0)
        {
            GameOver();
            Destroy(player);
        }

        if (!gameIsOn)
        {
            gameIsOn = true;
            PlateauManager.ResetMap();
            chrono = memoryChrono;

            int tableau = Random.Range(0, 3);
            //Debug.Log("RANDOM =" + tableau);

            Vector3 pos = new Vector3(0, 0, 0);
            int x = 0;
            int y = 0;

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
            }
            else if (tableau == 2)
            {
                while(pos == new Vector3(positionPlayerX, positionPlayerY, 0) || PlateauManager.itemInPlateau[x, y] == true || pos == new Vector3(positionPlayerX, y, 0) || pos == new Vector3(x, positionPlayerY, 0))
                {
                    x = Random.Range(0, taillePlateau);
                    y = Random.Range(0, taillePlateau);
                    pos = new Vector3(x, y, 0);
                }
                Instantiate(enemy, pos, Quaternion.identity);
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
