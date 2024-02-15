using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksCompletedText : MonoBehaviour
{
    private TextMeshProUGUI tasksCompletedText;
    
    // Start is called before the first frame update
    void Start()
    {
        tasksCompletedText = GetComponent<TextMeshProUGUI>();
        tasksCompletedText.text = "Tasks Completed: " + TaskCounter.taskCounter;
    }
}
