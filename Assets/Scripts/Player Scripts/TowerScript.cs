using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private float costAmount;

    public bool CreateTower(TowerScript tower, Vector3 position) 
    {
        CurrencySystem currencySystem = FindObjectOfType<CurrencySystem>();

        if (currencySystem == null) return false;
        if (currencySystem.CurrentBalance >= costAmount) 
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            currencySystem.WithdrawCurrency(costAmount);
            return true;
        }

        return false;
    }
}
