using UnityEngine;

public class PlayersCamera : MonoBehaviour
{
    public Transform Target;
    Vector3 moveVec, startDistance;
    void Start()
    {
        startDistance = transform.position - Target.position;
    }

    void Update()
    {
        moveVec = Target.position + startDistance;

        moveVec.x = 0;
        moveVec.y = startDistance.y;

        transform.position = moveVec;
    }
}
