using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    private CurrencySystem currencySystem;

    private void Awake()
    {
        currencySystem = FindObjectOfType<CurrencySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCurrencyText();
    }

    private void ShowCurrencyText() 
    {
        currencyText.text = "Gold: " + currencySystem.CurrentBalance.ToString();
    }
}
