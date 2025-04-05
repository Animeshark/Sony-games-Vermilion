using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float movespeed;
    [SerializeField] private float damage;
    private float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
        lifetime -= Time.deltaTime * 1;
        
        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void move()
    {
        rb.velocity = transform.up * movespeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy1>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
