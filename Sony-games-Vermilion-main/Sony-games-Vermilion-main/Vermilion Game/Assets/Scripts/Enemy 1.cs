using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update


    // attack

    public float health, maxHealth = 3f;
    public float damage = 1f;

    [SerializeField] float attackRange = 5f;
    [SerializeField] float attackCooldown = 5f;
    float attackCooldownPassed = 0;
    bool isAttacking = false;
    

    [SerializeField] float attackPhase1Dur = 1f;
    [SerializeField] float attackPhase2Dur = 3f;
    float attackDurPassed = 0f;
    Vector2 dashDirection;

    [SerializeField] float dashSpeed;



    // movement
    Rigidbody2D rb;
    public Player target;
    [SerializeField] float moveSpeed = 2f;
    Vector2 moveDirection;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Player>();
        attackCooldownPassed = attackCooldown;
        health = maxHealth;

        attackCooldownPassed = UnityEngine.Random.Range(1, 60) / 100;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        if (!isAttacking) rb.velocity = moveDirection * moveSpeed;
    }

    private Vector3 findTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        return direction;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
    
    public void Attack()
    {

        //Scout
        if (target || !isAttacking)
        {
            moveDirection = findTarget(target.transform);

            if (moveDirection.sqrMagnitude <= attackRange)
            {

                if (attackCooldownPassed >= attackCooldown)
                {
                    //Begin attack
                    isAttacking = true;
                    moveDirection = Vector2.zero;
                    rb.velocity = Vector2.zero;

                }
                else
                {
                    attackCooldownPassed += Time.deltaTime;
                }

            }
        }

        if (isAttacking)
        {
            attackDurPassed += Time.deltaTime;

            //Phase 1
            if (attackDurPassed <= attackPhase1Dur)
            {
                //Wind up
                dashDirection = findTarget(target.transform);
                // Animation needed only
            }
            //Phase 2 (between 1 and 3 seconds passed)
            else if (attackDurPassed <= attackPhase2Dur)
            {
                //Dash
                // Uses direction from last attackTimePassed                   Gives the slowing movement affect
                rb.velocity = new Vector2(dashDirection.x, dashDirection.y) * (attackPhase2Dur - attackDurPassed) * dashSpeed;
                GetComponent<Animator>().SetBool("isDashing", true);
                if(dashDirection.x < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }

            }
            //Phase 3 (after 3 seconds)
            else
            {
                //End attack
                attackDurPassed = 0;
                attackCooldownPassed = 0;
                isAttacking = false;
                GetComponent<Animator>().SetBool("isDashing", false);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            target.TakeDamage(damage);
    }
}
