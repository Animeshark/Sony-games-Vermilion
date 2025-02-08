using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovememt : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 input;

    [SerializeField] private float walkSpeed = 0.2f;
    [SerializeField] private float sprint = 2f;
    [SerializeField] private Sprite[] faceing;
    int isSprinting = 0;


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

    }

    private Vector2 Movement()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        return input;
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
    private void FixedUpdate()
    {
        rb.velocity = input * (walkSpeed + sprint * isSprinting);
    }
}
