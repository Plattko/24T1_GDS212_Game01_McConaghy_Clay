using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowListUpdater : MonoBehaviour
{
    // For updating the list of canvases in the WindowManager
    
    private WindowManager windowManager;
    private Canvas canvas;
    
    private void Awake()
    {
        windowManager = GameObject.FindGameObjectWithTag("WindowManager").GetComponent<WindowManager>();
        canvas = GetComponent<Canvas>();
    }

    // Add this canvas to the list of canvases and update the order with it at the top
    private void OnEnable()
    {
        windowManager.windowCanvases.Add(canvas);
        windowManager.UpdateOrder();
    }

    // Remove this canvas from the list of window canvases
    private void OnDisable()
    {
        windowManager.windowCanvases.Remove(canvas);
    }

    // Bring this canvas to the top of the sorting order
    public void BringToTop()
    {
        Debug.Log("Brought window to top");
        windowManager.windowCanvases.Remove(canvas);
        windowManager.windowCanvases.Add(canvas);
        windowManager.UpdateOrder();
    }
}
