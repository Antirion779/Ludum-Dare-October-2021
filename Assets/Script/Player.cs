using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Transform playerPosition;
    public float playerPositionX;
    public float playerPositionY;
    

    KeyCode keyUp = KeyCode.Z;
    KeyCode keyDown = KeyCode.S;
    KeyCode keyRight = KeyCode.D;
    KeyCode keyLeft = KeyCode.Q;
    [SerializeField]
    Text textButtonKeyboard;

    private void Start()
    {
        playerPosition = this.transform;

        //Set Pos default player
        playerPositionX = GameManager.positionPlayerX;
        playerPositionY = GameManager.positionPlayerY;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyUp))
        {
            if (playerPositionY != GameManager.taillePlateau - 1)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX, (int)playerPositionY + 1];
                playerPositionY++;
                playerPosition.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(keyDown))
        {
            if (playerPositionY != 0)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX, (int)playerPositionY - 1];
                playerPositionY--;
                playerPosition.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(keyLeft))
        {
            if (playerPositionX != 0)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX - 1, (int)playerPositionY];
                playerPositionX--;
                playerPosition.rotation = new Quaternion(0, 0, 180, 0);
            }
        }
        else if (Input.GetKeyDown(keyRight))
        {
            if(playerPositionX != GameManager.taillePlateau - 1)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX + 1, (int)playerPositionY];
                playerPositionX++;
                playerPosition.rotation = new Quaternion(0, 0, 0, 0);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameObject Enemybahhhh = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(Enemybahhhh);
            //LOAD LA SCENE DE MORT DU PERSONNAGE
        }
        if (collision.CompareTag("EnemyBall"))
        {
            Destroy(gameObject);
            GameObject Enemybahhhh = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(Enemybahhhh);
            //LOAD LA SCENE DE MORT DU PERSONNAGE
        }
    }

}
