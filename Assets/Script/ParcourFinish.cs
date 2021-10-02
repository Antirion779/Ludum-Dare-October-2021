using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dqfsdf");
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            TestSystemSpawn.instance.ResetPlateau();
        }
    }
}
