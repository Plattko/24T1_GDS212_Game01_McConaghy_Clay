using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    // For managing the ordering of app windows
    
    public List<Canvas> windowCanvases = new List<Canvas>();
    
    private void Awake()
    {
        windowCanvases.Clear();
    }

    // Set the sorting order of each canvas in the list to its index number + 1
    public void UpdateOrder()
    {
        for (int i = 0; i < windowCanvases.Count; i++)
        {
            windowCanvases[i].sortingOrder = i + 1;
        }
    }
}
