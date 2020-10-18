using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityBehaviour : MonoBehaviour
{

    //CITY PROPERTIES
    [SerializeField]
    private string cityName;
    [SerializeField]
    private float initialHumanPopulation;
    [SerializeField]
    private float humanPopulation;
    [SerializeField]
    private float robotPopulation = 1;
    [SerializeField]
    private float income;
    [SerializeField]
    private float unrest;

    //ROBOT REPLICATION
    [SerializeField]
    private float robotRate;
    [SerializeField]
    private float robotRateIncrease;

    //INCOME FACTORS
    [SerializeField]
    private float incomeMultiplier;

    //UNREST FACTORS
    [SerializeField]
    private float unrestMultiplier = 1;


    //TEXT & GRAPHIC ELEMENTS
    [SerializeField]
    private TextMeshProUGUI cityNameText;
    [SerializeField]
    private TextMeshProUGUI robotRateText;
    [SerializeField]
    private TextMeshProUGUI humanPopulationText;
    [SerializeField]
    private TextMeshProUGUI robotPopulationText;
    [SerializeField]
    private TextMeshProUGUI incomeText;
    [SerializeField]
    private TextMeshProUGUI unrestText;
    [SerializeField]
    private TextMeshProUGUI tierText;

    //REMEDIAL AIDS TO CITY
    [SerializeField]
    private bool robotsReducedPopulationBoosted;
    [SerializeField]
    private bool incomeBoosted;
    [SerializeField]
    private bool unrestReduced;
    [SerializeField]
    private bool tierLevel;

    //ATTACHED TO AN ENUMERATOR SO RATE IS SET TO 1 AT A CERTAIN POINT
    [SerializeField]
    private float setRobotRateToOne;

    void Start()
    {
        cityNameText.text = cityName;
        humanPopulation = initialHumanPopulation;
    }

    public void newGeneration()
    {
        robotReplication();
        setIncome();
        setUnrest();
        humanPopulation += 1;
    }

    void robotReplication()
    {
        float newRobots = robotPopulation * robotRate;
        robotPopulation = newRobots;
        humanPopulation = initialHumanPopulation - robotPopulation;
        //SETS REPLICATION RATE
        increaseRR();
        //SETS TEXTS
        float num = (float)Mathf.Round(robotRate * 100) / 100;
        robotRateText.text = "RR: " + num.ToString();
        humanPopulationText.text = "People: " + Mathf.Round(humanPopulation).ToString();
        robotPopulationText.text = "Robots: " + Mathf.Round(robotPopulation).ToString();
        
    }

    public void setToManager()
    {
        GameManager.instance.cityTag = gameObject.tag;
        GameManager.instance.setCityAspect();
        GetComponent<Animator>().SetTrigger("Press");
    }

    void increaseRR()
    {
        robotRate += robotRateIncrease;
    }

    void setIncome()
    {
        income = humanPopulation * incomeMultiplier;
        incomeText.text = "Income: " + Mathf.Round(income).ToString();
    }

    void setUnrest()
    {
        unrest *= unrestMultiplier;
        unrestText.text = "Unrest: " + Mathf.Round(unrest).ToString();
    }

    float returnPercent(float i,int percent)
    {
        float num = (i / 100) * percent;
        return num;
    }

    public void modHunters()
    {
        robotPopulation -= returnPercent(robotPopulation, 20);
    }

    public void modIncome()
    {
        incomeMultiplier += returnPercent(incomeMultiplier, 10);
    }

    public void modUnrest()
    {
        unrest -= returnPercent(unrest, 30);
    }

    public void modTierOne()
    {
        robotRate -= returnPercent(robotRate, 30);
        unrestMultiplier = 1.05f;
        tierText.text = "T1";
    }

    public void modTierTwo()
    {
        robotRate -= returnPercent(robotRate, 50);
        unrestMultiplier = 1.1f;
        tierText.text = "T2";
    }

    public void modTierThree()
    {
        robotRate -= returnPercent(robotRate, 70);
        unrestMultiplier = 1.15f;
        tierText.text = "T3";
    }
}
