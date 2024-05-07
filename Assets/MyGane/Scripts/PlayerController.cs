using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public float speed = 5f;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pointA.position)
        {
            targetPos = pointB.position;
        }
        else if(transform.position == pointB.position)
        {
            targetPos = pointC.position;
        }
        else if (transform.position == pointC.position)
        {
            targetPos = pointD.position;
        }
        else if (transform.position == pointD.position)
        {
            targetPos = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.LookAt(targetPos);
    }
}
