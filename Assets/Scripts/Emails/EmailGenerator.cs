using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailGenerator : MonoBehaviour
{
    [SerializeField] private GameObject onboardingEmailPrefab;
    [SerializeField] private GameObject taskEmailPrefab;
    
    private EmailManager emailManager;
    
    private bool hasGeneratedFirstEmail = false;

    private void Start()
    {
        emailManager = GetComponent<EmailManager>();
    }

    public void GenerateEmail()
    {
        Email email;
        Task task;

        if (!hasGeneratedFirstEmail) // Is onboarding email
        {
            hasGeneratedFirstEmail = true;

            // Instantiate onboarding email window
            GameObject onboardingEmail = Instantiate(onboardingEmailPrefab, transform);

            // Get email script component and set task to null
            email = onboardingEmail.GetComponent<Email>();
            email.SetTask(null);

            // Add email to queue
            emailManager.AddEmailToQueue(onboardingEmail);
        }
        else // Is task email
        {
            // Instantiate task email window
            GameObject taskEmail = Instantiate(taskEmailPrefab, transform);

            // Get task and email script components
            task = taskEmail.GetComponent<Task>();
            email = taskEmail.GetComponent<Email>();

            // Generate task and set the email's task to the generated task
            task.GenerateTask();
            email.SetTask(task);

            // Add email to queue
            emailManager.AddEmailToQueue(taskEmail);

            // Start task timer
            task.taskTimer.GetComponent<TaskTimer>().isTimerStarted = true;
        }
    }
}
