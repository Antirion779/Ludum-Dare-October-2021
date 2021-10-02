using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Plateau")]
    public static int taillePlateau = 6;

    public static int positionPlayerX = 0;
    public static int positionPlayerY = 0;


    [Header("Enemy")] public static float tempsDeReaction = 1;

}
