using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauManager : MonoBehaviour
{
    //public static PlateauManager instance;

    public static Vector2[,] plateau = new Vector2[GameManager.taillePlateau, GameManager.taillePlateau];
    public static bool[,] itemInPlateau = new bool[GameManager.taillePlateau, GameManager.taillePlateau];

    private void Start()
    {
        /*if (instance == null)
            instance = this;*/

        //Intégration de chaque coord dans chaque partie du tableau
        for (int i = 0; i < GameManager.taillePlateau; i++)
        {
            for (int j = 0; j < GameManager.taillePlateau; j++)
            {
                plateau[i, j] = new Vector2(i, j);
            }
        }

    }
}
