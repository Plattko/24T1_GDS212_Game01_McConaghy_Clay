using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGenerator : MonoBehaviour
{
    private float firstEmailTime = 5f;

    private float taskIntervalTimer;
    private float taskIntervalTimerReset = 30f;

    private float increaseRateTimer;
    private float increaseRateTimerReset = 120f;


    private enum GameState
    {
        Undefined,
        Onboarding,
        Gameplay
    }
    
    [SerializeField] private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Onboarding;
        StartCoroutine(GiveFirstEmail());

        taskIntervalTimer = 0f;
        increaseRateTimer = increaseRateTimerReset;
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log("Generating new task.");

                // Reset the task interval timer to the new randomised time
                taskIntervalTimer = taskIntervalTimerReset + Random.Range(-2f, 2f);
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
                
                if (taskIntervalTimerReset >= 12f)
                {
                    taskIntervalTimerReset -= 2f;
                }

                // Reset the increase rate timer
                increaseRateTimer = increaseRateTimerReset;
            }
        }
    }

    private IEnumerator GiveFirstEmail()
    {
        yield return new WaitForSecondsRealtime(firstEmailTime);

    }
}
