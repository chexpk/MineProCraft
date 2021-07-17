using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool isGrounded;
    public float speed = 6.0F;
    public float jumpSpeed = 2.0F;
    public float gravity = 9.8F;

    [SerializeField]
    private Vector3 playerVelocity = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // For debug
        isGrounded = controller.isGrounded;

        // Stop move
        playerVelocity.x = 0f;
        playerVelocity.z = 0f;

        // Move
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        move = transform.TransformDirection(move);
        playerVelocity += move;

        // Jump
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            playerVelocity.y = jumpSpeed; 
        }

        // Приземление
        if (controller.isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }

        // Gravity
        playerVelocity.y -= gravity * Time.deltaTime;

        // Apply move
        controller.Move(playerVelocity);
    }
}
