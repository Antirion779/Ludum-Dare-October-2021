using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestSystemSpawn : MonoBehaviour
{
    [Header("Compnent")]
    [SerializeField] private GameObject item;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SpawnAnItem();
        }
    }


    public void SpawnAnItem()
    {
        int voidCase = 0;

        int x = Random.Range(0, GameManager.taillePlateau);
        int y = Random.Range(0, GameManager.taillePlateau);
        Vector3 pos = new Vector3(x, y, 0);
        
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if((x + i <= GameManager.taillePlateau - 1 && x + i >= 0) || (y + j <= GameManager.taillePlateau - 1 && y + j >= 0))
                {
                    if (PlateauManager.itemInPlateau[x + i, y + j] == false)
                    {
                        Debug.Log("Patate");
                        voidCase++;
                    }
                }
            }
        }

        if(voidCase == 9)
        {
            Debug.Log("AN ITEM APPEAR");
            Instantiate(item, pos, Quaternion.identity);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    PlateauManager.itemInPlateau[x + i, y + j] = true;
                }
            }
        }
        
    }
}
