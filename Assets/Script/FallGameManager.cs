using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGameManager : MonoBehaviour
{
    public static FallGameManager instance;

    [SerializeField] 
    private GameObject cross;
    [SerializeField]
    private GameObject player;

    private float chrono;
    private float memoryChrono;
    private bool nextSecond;
    private int diviseur = 100;
    private bool isDie;

    public bool isVictory;

    private GameObject[] crossCase;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (nextSecond && chrono > 0)
        {
            //Debug.Log("patate");
            StartCoroutine(WaitForTimer());
        }

        if(chrono <= 0)
        {
            crossCase = GameObject.FindGameObjectsWithTag("Cross");
            foreach (GameObject cross in crossCase)
            {
                if(cross.transform.position == player.transform.position)
                {
                    Destroy(player);
                    isDie = true;
                }
                Destroy(cross);
            }

            if(isVictory && !isDie)
                GameManager.instance.gameIsOn = false;
        }
    }

    public void SpawnGoodCase()
    {
        int spawn = Random.Range(4, 7);
        for (int i = 0; i < spawn; i++)
        {
            int x = Random.Range(0, GameManager.taillePlateau);
            int y = Random.Range(0, GameManager.taillePlateau);

            Vector3 pos = new Vector3(x, y, 0);

            if (PlateauManager.itemInPlateau[x, y] == false && pos != cross.transform.position)
            {
                PlateauManager.itemInPlateau[x, y] = true;
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < GameManager.taillePlateau; i++)
        {
            for (int j = 0; j < GameManager.taillePlateau; j++)
            {
                if(PlateauManager.itemInPlateau[i, j] == false)
                {
                    Instantiate(cross, new Vector3(i, j, 0), Quaternion.identity);
                }
            }
        }

        chrono = 3;
        memoryChrono = chrono / diviseur;
        nextSecond = true;
    }

    private IEnumerator WaitForTimer()
    {
        if (chrono > 0)
        {
            nextSecond = false;
            yield return new WaitForSeconds(memoryChrono);
            chrono -= memoryChrono;

            crossCase = GameObject.FindGameObjectsWithTag("Cross");
            foreach (GameObject cross in crossCase)
            {
                cross.transform.localScale = new Vector3(cross.transform.localScale.x + 0.8f/ diviseur, cross.transform.localScale.y + 0.8f / diviseur, cross.transform.localScale.z + 0.8f / diviseur);
            }
            nextSecond = true;
        }
    }
}
