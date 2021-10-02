using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private ItemSpawn currentItemPickedUp;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            Debug.Log("+1");
            currentItemPickedUp.GetComponent<ItemSpawn>().currentItemPickedUp++;
            Destroy(col.gameObject);
        }
    }
}
