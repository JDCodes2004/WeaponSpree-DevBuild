using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement_Character_Ammended : MonoBehaviour
{
    public CharacterController controller;

    public float MovementSpeed = 4f;
    public float gravity = -9.81f;
    public float jump = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;



    //Sprint code from home
    public bool isSprinting = false;
    public float sprintingMultiplier = 2f;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MovementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            isGrounded = false;
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Sprint Mechanic Code
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        Vector3 Walkmovement = new();

        Walkmovement = x * transform.right + z * transform.forward;

        if (isSprinting == true)
        {
            Walkmovement *= sprintingMultiplier;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(MovementSpeed * Time.deltaTime * Walkmovement);
        controller.Move(velocity * Time.deltaTime);

        }
}
