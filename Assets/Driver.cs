using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float brakeSpeed = 5f;

    private Rigidbody2D rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveInput = Input.GetAxis("Vertical");

        if (moveInput > 0)
        {
            currentSpeed += moveInput * moveSpeed * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }
        else if (moveInput < 0)
        {
            currentSpeed -= brakeSpeed * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }

        if (currentSpeed > 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }

        rb.velocity = transform.up * currentSpeed;
    }
}
