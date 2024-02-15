using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskTimer : MonoBehaviour
{
    private Task task;
    private PlayerStrikes playerStrikes;

    private TextMeshProUGUI taskTimerText;
    private float taskTime;
    private bool hasTimerEnded = false;
    public bool isTimerStarted = false;

    private void Start()
    {
        playerStrikes = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStrikes>();
    }

    public void Initialise(Task task)
    {
        Debug.Log("Task initialised.");
        this.task = task;
        taskTimerText = task.taskTimerText;
        taskTime = task.taskTime;
    }

    private void Update()
    {
        if (taskTime > 0f && isTimerStarted) // Must figure out how to run when window is disabled
        {
            taskTime -= Time.deltaTime;
            // Update task timer UI
            taskTimerText.text = "Task due in: " + Mathf.RoundToInt(taskTime) + "s";
        }
        else if (taskTime <= 0 && !hasTimerEnded)
        {
            hasTimerEnded = true;
            Debug.Log("Task timer reached 0.");
            // Give player strike
            playerStrikes.AddStrike();
            // Remove it from the queue
            task.transform.parent.gameObject.GetComponent<EmailManager>().emailWindows.Dequeue();
            // Remove its notification
            task.transform.parent.gameObject.GetComponent<EmailNotification>().RemoveNotification();
            // Destroy the task
            Destroy(task.gameObject);
            Destroy(task.record);
            Destroy(gameObject);
        }
    }
}
