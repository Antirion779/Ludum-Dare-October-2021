using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            TableauAtoBSystem.instance.ResetPlateau();
            GameManager.instance.GameOver();
        }
    }
}
