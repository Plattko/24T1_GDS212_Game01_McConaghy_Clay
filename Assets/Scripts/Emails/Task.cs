using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Task : MonoBehaviour
{
    [SerializeField] private GameObject recordPrefab;
    [SerializeField] private GameObject emailSubBoxPrefab;
    [SerializeField] private GameObject taskTimerPrefab;
    [SerializeField] private TMP_InputField dropBoxInputField;

    [HideInInspector] public GameObject taskTimer;
    public TextMeshProUGUI taskTimerText;

    [HideInInspector]
    public enum TaskType
    {
        Image,
        Compare
    }

    [HideInInspector] public TaskType taskType;
    [HideInInspector] public float taskTime { get; private set; }

    // Compare task variables
    public GameObject record { get; private set; }
    private int incorrectEntries;

    public void GenerateTask()
    {
        // Pick a random task type
        //taskType = (TaskType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(TaskType)).Length);

        taskType = TaskType.Compare;

        switch (taskType)
        {
            case TaskType.Image:
                Debug.Log("Generated Image email.");
                taskTime = UnityEngine.Random.Range(25f, 30f);

                break;

            case TaskType.Compare:
                Debug.Log("Generated Compare email.");

                // Set incorrect entries to 0
                incorrectEntries = 0;

                // Give the record a 50% chance of being incorrect
                bool isRecordCorrect = UnityEngine.Random.Range(0, 2) == 1;

                // Instantiate the record and generate its seed
                record = Instantiate(recordPrefab, transform.parent);
                CompareDoc compareDoc = record.GetComponent<CompareDoc>();
                compareDoc.SetCompareDoc(compareDoc.GenerateCompareDocCode());

                if (!isRecordCorrect) // Record is incorrect
                {
                    CompareDoc.PurchaseType incPurchaseType;
                    string incAddress;
                    float incPrice;
                    DateTime incIssueDate;
                    DateTime incDueDate;
                    
                    string purchaseTypeEntry = compareDoc.purchaseTypeText.text;
                    string addressEntry = compareDoc.addressText.text;
                    string priceEntry = compareDoc.priceText.text;
                    string issueDateEntry = compareDoc.issueDateText.text;
                    string dueDateEntry = compareDoc.dueDateText.text;

                    List<string> correctInfo = new List<string>{ purchaseTypeEntry, addressEntry, priceEntry, issueDateEntry, dueDateEntry };
                    List<string> incorrectInfo = new List<string>();

                    // Set 1-2 of the record entries to be incorrect
                    incorrectEntries = UnityEngine.Random.Range(1, 3);

                    for (int i = 0; i < incorrectEntries; i++)
                    {
                        int index = UnityEngine.Random.Range(0, correctInfo.Count);

                        incorrectInfo.Add(correctInfo[index]);
                        correctInfo.Remove(correctInfo[index]);
                    }

                    // Replace the entry's correct info with incorrect info
                    foreach (string entry in incorrectInfo)
                    {
                        if (entry == purchaseTypeEntry)
                        {
                            incPurchaseType = (CompareDoc.PurchaseType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CompareDoc.PurchaseType)).Length);
                            compareDoc.purchaseTypeText.text = incPurchaseType.ToString();
                        }
                        else if (entry == addressEntry)
                        {
                            incAddress = Strings.addresses[UnityEngine.Random.Range(0, Strings.addresses.Length)];
                            compareDoc.addressText.text = incAddress;
                        }
                        else if (entry == priceEntry)
                        {
                            incPrice = UnityEngine.Random.Range(compareDoc.minPrice, compareDoc.maxPrice);
                            compareDoc.priceText.text = String.Format("${0:0.00}", incPrice);
                        }
                        else if (entry == issueDateEntry)
                        {
                            incIssueDate = compareDoc.RandomDate();
                            compareDoc.issueDateText.text = incIssueDate.ToString("yyyy-MM-dd");
                        }
                        else if (entry == dueDateEntry)
                        {
                            incDueDate = compareDoc.issueDate.AddDays(compareDoc.dueTimes[UnityEngine.Random.Range(0, compareDoc.dueTimes.Length)]);
                            compareDoc.dueDateText.text = incDueDate.ToString("yyyy-MM-dd");
                        }
                    }
                }

                // Attach the email sub-box with the compare doc to the email
                GameObject emailSubBox = Instantiate(emailSubBoxPrefab, transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0));
                emailSubBox.transform.SetSiblingIndex(1);

                // Set the task time
                //taskTime = UnityEngine.Random.Range(45f, 50f);
                taskTime = 45f;
                Debug.Log("Task time set.");

                break;

            default:
                Debug.LogWarning("Task type not found.");
                break;
        }

        taskTimer = Instantiate(taskTimerPrefab);
        taskTimer.GetComponent<TaskTimer>().Initialise(this);
    }

    public bool IsSubmissionCorrect()
    {
        int number = int.Parse(dropBoxInputField.text);
        
        if (number == incorrectEntries)
        {
            return true;
        }
        return false;
    }
}
