using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LargeNumbers;

public class UpgradeButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject currency;
    [SerializeField] private GameObject axe;
    [SerializeField] private TextMeshProUGUI TMPLevel;
    [SerializeField] private TextMeshProUGUI TMPDamage;
    [SerializeField] private TextMeshProUGUI TMPCost;
    public AlphabeticNotation upgradeCost = new AlphabeticNotation(10d);

    private void Update()
    {
        TMPLevel.text = "LVL." + axe.GetComponent<Chop>().damageLvl.ToString();
        TMPDamage.text = axe.GetComponent<Chop>().damage.ToString();
        TMPCost.text = upgradeCost.ToString();
    }

    public void BuyDamageUpgrade()
    {
        if(currency.GetComponent<Currency>().currency >= 10d)
        {
            currency.GetComponent<Currency>().currency -= upgradeCost;
            axe.GetComponent<Chop>().damage += 10;
            axe.GetComponent<Chop>().damageLvl++;
            upgradeCost += 5d;
        }
    }
}
