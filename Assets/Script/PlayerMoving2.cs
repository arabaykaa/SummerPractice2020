using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving2 : MonoBehaviour
{
    CharacterController cc;
    //Rigidbody rb;
    Vector3 moveVec, gravity;
    float speed = 5f, jumpSpeed = 13;

    public GameObject leftWall1, leftWall2, leftWall3;
    public GameObject ground4, ground5, ground6;
    public GameObject righttWall7, righWtall8, rightWall9;
    Vector3 l1, l2, l3, m4, m5, m6, r7, r8, r9;
    List<Vector3> list = new List<Vector3>();
    void Start()
    {
        cc = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        gravity = Vector3.zero;

        l1 = leftWall1.transform.position; l2 = leftWall2.transform.position; l3 = leftWall3.transform.position;
        m4 = ground4.transform.position; m5 = ground5.transform.position; m6 = ground6.transform.position;
        r7 = righttWall7.transform.position; r8 = righWtall8.transform.position; r9 = rightWall9.transform.position;
       
        list.Add(l1); list.Add(l2); list.Add(l3);
        list.Add(m4); list.Add(m5); list.Add(m6);
        list.Add(r7); list.Add(r8); list.Add(r9);
        //rb.position = m5;
    }

   
    void FixedUpdate()
    {
        if (cc.isGrounded)
        {
            gravity = Vector3.zero;
            if (Input.GetAxis("Jump") > 0)
            {
                gravity.y = jumpSpeed;
            }
        }
        else gravity += Physics.gravity * Time.deltaTime * 3;

        moveVec.z += speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            cc.transform.position = m4; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            cc.transform.position = m6; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            cc.transform.position = m5; 
        }
        
    }
}
