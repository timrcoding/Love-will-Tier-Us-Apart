using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int dayCounter;
    [SerializeField]
    private TextMeshProUGUI dayText;
    [SerializeField]
    private GameObject[] cityObjects;

    //SELECTION OF OBJECTS
    public bool remedialSelected;
    public int remedialIdentifier;
    public string cityTag;


    //NEWSFEED
    public List<string> cities;
    [SerializeField]
    private TextAsset genericNewsText;
    public List<string> genericNews;
    public List<string> citySpecificNews;
    [SerializeField]
    private GameObject newsFeed;
    [SerializeField]
    public int newsSpawnSpeed;
    void Start()
    {
        instance = this;
        StartCoroutine(newGenerationForCities());
        StartCoroutine(createNews());
        genericNews = new List<string>(genericNewsText.text.Split('\n'));
    }

    IEnumerator newGenerationForCities()
    {
        foreach(GameObject g in cityObjects)
        {
            CityBehaviour cb = g.GetComponent<CityBehaviour>();
            cb.newGeneration();
        }
        dayCounter++;
        setDayText();
        yield return new WaitForSeconds(1);
        StartCoroutine(newGenerationForCities());
    }

    public void setCityAspect()
    {
        
        if (remedialSelected)
        {
            Debug.Log("ASPECT SET");
            GameObject city = GameObject.FindGameObjectWithTag(cityTag);
            CityBehaviour cb = city.GetComponent<CityBehaviour>();
            switch (remedialIdentifier)
            {
                case 0:
                    cb.modHunters();
                    break;
                case 1:
                    cb.modIncome();
                    break;
                case 2:
                    cb.modUnrest();
                    break;
                case 3:
                    cb.modTierOne();
                    break;
                case 4:
                    cb.modTierTwo();
                    break;
                case 5:
                    cb.modTierThree();
                    break;
            }
            remedialSelected = false;
        }
        else
        {

        }
    }

    IEnumerator createNews()
    {
        yield return new WaitForSeconds(newsSpawnSpeed);
        GameObject descriptionPanel = GameObject.FindGameObjectWithTag("DescriptionPanel");
        GameObject news = Instantiate(newsFeed, newsFeed.transform.position, newsFeed.transform.rotation);
        news.transform.SetParent(descriptionPanel.transform,false);
        news.GetComponent<NewsfeedBehaviour>().newsText.text = generateGenericFeed();
        
        StartCoroutine(createNews());
    }

    string generateGenericFeed()
    {
        string city = cities[Random.Range(0, cities.Count-1)];
        string genericNewsSegment = genericNews[Random.Range(0, genericNews.Count-1)];
        string news = city + " " + genericNewsSegment;
        return news;
        Debug.Log(news);
    }

    void setDayText()
    {
        dayText.text = dayCounter.ToString();
    }
    
}
