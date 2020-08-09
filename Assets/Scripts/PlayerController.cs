using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;// 0-stanga  1-mijloc 2-dreapta
    public float laneDistance = 4;//dist between lanes

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (!PlayerManager.gameStart) return;

        if(forwardSpeed < maxSpeed) forwardSpeed += 0.1f * Time.deltaTime;

        animator.SetBool("isGameStarted", true);

        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {
            //if (Input.GetKeyDown(KeyCode.UpArrow))
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }


        //if (Input.GetKeyDown(KeyCode.RightArrow))
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3) desiredLane = 2;
        }

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1) desiredLane = 0;
        }

        Vector3 newPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            newPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            newPosition += Vector3.right * laneDistance;
        }

        transform.position = newPosition;
        controller.center = controller.center;

    }

    private void FixedUpdate()
    {
        if (!PlayerManager.gameStart) return;

        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.transform.CompareTag("Obstacle"))
        {
            PlayerManager.gameOver = true;
            // Debug.Log("Obstacool");
        }
    }

}
