using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyController : MonoBehaviour
{
    public int money;
    SpawnAgents sa;
    public TextMeshProUGUI moneyCounter;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        sa = gameObject.GetComponent<SpawnAgents>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney()
    {
        money += sa.waveNumber;
        UpdateText();
    }

    public void SubtractMoney(int amount)
    {
        money -= amount;
        UpdateText();
    }
    void UpdateText()
    {
        moneyCounter.text = "Money: " + money;
    }
}
