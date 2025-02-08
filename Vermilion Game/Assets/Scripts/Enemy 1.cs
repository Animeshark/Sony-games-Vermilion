using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float damage = 1f;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.Find("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
