using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.gameIsOn = false;
            GameManager.score++;
            //Debug.Log(GameManager.score);
        }
    }
}
