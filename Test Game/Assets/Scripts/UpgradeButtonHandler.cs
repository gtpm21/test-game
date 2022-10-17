using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject currency;
    [SerializeField] private GameObject axe;
    [SerializeField] private TextMeshProUGUI TMPLevel;
    [SerializeField] private TextMeshProUGUI TMPDamage;
    [SerializeField] private TextMeshProUGUI TMPCost;

    private void Update()
    {
        TMPLevel.text = "LVL." + axe.GetComponent<Chop>().damageLvl.ToString();
        TMPDamage.text = axe.GetComponent<Chop>().damage.ToString();
        TMPCost.text = axe.GetComponent<Chop>().upgradeCost.ToString() + "G";
    }

    public void BuyDamageUpgrade()
    {
        if(currency.GetComponent<Currency>().currency >= 10d)
        {
            currency.GetComponent<Currency>().currency -= axe.GetComponent<Chop>().upgradeCost;
            axe.GetComponent<Chop>().damage += 10;
            axe.GetComponent<Chop>().damageLvl++;
            axe.GetComponent<Chop>().upgradeCost += 5;
        }
    }
}
