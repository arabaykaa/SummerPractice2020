 using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVec, gravity;
    float speed = 5f, jumpSpeed = 13;
    int laneNumber = 1, 
        laneCount = 5;

    public float FirstLanePos, LaneDistance, SideSpeed;
    bool didChangeLastFrame = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveVec = new Vector3(1,0,0);
        gravity = Vector3.zero;
    }

    private void Update()
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
    }
    void FixedUpdate()
    {
        moveVec.z = speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;

        float input = Input.GetAxis("Horizontal");
        if (Mathf.Abs(input) > .1f)
        {
            if (!didChangeLastFrame)
            {
                didChangeLastFrame = true;
                if (laneNumber > 1 && laneNumber < 2)
                {
                    laneNumber += (int)Mathf.Sign(input);
                    laneNumber = Mathf.Clamp(laneNumber, -3, laneCount);
                } else if (laneNumber < 1)
                {
                    laneNumber += (int)Mathf.Sign(input);
                    laneNumber = Mathf.Clamp(laneNumber, -3, laneCount);
                }
            }
        }
        else didChangeLastFrame = false;

        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(newPos.x, FirstLanePos + (laneNumber * LaneDistance), Time.deltaTime * SideSpeed);
        transform.position = newPos;
    }
}
