using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Transform playerPosition;
    float playerPositionX;
    float playerPositionY;
    Vector2[,] plateau = new Vector2[5,5];

    KeyCode keyUp = KeyCode.Z;
    KeyCode keyDown = KeyCode.S;
    KeyCode keyRight = KeyCode.D;
    KeyCode keyLeft = KeyCode.Q;
    [SerializeField]
    Text textButtonKeyboard;

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
        if (Input.GetKeyDown(keyUp))
        {
            if (playerPositionY != 4)
            {
                playerPosition.position = plateau[(int)playerPositionX, (int)playerPositionY + 1];
                playerPositionY++;
            }
        }
        else if (Input.GetKeyDown(keyDown))
        {
            if (playerPositionY != 0)
            {
                playerPosition.position = plateau[(int)playerPositionX, (int)playerPositionY - 1];
                playerPositionY--;
            }
        }
        else if (Input.GetKeyDown(keyLeft))
        {
            if (playerPositionX != 0)
            {
                playerPosition.position = plateau[(int)playerPositionX - 1, (int)playerPositionY];
                playerPositionX--;
            }
        }
        else if (Input.GetKeyDown(keyRight))
        {
            if(playerPositionX != 4)
            {
                playerPosition.position = plateau[(int)playerPositionX + 1, (int)playerPositionY];
                playerPositionX++;
            }
        }
    }

    public void SwitchAzertyQuerty()
    {
        if(keyUp == KeyCode.W)
        {
            textButtonKeyboard.text = "Azerty";
            keyUp = KeyCode.Z;
            keyLeft = KeyCode.Q;
        }
        else if(keyUp == KeyCode.Z)
        {
            textButtonKeyboard.text = "Querty";
            keyUp = KeyCode.W;
            keyLeft = KeyCode.A;
        }
    }
}
