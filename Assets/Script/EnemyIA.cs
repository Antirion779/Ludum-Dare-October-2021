using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [Header("Component")] 
    [SerializeField] private GameObject player;

    [Header("Variable")] 
    [SerializeField] private bool isInLine;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(WaitAction(GameManager.tempsDeReaction));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator WaitAction(float a)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(a);
        Action();
    }

    private void Action()
    {
        if (player.transform.position.x == transform.position.x || player.transform.position.y == transform.position.y)
        {
            isInLine = true;
        }

        if (isInLine)
        {
            Shoot();
        }
        else
        {
            MoveToPlayer();
        }
    }

    private void Shoot()
    {
        Debug.Log("RATRATATA");

        isInLine = false;
        StartCoroutine(WaitAction(GameManager.tempsDeReaction));
    }

    private void MoveToPlayer()
    {
        float diffX = player.transform.position.x - transform.position.x;//+ -> joueur à droite ; - -> joueur à gauche
        float diffY = player.transform.position.y - transform.position.y;//+ -> joueur en haut ; - -> joueur en bas

        float absDiffX = Mathf.Abs(diffX);
        float absDiffY = Mathf.Abs(diffY);

        if (absDiffX > absDiffY) //si vrai on le bouge sur Y
        {
            if (diffY > 0) //le monte d'une case
            {
                if (transform.position.y != GameManager.taillePlateau - 1)
                {
                    transform.position = PlateauManager.plateau[(int)transform.position.x, (int)transform.position.y + 1];
                    Debug.Log("UP");
                }
            }
            else //Le baisse d'une case
            {
                if (transform.position.y != 0)
                {
                    transform.position = PlateauManager.plateau[(int)transform.position.x, (int)transform.position.y - 1];
                    Debug.Log("Down");
                }
            }
        }

        else//sinon on le bouge sur X
        {
            if (diffX > 0)//droite d'une case
            {
                if(transform.position.x != GameManager.taillePlateau - 1)
                {
                    transform.position = PlateauManager.plateau[(int)transform.position.x +1, (int)transform.position.y];
                    Debug.Log("Droite");
                }
            }

            else//Gauche d'une case
            {
                if (transform.position.x != 0)
                {
                    transform.position = PlateauManager.plateau[(int)transform.position.x - 1, (int)transform.position.y];
                    Debug.Log("Gauche");
                }
            }
        }

        StartCoroutine(WaitAction(GameManager.tempsDeReaction));
    }
}
