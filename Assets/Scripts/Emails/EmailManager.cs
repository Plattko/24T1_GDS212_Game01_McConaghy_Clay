using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    // For the queueing and opening of emails
    
    private EmailNotification emailNotification;
    
    public Queue<GameObject> emailWindows = new Queue<GameObject>();

    private void Start()
    {
        emailNotification = GetComponent<EmailNotification>();
    }

    public void AddEmailToQueue(GameObject emailWindow)
    {
        // Add email to queue
        emailWindows.Enqueue(emailWindow);
        // Update email notification
        emailNotification.AddNotification();
    }

    public void EmailAppButton()
    {
        if (emailWindows.Count > 0)
        {
            // Get window at front of queue
            GameObject windowToOpen = emailWindows.Dequeue();
            // Set its position
            windowToOpen.GetComponent<RectTransform>().anchoredPosition = new Vector3(-103.5f, 108.5f, 0);
            // Enable the window
            windowToOpen.SetActive(true);
            // Update email notification
            emailNotification.RemoveNotification();
        }
        else
        {
            Debug.Log("No emails.");
        }
    }
}
