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
    private Vector2 lastMoveDirection;
    private bool facingleft = false;

    // Aim rotation
    public Transform aim;
    bool isWalking = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccessInputs();

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
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    void ProccessInputs()
    {
        Sprint();

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }
}
