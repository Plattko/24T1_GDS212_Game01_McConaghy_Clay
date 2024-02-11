using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    private enum ButtonType
    {
        Open,
        Close
    }

    [SerializeField] private ButtonType buttonType;

    private AppManager appManager;
    private Transform buttonTransform;
    [SerializeField] private Button button;

    private void Awake()
    {
        appManager = GameObject.FindGameObjectWithTag("AppManager").GetComponent<AppManager>();
        buttonTransform = transform;
        button = GetComponent<Button>();
    }

    void Start()
    {
        if (buttonType == ButtonType.Open)
        {
            button.onClick.AddListener(() => appManager.OpenApp(buttonTransform));
        }
    }

    private void OnEnable()
    {
        if (buttonType == ButtonType.Close)
        {
            button.onClick.AddListener(() => appManager.CloseApp(buttonTransform));
        }
    }

    private void OnDisable()
    {
        if (buttonType == ButtonType.Close)
        {
            button.onClick.RemoveListener(() => appManager.CloseApp(buttonTransform));
        }
    }

    private void OnDestroy()
    {
        if (buttonType == ButtonType.Open)
        {
            button.onClick.RemoveListener(() => appManager.OpenApp(buttonTransform));
        }
    }
}