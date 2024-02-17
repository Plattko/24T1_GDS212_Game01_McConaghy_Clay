using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmailNotification : MonoBehaviour
{
    // For updating the email notification image and number
    
    private GameObject notification;
    private TextMeshProUGUI notificationText;
    
    private int notificationNumber = 0;

    private void Start()
    {
        notification = transform.GetChild(2).gameObject;
        notificationText = notification.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        AddNotification();
    //    }
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        RemoveNotification();
    //    }
    //}

    public void AddNotification()
    {
        notificationNumber++;
        notificationText.text = notificationNumber.ToString();
        
        if (notification.activeInHierarchy == false && notificationNumber > 0)
        {
            notification.SetActive(true);
        }
    }

    public void RemoveNotification()
    {
        if (notificationNumber > 0)
        {
            notificationNumber--;
            notificationText.text = notificationNumber.ToString();

            if (notification.activeInHierarchy == true && notificationNumber <= 0)
            {
                notification.SetActive(false);
            }
        }
    }
}
