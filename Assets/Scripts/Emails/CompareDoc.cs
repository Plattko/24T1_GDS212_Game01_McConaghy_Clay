using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CompareDoc : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI appNameText;
    [SerializeField] private TextMeshProUGUI addressTitleText;

    public TextMeshProUGUI purchaseTypeText;
    public TextMeshProUGUI addressText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI issueDateText;
    public TextMeshProUGUI dueDateText;

    private int seedNumber;

    public enum PurchaseType
    {
        Goods,
        Service
    }
    public PurchaseType purchaseType { get; private set; }
    public string address { get; private set; }
    public float price { get; private set; }
    public DateTime issueDate { get; private set; }
    public DateTime dueDate { get; private set; }

    public float minPrice { get; private set; } = 60;
    public float maxPrice { get; private set; } = 2400;
    public int[] dueTimes { get; private set; } = { 14, 30, 60, 90, 180 };

    private void Start()
    {
        //inputSeed.text = seedNumber.ToString();

        //SetCompareDoc(GenerateCompareDocCode());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GenerateCompareDocCode();
        }
    }

    public String GenerateCompareDocCode()
    {
        string codeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345679";
        int length = 7;

        char[] randomCode = new char[length];

        for (int i = 0; i < length; i++)
        {
            if (i == 3)
            {
                randomCode[i] = '-';
            }
            else
            {
                randomCode[i] = codeChars[UnityEngine.Random.Range(0, codeChars.Length)];
            }
        }

        Debug.Log(new string(randomCode));
        return new string(randomCode);
    }

    public DateTime RandomDate()
    {
        System.Random gen = new System.Random();
        // Set the earliest date
        DateTime start = new DateTime(2023, 1, 1);
        // Set the time range
        int range = (DateTime.Today - start).Days;
        // Get a random date
        return start.AddDays(UnityEngine.Random.Range(0, range));
    }

    public void SetCompareDoc(string codeString)
    {
        Debug.Log("Setting Compare Doc.");

        int codeHash = codeString.GetHashCode();
        seedNumber = codeHash;

        UnityEngine.Random.InitState(seedNumber);

        appNameText.text = "Record " + codeString;

        purchaseType = (PurchaseType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(PurchaseType)).Length);
        purchaseTypeText.text = purchaseType.ToString();

        if (purchaseType == PurchaseType.Goods)
        {
            addressTitleText.text = "Deliver to:";
        }
        else if (purchaseType == PurchaseType.Service)
        {
            addressTitleText.text = "Address:";
        }

        address = Strings.addresses[UnityEngine.Random.Range(0, Strings.addresses.Length)];
        addressText.text = address;

        price = UnityEngine.Random.Range(minPrice, maxPrice);
        priceText.text = String.Format("${0:0.00}", price);

        issueDate = RandomDate();
        issueDateText.text = issueDate.ToString("yyyy-MM-dd");

        dueDate = issueDate.AddDays(dueTimes[UnityEngine.Random.Range(0, dueTimes.Length)]);
        dueDateText.text = dueDate.ToString("yyyy-MM-dd");
    }
}
