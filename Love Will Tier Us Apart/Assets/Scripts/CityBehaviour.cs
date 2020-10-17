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
        StartCoroutine(newGeneration());
        cityNameText.text = cityName;
        humanPopulation = initialHumanPopulation;
    }

    IEnumerator newGeneration()
    {
        yield return new WaitForSeconds(1);
        robotReplication();
        setIncome();
        setUnrest();
        StartCoroutine(newGeneration());
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
        robotRateText.text = "RR = " + num.ToString();
        humanPopulationText.text = "People: " + Mathf.Round(humanPopulation).ToString();
        robotPopulationText.text = "Robots: " + Mathf.Round(robotPopulation).ToString();
        
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
        unrestText.text = "Unrest: " + Mathf.Round(unrest).ToString();
    }
}
