using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    // Movement
    Vector2 input;
    [SerializeField] private float walkSpeed = 2f;
    bool canWalk = true;

    // Sprinting
    [SerializeField] private float sprint = 2f;
    int isSprinting = 0;

    // Visual rotation
    [SerializeField] private Sprite[] faceing;
    private bool facingleft = false;

    // Aim rotation
    public Transform aim;
    bool isWalking = false;

    // Player health
    public float maxHealth = 10f;
    private float health;

    [SerializeField] float colitionCooldown;
    private float colitionCooldownTimer = 0f;

    // Attack
    [SerializeField] float arrowSpeed = 1f;
    public float damage = 1f;

    Arrow arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = new Arrow();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ProccessInputs();
        input.Normalize();
        rb.velocity = input * (walkSpeed + sprint * isSprinting);



        if (colitionCooldownTimer > 0) colitionCooldownTimer -= Time.deltaTime * 1;
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = 1;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {   
            isSprinting = 0;
        }
        
    }

    void ProccessInputs()
    {
        Sprint();

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.P))
        {
            shoot();

        }

        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;

        }
    }

    public void TakeDamage(float damage)
    {
        if (colitionCooldownTimer <= 0)
        {
            health -= damage;
            if (health <= 0)
            {
                Debug.Log("Died");
            }
            colitionCooldownTimer = colitionCooldown;
        }
    }

    void shoot()
    {
        Instantiate(arrow, aim.transform.position, aim.transform.rotation);
    }
}
