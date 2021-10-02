using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform playerPosition;
    float playerPositionX;
    float playerPositionY;
    Vector2[,] plateau = new Vector2[5,5];

    private void Start()
    {
        playerPosition = this.transform;

        //Intégration de chaque coord dans chaque partie du tableau
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                plateau[i, j] = new Vector2(i,j);
            }
        }

        //Set Pos default player
        playerPosition.position = plateau[0, 0];
        playerPositionX = playerPosition.position.x;
        playerPositionY = playerPosition.position.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (playerPositionY != 4)
            {
                playerPosition.position = plateau[(int)playerPositionX, (int)playerPositionY + 1];
                playerPositionY++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerPositionY != 0)
            {
                playerPosition.position = plateau[(int)playerPositionX, (int)playerPositionY - 1];
                playerPositionY--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (playerPositionX != 0)
            {
                playerPosition.position = plateau[(int)playerPositionX - 1, (int)playerPositionY];
                playerPositionX--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(playerPositionX != 4)
            {
                playerPosition.position = plateau[(int)playerPositionX + 1, (int)playerPositionY];
                playerPositionX++;
            }
        }
    }
}
