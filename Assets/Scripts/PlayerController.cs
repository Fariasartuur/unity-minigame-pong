using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionAsset InputActions;

    private InputAction movement;

    private Rigidbody2D rb;

    private Vector2 moveInput;

    public bool isPlayerOne;

    public float moveSpeed = 12f;
    public float minY = -4.8f;
    public float maxY = 3.8f;

    public bool canMove = false;

    void Awake()
    {
        InputActions.Enable();

        rb = GetComponent<Rigidbody2D>();

        if (isPlayerOne)
            movement = InputActions.FindAction("MoveP1");
        else
            movement = InputActions.FindAction("MoveP2");

    }

    private void Update()
    {
        moveInput = movement.ReadValue<Vector2>();

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveInput.y * moveSpeed);

            float clampY = Mathf.Clamp(rb.position.y, minY, maxY);
            rb.position = new Vector2(rb.position.x, clampY);
        }
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
