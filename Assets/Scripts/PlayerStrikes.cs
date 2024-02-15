using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStrikes : MonoBehaviour
{
    private GameController gameController;
    
    [SerializeField] private GameObject strikeOne;
    [SerializeField] private GameObject strikeTwo;
    [SerializeField] private GameObject strikeThree;

    private int playerStrikes = 0;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void AddStrike()
    {
        playerStrikes++;

        if (playerStrikes == 1)
        {
            strikeOne.SetActive(true);
        }
        else if (playerStrikes == 2)
        {
            strikeTwo.SetActive(true);
        }
        else if (playerStrikes == 3)
        {
            strikeThree.SetActive(true);
            StartCoroutine(gameController.GameOver());
        }
    }
}
