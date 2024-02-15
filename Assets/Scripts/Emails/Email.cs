using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Email : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI emailText;
    private GameController gameController;
    private Task task;

    void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
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
        }
        else // Is onboarding email
        {
            // Change game state to gameplay and destroy email
            gameController.gameState = GameController.GameState.Gameplay;
            Debug.Log("Started gameplay");
            Destroy(this.gameObject);
        }
    }

    //public Email(Task task = null)
    //{
    //    Debug.Log("Called Email constructor");
    //    this.task = task;

    //    if (task != null)
    //    {
    //        switch (this.task.taskType)
    //        {
    //            case Task.TaskType.Image: // Is image task
    //                emailText = Strings.ImageEmailText;
    //                break;

    //            case Task.TaskType.Compare: // Is compare task
    //                emailText = Strings.CompareEmailText;
    //                break;

    //            default:
    //                Debug.Log("Task is not in switch case.");
    //                break;
    //        }
    //    }
    //    else // Is onboarding email (no task)
    //    {
    //        Debug.Log("Is onboarding email.");
    //        emailText = Strings.OnboardingEmailText;
    //    }
    //}
}
