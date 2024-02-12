using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGenerator : MonoBehaviour
{
    private float firstTaskTime = 5f;
    private bool firstTaskCompleted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GiveFirstTask());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GiveFirstTask()
    {
        yield return new WaitForSecondsRealtime(firstTaskTime);

    }
}
