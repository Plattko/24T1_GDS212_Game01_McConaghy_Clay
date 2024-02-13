using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public enum TaskType
    {
        Image,
        Compare
    }

    public TaskType taskType;

    private float taskTime;

    public Task()
    {
        // Pick a random task type
        taskType = (TaskType)Random.Range(0, System.Enum.GetValues(typeof(TaskType)).Length);

        switch (taskType)
        {
            case TaskType.Image:
                taskTime = Random.Range(25f, 30f);

                break;

            case TaskType.Compare:
                taskTime = Random.Range(45f, 50f);

                break;

            default:
                Debug.LogWarning("Task type not found.");
                break;
        }
    }
}
