using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //SELECTION OF OBJECTS
    public bool remedialSelected;
    public int remedialIdentifier;
    public string cityTag;
    void Start()
    {
        instance = this;
    }

    public void setCityAspect()
    {
        if (remedialSelected)
        {
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

    

    
}
