using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskTimerText;

    [HideInInspector]
    public enum TaskType
    {
        Image,
        Compare
    }

    [HideInInspector] public TaskType taskType;

    [HideInInspector] public bool isTimerStarted = false;
    private float taskTime;

    public void GenerateTask()
    {
        // Pick a random task type
        taskType = (TaskType)Random.Range(0, System.Enum.GetValues(typeof(TaskType)).Length);

        switch (taskType)
        {
            case TaskType.Image:
                Debug.Log("Generated Image email.");
                taskTime = Random.Range(25f, 30f);

                break;

            case TaskType.Compare:
                Debug.Log("Generated Compare email.");
                taskTime = Random.Range(45f, 50f);

                break;

            default:
                Debug.LogWarning("Task type not found.");
                break;
        }
    }

    private void Update()
    {
        if (taskTime > 0f && isTimerStarted) // Must figure out how to run when window is disabled
        {
            taskTime -= Time.deltaTime;
            // Update task timer UI
        }
        else if (taskTime <= 0)
        {
            // Give player strike and destroy task
        }
    }

    //public Task()
    //{
    //    // Pick a random task type
    //    taskType = (TaskType)Random.Range(0, System.Enum.GetValues(typeof(TaskType)).Length);

    //    switch (taskType)
    //    {
    //        case TaskType.Image:
    //            taskTime = Random.Range(25f, 30f);

    //            break;

    //        case TaskType.Compare:
    //            taskTime = Random.Range(45f, 50f);

    //            break;

    //        default:
    //            Debug.LogWarning("Task type not found.");
    //            break;
    //    }
    //}
}
