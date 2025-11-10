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
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnRenderer = spawn.GetComponent<SpriteRenderer>();

        ballDirection();
    }

    void FixedUpdate()
    {
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

    private void resetBall()
    {
        rb.position = Vector2.zero;

        ballDirection();

    }

    private void ballDirection()
    {
        rb.position = new Vector2(spawn.transform.position.x, UnityEngine.Random.Range(spawnRenderer.bounds.min.y - 0.5f, spawnRenderer.bounds.max.y - 0.5f));
        float x = UnityEngine.Random.value < 0.5f ? -1f : 1f;
        float y = UnityEngine.Random.Range(-0.5f, 0.5f);
        direction = new Vector2(x, y).normalized;

        rb.linearVelocity = direction * speed;
    }

}
