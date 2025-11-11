using System;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] private Text scoreOne;
    [SerializeField] private Text scoreTwo;
    [SerializeField] GameObject spawn;

    private SpriteRenderer spawnRenderer;
    public float speed = 10f;
    private Vector2 direction;
    private Rigidbody2D rb;

    public bool canMove = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnRenderer = spawn.GetComponent<SpriteRenderer>();

        resetBall();
    }

    void FixedUpdate()
    {

        if (!canMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = direction * speed;

        if (rb.position.x < -12)
        {
            int pointTwo = int.Parse(scoreTwo.text) + 1;
            scoreTwo.text = Convert.ToString(pointTwo);
            resetBall();

        }
        else if (rb.position.x > 12)
        {
            int pointOne = int.Parse(scoreOne.text) + 1;
            scoreOne.text = Convert.ToString(pointOne);
            resetBall();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Vector2.Reflect(direction, collision.GetContact(0).normal).normalized;
    }

    public void resetBall()
    {
        float randomY = UnityEngine.Random.Range(
            spawnRenderer.bounds.min.y + 1f,
            spawnRenderer.bounds.max.y - 1f
        );

        rb.position = new Vector2(spawn.transform.position.x, randomY);

        float x = UnityEngine.Random.value < 0.5f ? -1f : 1f;
        float y = 0f;

        while (Mathf.Abs(y) < 0.2f)
        {
            y = UnityEngine.Random.Range(-1f, 1f);
        }

        direction = new Vector2(x, y).normalized;
    }

    public void StartBall()
    {
        canMove = true;
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector2.zero;
        canMove = false;
    }


}
