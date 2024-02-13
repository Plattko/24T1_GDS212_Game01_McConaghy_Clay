using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Email : MonoBehaviour
{
    private GameController gameController;
    private Task task;

    private string emailText;
    
    void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
    }

    public Email(string emailText = "", Task task = null)
    {
        this.task = task;

        switch (this.task.taskType)
        {
            case Task.TaskType.Image:
                this.emailText = Strings.ImageEmailText;
                break;

            case Task.TaskType.Compare:
                this.emailText = Strings.CompareEmailText;
                break;

            default:
                this.emailText = emailText;
                break;
        }
    }

    public void SubmitTask()
    {
        if (task) // Is task email
        {
            // Check conditions
            Debug.Log("Checking conditions");
        }
        else // Is onboarding email
        {
            // Change game state to gameplay and destroy email
            gameController.gameState = GameController.GameState.Gameplay;
            Debug.Log("Started gameplay");
            Destroy(this.gameObject);
        }
    }
}
