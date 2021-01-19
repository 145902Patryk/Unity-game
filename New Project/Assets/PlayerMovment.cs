using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 6f;
    public float sprint = 4f;
    public float gravity = -15f;
    Vector3 velocity;
    public Transform ground;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jump = 2f;
    float newSpeed;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        isGrounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x+transform.forward*z;
        move.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            newSpeed = speed + sprint;
        }
        else
        {
            newSpeed = speed;
        }

        controller.Move(move * newSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -3f * gravity);
        }
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            if (velocity.y >= 0)
            {
                velocity.y = -velocity.y + 2f;
            }
        }
        velocity.y += gravity * Time.deltaTime * 2f;
        controller.Move(velocity * Time.deltaTime);
    }
}
