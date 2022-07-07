using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] [Range(0,10000)] private float startingBalance;
    private float currentBalance;
    public float CurrentBalance { get { return currentBalance; } }

    private GameManager gameManager;

    private void Awake()
    {
        currentBalance = startingBalance;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DepositCurrency(float amount) 
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void WithdrawCurrency(float amount) 
    {
        currentBalance -= Mathf.Abs(amount);

        CheckBalance();
    }

    private void CheckBalance() 
    {
        if (currentBalance <= 0f) 
        {
            gameManager.GameOver();
        }
    }
}
