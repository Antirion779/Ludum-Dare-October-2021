using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] private ItemSpawn currentItemPickedUp;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            audioSource.Play();
            //Debug.Log("+1");
            currentItemPickedUp.GetComponent<ItemSpawn>().currentItemPickedUp++;
            Destroy(col.gameObject);
        }
    }
}
