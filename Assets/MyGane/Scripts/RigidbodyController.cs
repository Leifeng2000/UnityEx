using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0f)
        {
            MoveForward();
        }
        else if (verticalInput < 0f)
        {
            MoveBackward();
        }

        float rotation = horizontalInput * turnSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void MoveForward()
    {
        rb.velocity = transform.forward * speed;
    }

    private void MoveBackward()
    {
        rb.velocity = -transform.forward * speed;
    }
}
