using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovememt : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] private float walkSpeed = 0.2f;
    [SerializeField] private float sprintMulti = 3f;
    bool isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Movement();
        Rotate();

    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        if (isSprinting)
        {
            rb.MovePosition(new Vector2(transform.position.x + horizontal * walkSpeed * sprintMulti, transform.position.y + vertical * walkSpeed * sprintMulti));
        }
        else
        {
            rb.MovePosition(new Vector2(transform.position.x + horizontal * walkSpeed, transform.position.y + vertical * walkSpeed));
        }

    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {   
            isSprinting = false;
        }
        
    }
    private void Rotate()
    {
        Debug.Log(rb.velocity);
    }
}
