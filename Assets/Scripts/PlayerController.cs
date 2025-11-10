using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 moveInput;
    public bool isPlayerOne;

    public float moveSpeed = 12f;
    public float minY = -4.8f;
    public float maxY = 3.8f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveInput.y * moveSpeed);

        float clampY = Mathf.Clamp(rb.position.y, minY, maxY);
        rb.position = new Vector2(rb.position.x, clampY);
    }
    public void OnMoveP1(InputAction.CallbackContext context)
    {
        if (isPlayerOne)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        
    }

    public void OnMoveP2(InputAction.CallbackContext context)
    {
        if (!isPlayerOne)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        
    }
}
