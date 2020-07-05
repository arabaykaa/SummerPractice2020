using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving3 : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 moveVec;
    //int i, speed = 1000;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveVec = new Vector3(1,0,0);
    }

    void Update()
    {
        /*if (Input.GetButtonDown("Jump"))
        {
            rb.MovePosition(moveVec);
        }*/
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.MovePosition(moveVec);
        }  
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.MovePosition(moveVec);
        }
    }
}
