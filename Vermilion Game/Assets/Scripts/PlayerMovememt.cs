using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovememt : MonoBehaviour
{

    float walkSpeed = 1f;
    float sprintMulti = 3f;
    bool isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Movement();

    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        if (isSprinting)
        {
            transform.position = new Vector2(transform.position.x + horizontal * walkSpeed * sprintMulti, transform.position.y + vertical * walkSpeed * sprintMulti);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + horizontal * walkSpeed, transform.position.y + vertical * walkSpeed);
        }
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
}
