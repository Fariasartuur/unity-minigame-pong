using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject menuObject;
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private BallController ball;

    [SerializeField] private Text scoreOne;
    [SerializeField] private Text scoreTwo;

    [SerializeField] InputActionAsset InputActions;

    private InputAction menu;

    private bool isPaused = true;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        menu = InputActions.FindAction("Menu");
        InputActions.Enable();
    }


    void Update()
    {
        if (menu.WasPerformedThisFrame())
            Pause();

        Freeze(isPaused);


    }

    private void Freeze(bool x)
    {
        if (!x)
        {
            player1.canMove = true;
            player2.canMove = true;
            ball.canMove = true;
        }
        else
        {
            player1.canMove = false;
            player2.canMove = false;
            ball.canMove = false;
        }
    }

    public void Restart()
    {
        Pause();
        scoreOne.text = Convert.ToString(0);
        scoreTwo.text = Convert.ToString(0);
        ball.resetBall();
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Pause()
    {
        isPaused = !isPaused;
        menuObject.SetActive(isPaused);
    }
}
