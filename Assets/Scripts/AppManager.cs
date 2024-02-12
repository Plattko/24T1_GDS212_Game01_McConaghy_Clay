using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    // For managing the opening/closing of apps

    public void OpenApp(Transform buttonTransform)
    {
        buttonTransform.GetChild(1).gameObject.SetActive(true);
    }

    public void CloseApp(Transform buttonTransform)
    {
        buttonTransform.parent.parent.gameObject.SetActive(false);
    }
}
