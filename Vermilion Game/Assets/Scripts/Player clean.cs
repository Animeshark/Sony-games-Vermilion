using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Playerclean : MonoBehaviour
{
    Rigidbody2D rb;

    // Movement
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float sprint = 2f;
    int isSprinting = 0;
    bool canWalk = true;
    Vector2 moveUnit;

    // Timer
    private float timer = 0f;
    private float colStart = 0f; // time at the colition

    // Battle
    [SerializeField] float maxHealth = 10f;
    public float health;

    [SerializeField] float hitInvinsibility;

    private bool isShoting = false;
    public Transform aim;

    public Arrow arrowPrefab;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float shootStart;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Update()
    {
        
        if (canWalk)
        {
            move();
        }
        if (!isShoting)
        {
            rotate();
        }
        else
        {
            attack();
        }

        timer += Time.deltaTime;
    }

    private void move()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = 1;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = 0;
        }

        moveUnit.x = Input.GetAxisRaw("Horizontal");
        moveUnit.y = Input.GetAxisRaw("Vertical");
        moveUnit.Normalize();

        rb.velocity = moveUnit * (walkSpeed + sprint * isSprinting);
    }
    public void TakeDamage(float damage)
    {
        if (timer - colStart >= hitInvinsibility)
        {  
            health -= damage;
            if (health <= 0)
            {
                Debug.Log("Died");
            }
            colStart = timer;
        }
    }
    
    private void rotate()
    {
        float deg = Mathf.Atan2(moveUnit.y, moveUnit.x);
        aim.rotation = Quaternion.Euler(0, 0, deg); // rotates the aim
    }

    private void attack()
    {
        if (timer - shootStart >= shootCooldown)
        {
            Instantiate(arrowPrefab, aim.position, aim.rotation);
            shootStart = timer;
        }
    }
}
