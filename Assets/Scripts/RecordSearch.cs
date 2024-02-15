using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordSearch : MonoBehaviour
{
    [SerializeField] private GameObject recordPrefab;

    private TMP_InputField inputCode;

    private void Start()
    {
        inputCode = transform.GetChild(1).GetChild(1).GetComponent<TMP_InputField>();
    }

    public void SearchButton()
    {
        GameObject record = Instantiate(recordPrefab, transform.parent);

        record.GetComponent<RectTransform>().anchoredPosition = new Vector3(-300f, 108.5f, 0f);

        record.GetComponent<CompareDoc>().SetCompareDoc(inputCode.text);

        record.SetActive(true);
    }
}
