using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float sprintSpeed;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] float rotationSpeed;
    [SerializeField] private GunSlotController gunSlotController;

    private const string HORIZONTALAXIS = "Horizontal";
    private const string VERTICALAXIS = "Vertical";

    private bool isGrounded = true;
    Rigidbody rb;
    bool isJumping = false;

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis(HORIZONTALAXIS);
        float z = Input.GetAxis(VERTICALAXIS);

        float mouseX = Input.GetAxis("Mouse X");

        Vector3 movement = new Vector3(x, 0, z);

        transform.Translate(movement * speed * Time.deltaTime);

        if (Mathf.Abs(x) > 0.1 || Mathf.Abs(z) > 0.1)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            animator.SetBool("isRunning", true);
        }
        else
            animator.SetBool("isRunning", false);

        if (gunSlotController.IsAnyActive())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("isShooting", true);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("isShooting", false);
            }
        }
    }
}
