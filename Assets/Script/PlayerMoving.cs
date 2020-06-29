 using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVec, gravity;
    float speed = 5f, jumpSpeed = 13;
    int laneNumber = 1, 
        laneCount = 2;

    public float FirstLanePos, LaneDistance, SideSpeed;
    bool didChangeLastFrame = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveVec = new Vector3(1,0,0);
        gravity = Vector3.zero;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            gravity = Vector3.zero;
            if (Input.GetAxis("Jump") > 0)
            {
                gravity.y = jumpSpeed;
            }
        }
        else gravity += Physics.gravity * Time.deltaTime * 3;

        moveVec.x = speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;

        float input = Input.GetAxis("Horizontal");
        if (Mathf.Abs(input) > .1f)
        {
            if (!didChangeLastFrame)
            {
                didChangeLastFrame = true;
                laneNumber += (int)Mathf.Sign(input);
                laneNumber = Mathf.Clamp(laneNumber, 0, laneCount);
            }
        }
        else didChangeLastFrame = false;

        controller.Move(moveVec);
        Vector3 newPos = transform.position;
        newPos.z = Mathf.Lerp(newPos.z, FirstLanePos + (laneNumber * LaneDistance), Time.deltaTime * SideSpeed);
        transform.position = newPos;
    }
}
