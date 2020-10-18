using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private int uniqueId;
    [SerializeField]
    private string description;
    void Start()
    {
        
    }

    public void setToManager()
    {
        GameManager.instance.remedialIdentifier = uniqueId;
        GameManager.instance.remedialSelected = true;
    }

    public void setDescriptionText()
    {
        GameObject descText = GameObject.FindGameObjectWithTag("DescriptionText");
        descText.GetComponent<TextMeshProUGUI>().text = description;
    }
}
