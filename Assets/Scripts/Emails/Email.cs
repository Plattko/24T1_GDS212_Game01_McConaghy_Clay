using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Email : MonoBehaviour
{
    private GameController gameController;
    private Task task;

    [SerializeField] private TextMeshProUGUI emailText;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void SetTask(Task task)
    {
        this.task = task;

        if (this.task != null)
        {
            switch (this.task.taskType)
            {
                case Task.TaskType.Image: // Is image task
                    emailText.text = Strings.ImageEmailText;
                    break;

                case Task.TaskType.Compare: // Is compare task
                    emailText.text = Strings.CompareEmailText;
                    break;

                default:
                    Debug.Log("Task is not in switch case.");
                    break;
            }
        }
        else // Is onboarding email (no task)
        {
            Debug.Log("Is onboarding email.");
            emailText.text = Strings.OnboardingEmailText;
        }
    }

    public void SubmitTask()
    {
        if (task) // Is task email
        {
            // Check conditions
            Debug.Log("Checking conditions");
            if (task.IsSubmissionCorrect())
            {
                Debug.Log("Submission is correct.");
                TaskCounter.taskCounter++;
                Debug.Log("Task counter is: " + TaskCounter.taskCounter);
                Destroy(task.taskTimer);
                Destroy(task.record);
                Destroy(gameObject);
            }
        }
        else // Is onboarding email
        {
            // Change game state to gameplay and destroy email
            gameController.gameState = GameController.GameState.Gameplay;
            Debug.Log("Started gameplay");
            Destroy(gameObject);
        }
    }
}
