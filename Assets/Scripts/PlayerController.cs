using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;

    private Rigidbody2D playerRb;

    public GameObject interactMessage;
    public float messageDuration = 5f;
    private Coroutine hideRoutine;

    public Animator animator;

    private Vector2 lastMove = Vector2.down;

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
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        interactMessage.SetActive(true);

        if (hideRoutine != null)
        {
            StopCoroutine(hideRoutine);
        }

        hideRoutine = StartCoroutine(HideMessageAfterDelay());

    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        interactMessage.SetActive(false);
        hideRoutine = null;
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
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
}
