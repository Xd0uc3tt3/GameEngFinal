using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;

    private Rigidbody2D playerRb;

    public Animator animator;

    private Vector2 lastMove = Vector2.down;

    private bool moveEnabled = true;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        UpdateAnimatorParameters();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!moveEnabled)
        {
            return;
        }

        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        if (!moveEnabled)
        {
            return;
        }

        playerRb.MovePosition(playerRb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateAnimatorParameters()
    {
        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("MoveInputX", moveInput.x);
        animator.SetFloat("MoveInputY", moveInput.y);

        if (isMoving)
        {
            lastMove = moveInput.normalized;
            animator.SetFloat("LastMoveX", lastMove.x);
            animator.SetFloat("LastMoveY", lastMove.y);
        }
    }

    public void SetMovementEnabled(bool enabled)
    {
        moveEnabled = enabled;

        if (!enabled)
        {
            moveInput = Vector2.zero;
        }
    }
}
