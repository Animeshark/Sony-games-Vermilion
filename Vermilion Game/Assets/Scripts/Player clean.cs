using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerclean : MonoBehaviour
{
<<<<<<< Updated upstream
    //Movement
    private bool isSprinting = false
=======

    Rigidbody2D rb;


    //Movement
    private bool isSprinting = false;

    [SerializeField] 
    private float walkSpeed = 3f;
    private float sprint = 2f;
    
>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        
=======
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
=======

    private void move()
    {
        

    }
>>>>>>> Stashed changes
}
