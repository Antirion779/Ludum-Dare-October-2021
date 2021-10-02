using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestSystemSpawn : MonoBehaviour
{
    public static TestSystemSpawn instance;

    [Header("Component")]
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject itemFinish;
    private GameObject[] fallCase;

    private void Start()
    {
        if (instance == null)
            instance = this;

        Instantiate(itemFinish, new Vector3(GameManager.taillePlateau - 1, GameManager.taillePlateau - 1, 0), Quaternion.identity);
        ActivateGame();
    }

    private void ActivateGame()
    {
        for (int i = 0; i < 100; i++)
        {
            SpawnAnItem();
        }
    }


    private void SpawnAnItem()
    {
        int voidCase = 0;

        int x = Random.Range(0, GameManager.taillePlateau);
        int y = Random.Range(0, GameManager.taillePlateau);
        Vector3 pos = new Vector3(x, y, 0);

        if (pos != new Vector3(GameManager.positionPlayerX, GameManager.positionPlayerY, 0) && pos != new Vector3(GameManager.taillePlateau - 1, GameManager.taillePlateau - 1, 0))
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if((x + i) <= GameManager.taillePlateau - 1 && (x + i) >= 0 && (y + j) <= GameManager.taillePlateau - 1 && (y + j) >= 0)
                    {
                        if (PlateauManager.itemInPlateau[x + i, y + j] == false)
                        {
                            voidCase++;
                        }
                    }
                    else
                    {
                        voidCase++;
                    }
                }
            }
        }

        if(voidCase == 9)
        {
            Instantiate(item, pos, Quaternion.identity);
            PlateauManager.itemInPlateau[x , y] = true;
        }
    }

    public void ResetPlateau()
    {
        fallCase = GameObject.FindGameObjectsWithTag("FallCase");
        foreach(GameObject voidcase in fallCase)
        {
            Destroy(voidcase);
        }
    }
}
