using UnityEngine;
using TMPro;
using BreakInfinity;
using System.Xml.Serialization;
using System.Collections.Generic;


public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake() => instance = this;

    public Data data;

    [SerializeField] private TMP_Text repsText;
    [SerializeField] private TMP_Text repsPerSecondText;
    [SerializeField] private TMP_Text repClickPowerText;

    public BigDouble ClickPower()
    {
        BigDouble total = 1;
        for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.clickUpgradesBasePower[i] * data.clickUpgradeLevel[i];
        }
        return total;
    }

    public BigDouble RepsPerSecond()
    {
        BigDouble total = 0;
        for (int i = 0; i < data.productionUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.productionUpgradesBasePower[i] * data.productionUpgradeLevel[i];
        }
        return total;
    }

    private void Start()
    {
        data = new Data();
        UpgradesManager.instance.StartUpgradeManager();
    }

    private void Update()
    {
        repsText.text = data.reps.ToString("F0") + " Reps";
        repsPerSecondText.text = $"{RepsPerSecond():F0}/s";
        repClickPowerText.text = "+" + ClickPower() + " Reps";
        data.reps += RepsPerSecond() * Time.deltaTime;
    }

    public void GenerateReps()
    {
        data.reps += ClickPower();
    }
}
