using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform playerPosition;
    Vector2[,] plateau = new Vector2[5,5];

    private void Start()
    {
        playerPosition = this.transform;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                plateau[i, j] = new Vector2(i,j);
            }
        }
        playerPosition.position = plateau[0, 0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerPosition.position = new Vector2(playerPosition.position.x, playerPosition.position.y + 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            playerPosition.position = new Vector2(playerPosition.position.x, playerPosition.position.y - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            playerPosition.position = new Vector2(playerPosition.position.x - 1, playerPosition.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerPosition.position = new Vector2(playerPosition.position.x + 1, playerPosition.position.y);
        }
    }
}
