using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
    public static ItemSpawn instance;

    [Header("Compnent")]
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject player;

    [Header("Variables")]
    //[SerializeField] private Text numberOfItemText;

    private int numberOfItem;
    public int currentItemPickedUp = 0;
    private bool tableauIsOn;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        //numberOfItemText.text = currentItemPickedUp + " / " + numberOfItem;
        if(currentItemPickedUp == numberOfItem && tableauIsOn)
        {
            currentItemPickedUp = 0;
            tableauIsOn = false;
            GameManager.instance.gameIsOn = false;
        }
    }

    public void SpawnAnItem()
    {
        int spawn = Random.Range(3, 6);
        numberOfItem = 0;
        for (int i = 0; i < spawn; i++)
        {
            int x = Random.Range(0, GameManager.taillePlateau);
            int y = Random.Range(0, GameManager.taillePlateau);

            Vector3 pos = new Vector3(x, y, 0);

            if (PlateauManager.itemInPlateau[x, y] == false && pos != player.transform.position)
            {
                Instantiate(item, pos, Quaternion.identity);
                PlateauManager.itemInPlateau[x, y] = true;
                numberOfItem++;
            }
        
            else
            {
                i--;
            }

            Debug.Log(i);
        }

        tableauIsOn = true;

    }

}
