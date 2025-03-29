using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    // Movement
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float sprint = 2f;
    int isSprinting = 0;
    bool canWalk = true;
    Vector2 moveUnit;
    Vector2 lastDirection;

    // Battle
    [SerializeField] float maxHealth = 10f;
    public float health;

    [SerializeField] float hitInvinsibility;
    private float hitTimer = 0;

    private bool isShooting = false;
    public Transform aim;
    

    public Arrow arrowPrefab;
    private float shootTimer = 0;
    [SerializeField] private float shootDelay;


    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Update()
    {
        check();

        if (canWalk)
        {
            move();
        }
        if (!isShooting)
        {
            rotate();
        }
        else
        {
            attack();
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime * 1;
        }
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime * 1;
        }
    }

    private void move()
    {
        moveUnit.x = Input.GetAxisRaw("Horizontal");
        moveUnit.y = Input.GetAxisRaw("Vertical");
        if(!moveUnit.Equals(new Vector2(0, 0)))
        {
            lastDirection = moveUnit;
        }

        moveUnit.Normalize();

        rb.velocity = moveUnit * (walkSpeed + sprint * isSprinting);
    }
    public void TakeDamage(float damage)
    {
        if (hitTimer <= 0)
        {  
            health -= damage;
            if (health <= 0)
            {
                Debug.Log("Died");
            }
            hitTimer = hitInvinsibility;
        }
    }
    
    private void rotate()
    {

        if(lastDirection.Equals(new Vector2(1, 0)))
        {
            aim.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (lastDirection.Equals(new Vector2(-1, 0)))
        {
            aim.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (lastDirection.Equals(new Vector2(0, 1)))
        {
            aim.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (lastDirection.Equals(new Vector2(0, -1)))
        {
            aim.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (lastDirection.Equals(new Vector2(1, 1)))
        {
            aim.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (lastDirection.Equals(new Vector2(-1, 1)))
        {
            aim.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (lastDirection.Equals(new Vector2(-1, -1)))
        {
            aim.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (lastDirection.Equals(new Vector2(1, -1)))
        {
            aim.rotation = Quaternion.Euler(0, 0, 135);
        }
    }

    private void attack()
    {
        if (shootTimer <= 0)
        {
            Instantiate(arrowPrefab, aim.position, aim.rotation);
            shootTimer = shootDelay;
        }
    }

    private void check()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = 1;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isShooting = false;
        }
    }
}
