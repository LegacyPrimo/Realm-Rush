using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float currencyDrop;
    [SerializeField] private float currencyPenalty;

    private CurrencySystem currencySystem;

    private void Awake()
    {
        currencySystem = FindObjectOfType<CurrencySystem>();
    }

    public void RewardCurrency() 
    {
        if (currencySystem != null) 
        {
            currencySystem.DepositCurrency(currencyDrop);
        }
    }

    public void PenalizeCurrency() 
    {
        if (currencySystem != null) 
        {
            currencySystem.WithdrawCurrency(currencyPenalty);
        }
    }
}
