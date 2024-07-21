using UnityEngine;
using TMPro;

public class UpgradeStats : MonoBehaviour
{
    private int PizzaPowerValue;
    [SerializeField] private TMP_Text PizzaPower;
    [SerializeField] private TMP_Text PizzaQualityStat;
    [SerializeField] private TMP_Text ArmorCapStat;
    [SerializeField] private TMP_Text PizzaCapStat;

    [SerializeField] StatsControllerSO PizzaQuality;
    [SerializeField] StatsControllerSO ArmorCap;
    [SerializeField] StatsControllerSO PizzaCap;

    private void Start()
    {
        PizzaPowerValue = 500;
    }

    public void UpgradeArmorCap()
    {
        if(ArmorCap.level >= ArmorCap.Maximum){
            return;
        }
        int level = ++ArmorCap.level;
        ArmorCap.Current += ArmorCap.levelIncrease;
        ArmorCapStat.text = "LEVEL " + level.ToString();
        UpdatePizaPower();
    }
    public void UpgradePizzaCap()
    {
        if(PizzaCap.level >= PizzaCap.maxLevel){
            return;
        }
        int level = ++PizzaCap.level;
        PizzaCap.Current += PizzaCap.levelIncrease;
        PizzaCapStat.text = "LEVEL " + level.ToString();
        UpdatePizaPower();
    }
    public void UpgradePizzaQuality()
    {
        if(PizzaQuality.level >= PizzaQuality.maxLevel){
            return
;        }
        int level = ++PizzaQuality.level;
        PizzaQuality.Current += PizzaQuality.levelIncrease;
        PizzaQualityStat.text = "LEVEL " + level.ToString();
        UpdatePizaPower();
    }

    private void UpdatePizaPower()
    {
        PizzaPowerValue += 50;
        PizzaPower.text = "LEVEL " + PizzaPowerValue.ToString();
    }
}


