using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Transform playerPosition;
    public float playerPositionX;
    public float playerPositionY;

    private SpriteRenderer spriteDeSesMorts;
    private Animator animatorDeSesMorts;


    private void Start()
    {
        playerPosition = this.transform;

        //Set Pos default player
        playerPositionX = GameManager.positionPlayerX;
        playerPositionY = GameManager.positionPlayerY;

        spriteDeSesMorts = gameObject.GetComponent<SpriteRenderer>();
        animatorDeSesMorts = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyboardManager.keyUp))
        {
            if (playerPositionY != GameManager.taillePlateau - 1)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX, (int)playerPositionY + 1];
                playerPositionY++;
                playerPosition.eulerAngles = new Vector3(0, 0, 90);
                spriteDeSesMorts.flipX = false;
                spriteDeSesMorts.flipY = true;
                animatorDeSesMorts.SetBool("goesUp", true);
                animatorDeSesMorts.SetBool("goesDown", false);
                animatorDeSesMorts.SetBool("goesSide", false);
            }
        }
        else if (Input.GetKeyDown(KeyboardManager.keyDown))
        {
            if (playerPositionY != 0)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX, (int)playerPositionY - 1];
                playerPositionY--;
                playerPosition.eulerAngles = new Vector3(0, 0, -90);
                spriteDeSesMorts.flipX = true;
                spriteDeSesMorts.flipY = true;
                animatorDeSesMorts.SetBool("goesUp", false);
                animatorDeSesMorts.SetBool("goesDown", true);
                animatorDeSesMorts.SetBool("goesSide", false);
            }
        }
        else if (Input.GetKeyDown(KeyboardManager.keyLeft))
        {
            if (playerPositionX != 0)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX - 1, (int)playerPositionY];
                playerPositionX--;
                playerPosition.rotation = new Quaternion(0, 0, 180, 0);
                spriteDeSesMorts.flipX = true;
                spriteDeSesMorts.flipY = true;
                animatorDeSesMorts.SetBool("goesUp", false);
                animatorDeSesMorts.SetBool("goesDown", false);
                animatorDeSesMorts.SetBool("goesSide", true);
            }
        }
        else if (Input.GetKeyDown(KeyboardManager.keyRight))
        {
            if (playerPositionX != GameManager.taillePlateau - 1)
            {
                playerPosition.position = PlateauManager.plateau[(int)playerPositionX + 1, (int)playerPositionY];
                playerPositionX++;
                playerPosition.rotation = new Quaternion(0, 0, 0, 0);
                spriteDeSesMorts.flipX = true;
                spriteDeSesMorts.flipY = false;
                animatorDeSesMorts.SetBool("goesUp", false);
                animatorDeSesMorts.SetBool("goesDown", false);
                animatorDeSesMorts.SetBool("goesSide", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameObject Enemybahhhh = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(Enemybahhhh);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.CompareTag("EnemyBall"))
        {
            Destroy(gameObject);
            GameObject Enemybahhhh = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(Enemybahhhh);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
