using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Joystick joystick;
    public Animator animator;
    public Transform transform;
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public float runSpeed = 3f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 6f;
        }

        float horizontal = joystick.Horizontal;
        if (horizontal >= 0.2f)
        {
            horizontalMove = 1f;
            animator.SetFloat("vertical", 1);
        }
        else if (horizontal <= -0.2f)
        {
            horizontalMove = 1f;
            animator.SetFloat("vertical", 1);
        }
        else
        {
            horizontalMove = 0f;
            animator.SetFloat("vertical", 0);
        }

        float vertical = joystick.Vertical;
        if (vertical >= 0.2f)
        {
            verticalMove = 1f;
            animator.SetFloat("vertical", 1);
        }
        else if (vertical <= -0.2f)
        {
            verticalMove = -1f;
            animator.SetFloat("vertical", 1);
        }
        else
        {
            animator.SetFloat("vertical", 0);
            verticalMove = 0f;
        }

        Debug.Log(verticalMove);
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        
        controller.Move(move * runSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
    }
}
