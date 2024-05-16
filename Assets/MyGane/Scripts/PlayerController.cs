using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100;
    public float fuelValue = 20;
    public float damageValue = 100;
    public GameObject explosionPrefabs;

    private float currentHealth = 0;
    public enum DriveMode
    {
        Manual,
        Automatic
    }

    public DriveMode mode = DriveMode.Manual;
    public float speed = 10f;
    public float turnSpeed = 200f;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetButtonDown("ChangeMode")) // Q or E to switch between manual and automatic modes.
        {
            if (mode == DriveMode.Manual)
            {
                mode = DriveMode.Automatic;
            }
            else if (mode == DriveMode.Automatic)
            {
                mode = DriveMode.Manual;
            }
        }
        
        float speedAdjustment = Input.GetAxis("SpeedAdjustment"); // N to slow down, M to speed up.

        if (speedAdjustment > 0f)
        {
            speed++;
        }
        else if (speedAdjustment < 0f)
        {
            if (speed > 0) //Stop when the speed reduced to 0.
            {
                speed--;
            }
        }
        if (mode == DriveMode.Automatic)
        {
            MoveForward();

            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
        }
        else if (mode == DriveMode.Manual)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Steer the car
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

            // Move the car forward or backward
            if (verticalInput > 0f)
            {
                MoveForward();
            }
            else if (verticalInput < 0f)
            {
                MoveBackward();
            }
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void MoveBackward()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag  == "Fuel")
        {
            Destroy(other.gameObject);
            GameManager.Instance.SetFuel(fuelValue);
            IntantiateGame(other);
        }
        else if(other.tag == "Damage")
        {
            DamageHealth(damageValue);
            IntantiateGame(other);
        }
    }
    void IntantiateGame(Collider other)
    {
        Instantiate(explosionPrefabs, other.transform.position, Quaternion.identity);
    }
    private void DamageHealth(float health)
    {
        if (currentHealth>0)
        {
            currentHealth -= health;
        }
        else
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}
