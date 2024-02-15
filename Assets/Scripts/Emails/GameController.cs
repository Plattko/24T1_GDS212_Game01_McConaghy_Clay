using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // For controlling the state of the game,
    // the time interval between generating tasks,
    // and increasing the task generation rate over time

    [SerializeField] private Plattko.SceneController sceneController;
    [SerializeField] private EmailGenerator emailGenerator;
    
    private float firstEmailDelay = 5f;
    private float gameOverDelay = 5f;

    private float taskIntervalTimer;
    private float taskIntervalTimerReset = 20f;

    private float increaseRateTimer;
    private float increaseRateTimerReset = 30f;

    public enum GameState
    {
        Undefined,
        Onboarding,
        Gameplay
    }

    public GameState gameState;

    private void Awake()
    {
        TaskCounter.taskCounter = 0;
    }

    private void Start()
    {
        gameState = GameState.Onboarding;

        taskIntervalTimer = 0f;
        increaseRateTimer = increaseRateTimerReset;

        StartCoroutine(GiveOnboardingEmail());
    }

    private void Update()
    {
        if (gameState == GameState.Gameplay)
        {
            // Task interval timer
            if (taskIntervalTimer > 0f)
            {
                taskIntervalTimer -= Time.deltaTime;
            }
            else
            {
                // Generate new task
                emailGenerator.GenerateEmail();

                // Reset the task interval timer to the new randomised time
                taskIntervalTimer = taskIntervalTimerReset + Random.Range(-5f, 5f);
            }

            // Task rate increase timer
            if (increaseRateTimer > 0f)
            {
                increaseRateTimer -= Time.deltaTime;
            }
            else
            {
                // Increase task rate
                Debug.Log("Increasing task rate.");
                
                if (taskIntervalTimerReset > 6f)
                {
                    taskIntervalTimerReset -= 2f;
                    Debug.Log("Task interval timer is: " + taskIntervalTimerReset);
                }

                // Reset the increase rate timer
                increaseRateTimer = increaseRateTimerReset;
            }
        }
    }

    // Give the player their first email
    private IEnumerator GiveOnboardingEmail()
    {
        yield return new WaitForSeconds(firstEmailDelay);

        // Generate onboarding email
        emailGenerator.GenerateEmail();
        Debug.Log("Gave first email.");
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        // Load lose scene
        sceneController.LoadScene(2);
    }
}
