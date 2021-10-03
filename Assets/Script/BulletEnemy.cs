using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
           // player.TakeDamage(damage);
        }

        GameObject explosion = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject, 3.0f);
        Destroy(explosion, 2.0f);
    }


}
