using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
    [Header("Compnent")]
    [SerializeField] private GameObject item;

    [Header("Variables")]
    [SerializeField] private Text numberOfItemText;

    private int numberOfItem;
    public int currentItemPickedUp = 0;

    private void Start()
    {
        int spawn = Random.Range(3, 5);

        for (int i = 0; i < spawn; i++)
        {
            SpawnAnItem();
        }
    }

    private void Update()
    {
        numberOfItemText.text = currentItemPickedUp + " / " + numberOfItem;
    }

    public void SpawnAnItem()
    {
        int x = Random.Range(0, GameManager.taillePlateau);
        int y = Random.Range(0, GameManager.taillePlateau);

        Vector3 pos = new Vector3(x, y, 0);

        Instantiate(item, pos, Quaternion.identity);
        
        numberOfItem++;
    }

}
