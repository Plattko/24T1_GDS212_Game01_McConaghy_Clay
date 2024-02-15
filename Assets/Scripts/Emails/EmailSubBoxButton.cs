using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailSubBoxButton : MonoBehaviour
{
    private Task task;
    private GameObject record;
    
    void Start()
    {
        task = transform.parent.parent.parent.parent.parent.GetComponent<Task>();
    }

    public void OpenButton()
    {
        switch (task.taskType)
        {
            case Task.TaskType.Image:
                break;

            case Task.TaskType.Compare:
                task.record.GetComponent<RectTransform>().anchoredPosition = new Vector3(-103.5f, 108.5f, 0f);
                task.record.SetActive(true);
                break;

            default:
                break;
        }
    }
}
