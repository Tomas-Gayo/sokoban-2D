using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private InputReader inputReader;

    #region Events subscription
    private void OnEnable()
    {
        inputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        inputReader.MoveEvent -= OnMove;
    }
    #endregion

    // Inputs
    Vector2 direction;

    public Vector2 Direction => direction;

    // References
    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateMovement(); 
    }

    private void LateUpdate()
    {
        UpdateAnimations();
    }
    // ========== Player Physics ========== //
    private void UpdateMovement()
    {
        // Avoid diagonal movement
        if (Mathf.Abs(direction.x) > 0.01f)
        {
            direction.y = 0;
            direction = direction.normalized;
        }

        rb.MovePosition(rb.position + (moveSpeed * Time.fixedDeltaTime * direction));
    }

    // ========== Player Animations ========== //
    private void UpdateAnimations()
    {
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }

    // ========== Player Inputs ========== //
    private void OnMove(Vector2 input)
    {
        direction = input;
    }
}
